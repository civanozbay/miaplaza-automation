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


        [FindsBy(How = How.CssSelector, Using = "span#ariarequired-Name0 + input[name='Name']")]
        private IWebElement nameField;

        [FindsBy(How = How.CssSelector, Using = "span#ariarequired-Name1 + input[name='Name']")]
        private IWebElement surnameField;

        [FindsBy(How = How.Id, Using = "Email-arialabel")]
        private IWebElement emailField;

        [FindsBy(How = How.Id, Using = "PhoneNumber")]
        private IWebElement phoneField;

        [FindsBy(How = How.Id, Using = "Dropdown-arialabel")]
        private IWebElement secondParentInfoDropdown;

        [FindsBy(How = How.CssSelector, Using = "#Checkbox_1+label")]
        private IWebElement firstCheckbox;

        [FindsBy(How = How.Id, Using = "Date-date")]
        private IWebElement dateField;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Next\nNavigates to page 3 out of 4']")]
        private IWebElement nextButtonPage2;


        public IWebElement getNextButtonPage1()
        {
            return nextButtonPage1;
        }
        public IWebElement getNameField()
        {
            return nameField;
        }
        public IWebElement getSurnameField()
        {
            return surnameField;
        }
        public IWebElement getEmailField()
        {
            return emailField;
        }
        public IWebElement getPhoneField()
        {
            return phoneField;
        }

        public IWebElement getSecondParentInfoDropdown()
        {
            return secondParentInfoDropdown;
        }

        public IWebElement getFirstCheckbox()
        {
            return firstCheckbox;
        }

        public IWebElement getDateField()
        {
            return dateField;
        }


        public IWebElement getNextButtonPage2()
        {
            return nextButtonPage2;
        }

    }
}

