using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Net.NetworkInformation;

namespace miaplaza_automation.pageObjects
{
	public class StudentInformation
	{
        private IWebDriver driver;
        public StudentInformation(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "Section3-li")]
        private IWebElement studentInformationText;

        public IWebElement getStudentInformationText()
        {
            return studentInformationText;
        }
    }
}

