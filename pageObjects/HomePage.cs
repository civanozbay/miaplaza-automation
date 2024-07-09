using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Net.NetworkInformation;

namespace miaplaza_automation.pageObjects
{
	public class HomePage
	{		
        private IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='https://miaprep.com/online-school/']")]
        private IWebElement onlineHighSchoolLink;

        public IWebElement getOnlineHighSchoolLink()
        {
            return onlineHighSchoolLink;
        }
    }
}

