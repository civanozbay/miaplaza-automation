using System;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace miaplaza_automation.utilities
{
	public class Base
	{
        ExtentReports extent;
        ExtentTest test;
        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host name", "Local host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Civan");
        }
        public IWebDriver driver;
        public Base()
        { }

        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            string browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://miacademy.co/#/";

        }

        [TearDown]
        public void closeBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
            if(status == TestStatus.Failed)
            {
                test.Fail("Test failed", captureScreenShot(driver, fileName));
                test.Log(Status.Fail,"test failed with logtrace"+stackTrace);
            }else if(status == TestStatus.Passed) { }
            extent.Flush();
            driver.Quit();
        }
        public void InitBrowser(string browserName)
            {
                switch (browserName)
                {
                    case "Firefox":
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    case "Chrome":
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    case "Edge":
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                }
            }
        public IWebDriver getDriver()
        {
            return driver;
        }
        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts =(ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }



        public void ScrollDown(int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {pixels});");
        }

        public void ScrollUp(int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, -{pixels});");
        }

    }
}

