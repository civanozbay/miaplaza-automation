using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Net.NetworkInformation;

namespace miaplaza_automation.pageObjects
{
	public class OnlineHighSchool
	{
        private IWebDriver driver;
        public OnlineHighSchool(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.LinkText, Using = "Apply to Our School")]
        private IWebElement applyToSchool;

        public IWebElement getApplyToSchool()
        {
            return applyToSchool;
        }
    }
}

