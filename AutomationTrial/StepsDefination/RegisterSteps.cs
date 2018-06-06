using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTrial.Global;
using AutomationTrial.Helpers;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace AutomationTrial.StepDefinations
{
    [Binding]
    public class RegisterSteps
    {
        private IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>();

        private ExtentTest test = ScenarioContext.Current.Get<ExtentTest>();

        //POM_Register _RegisterObj = new POM_Register();

        [Given(@"I have navigated to url for NopCommerce")]
        public void GivenIHaveNavigatedToUrlForNopCommerce()
        {
            driver.Navigate().GoToUrl(Constants.NopComURL);
            string pageTitle = driver.Title;
            Assert.AreEqual(pageTitle, "nopCommerce - ASP.NET Open-source Ecommerce Shopping Cart Solution");
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I have clicked on Register")]
        public void GivenIHaveClickedOnRegister()
        {
            IWebElement RegisterLnq = driver.FindElement(By.XPath("html/body/form/div[3]/div[1]/div[2]/div/ul[1]/li[1]/a"));
            RegisterLnq.Click();
            Console.WriteLine("User able to click on Register");
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I have been navigated to Register page")]
        public void GivenIHaveBeenNavigatedToRegisterPage()
        {
            string pageTitle = driver.Title;
            Assert.AreEqual(pageTitle, "Register - nopCommerce");
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I enter my Credentials to register")]
        public void GivenIEnterMyCredentialsToRegister()
        {
            IWebElement RegisterLnq = driver.FindElement(By.XPath("html/body/form/div[3]/div[1]/div[2]/div/ul[1]/li[1]/a"));
            RegisterLnq.Click();
            IWebElement FirstName = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_txtFirstName"));
            FirstName.SendKeys("Alpha");
            IWebElement LastName = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_txtLastName"));
            LastName.SendKeys("Belgium");
            IWebElement Email = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_Email"));
            Email.SendKeys("harshasurbhi@ymail.com");
            IWebElement UserName = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_UserName"));
            UserName.SendKeys("Alpha$");
            IWebElement CountryDdl = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_ddlCountry"));
            SelectElement selectAnCountry = new SelectElement(CountryDdl);
            selectAnCountry.SelectByValue("6"); //Value 6 for selecting "Australia"

            IWebElement RoleDdl = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_ddlRole"));
            SelectElement selectARole = new SelectElement(RoleDdl);
            selectARole.SelectByValue("10"); //value 2 for Technical/Developer

            IWebElement Password = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_Password"));
            Password.SendKeys("Qwerty@123");
            IWebElement CnfPassword = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm_CreateUserStepContainer_ConfirmPassword"));
            CnfPassword.SendKeys("Qwerty@123");
            IWebElement SubmitRegister = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm___CustomNav0_StepNextButton"));
           


            bool bSubRegister = SubmitRegister.Enabled;
            if (bSubRegister)
            {
                Assert.IsTrue(bSubRegister, "Form is filled and Register Button Enabled");
            }
            //ScenarioContext.Current.Pending();
        }

        [When(@"I click on Register")]
        public void WhenIClickOnRegister()
        {

            IWebElement SubmitRegister = driver.FindElement(By.Id("ctl00_ctl00_cph1_cph1_ctrlCustomerRegister_CreateUserForm___CustomNav0_StepNextButton"));
            SubmitRegister.Click();

        }

        [Then(@"my account should be registerd on NopCommerce website")]
        public void ThenMyAccountShouldBeRegisterdOnNopCommerceWebsite()
        {
            try
            {
                string PTitle = driver.Title;
                Assert.AreEqual(PTitle, "Register - nopCommerce");
            }
            catch (Exception)
            {
                test.Fail("Failure occurred ", MediaEntityBuilder.CreateScreenCaptureFromPath(Reports.SaveScreenshot(driver)).Build());
            }
            
        }

    }

}
