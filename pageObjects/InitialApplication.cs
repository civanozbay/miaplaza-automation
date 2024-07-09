using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Net.NetworkInformation;

namespace miaplaza_automation.pageObjects
{
	public class InitialApplication
	{
        private IWebDriver driver;
        public InitialApplication(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "button[elname='next']")]
        private IWebElement nextButtonPage1;

        public IWebElement getNextButtonPage1()
        {
            return nextButtonPage1;
        }
    }
}

