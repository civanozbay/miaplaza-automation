using System;
using miaplaza_automation.pageObjects;
using miaplaza_automation.utilities;
using OpenQA.Selenium.Support.UI;

namespace miaplaza_automation.e2e
{
	public class InitialApplicationMOHS : Base
	{
		public InitialApplicationMOHS()
		{
		}
		[Test]
		public void initialApplication()
		{
			HomePage homePage = new HomePage(getDriver());
			homePage.getOnlineHighSchoolLink().Click();
			string expectedUrlOnlineSchool = "https://miaprep.com/online-school/";
			Assert.AreEqual(expectedUrlOnlineSchool, getDriver().Url);
			
            OnlineHighSchool onlineHighSchool = new OnlineHighSchool(getDriver());
            String expectedUrlForm = "https://forms.zohopublic.com/miaplazahelp/form/MOHSInitialApplication/formperma/okCyt4yyq39rZvSBXB9FSjDeek1ilbRVK1iNCK--3K8";
            onlineHighSchool.getApplyToSchool().Click();
            Assert.AreEqual(expectedUrlForm, getDriver().Url);

            InitialApplication initialApplication = new InitialApplication(getDriver());
			initialApplication.getNextButtonPage1().Click();
			initialApplication.getNameField().SendKeys("Civan");
            initialApplication.getSurnameField().SendKeys("Ozbay");
			initialApplication.getEmailField().SendKeys("test1234@gmail.com");
			initialApplication.getPhoneField().SendKeys("0123456789");

            SelectElement select = new SelectElement(initialApplication.getSecondParentInfoDropdown());
			select.SelectByValue("No");

			initialApplication.getFirstCheckbox().Click();
			ScrollDown(500);
			initialApplication.getDateField().SendKeys("10-Aug-2024");
			initialApplication.getNextButtonPage2().Click();

			StudentInformation studentInformation = new StudentInformation(getDriver());
			Assert.True(studentInformation.getStudentInformationText().Displayed);
				
            

        }
	}
}

