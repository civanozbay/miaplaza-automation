using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace miaplaza_automation.utilities
{
	public class Base
	{
        public IWebDriver driver;
        public Base()
        { }

            [SetUp]
            public void Setup()
            {
                string browserName = ConfigurationManager.AppSettings["browser"];
                InitBrowser(browserName);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
             
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
            [TearDown]
            public void closeBrowser()
            {
                TestContext.Progress.WriteLine("setup method execution");
                driver.Quit();
            }
        
	}
}

