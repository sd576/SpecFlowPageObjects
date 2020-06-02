using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowScratch.PageObjects;
using TechTalk.SpecFlow;

namespace SpecFlowScratch
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver _driver;
        HomePage _homePage;
        ConduitWebPage _conduitWebpage;
        SignUpPage _signUpPage;
        SignInPage _signInPage;

        public LoginSteps(IWebDriver driver, HomePage hPg, ConduitWebPage cdpg, SignUpPage sUpg, SignInPage sIpg)
        {
            _driver = driver;
            _homePage = hPg;
            _conduitWebpage = cdpg;
            _signUpPage = sUpg;
            _signInPage = sIpg;
        }

        [Given(@"the SignIn page is displayed")]
        public void GivenTheSignInPageIsDisplayed()
        {
            Assert.AreEqual("Sign in — Conduit", _homePage.PageTitle);
        }
        
        [Given(@"the User navigates to Sign up page")]
        public void GivenTheSignUpPageIsDisplayed()
        {
            _conduitWebpage.GoToSignUpPage();
        }
        
        [When(@"the User Navigates to settings page")]
        public void WhenTheUserNavigatesToSettingsPage()
        {
            _homePage.GoToSettingsPage();
        }

        [When(@"the User Logs Out")]
        public void WhenTheUserClicksTheLogOutButton()
        {
            _homePage.GoToSettingsPage().ClickLogOutButton();
        }

        [When(@"the User enters the Username '(.*)' and the Email '(.*)' and the Password '(.*)'")]
        public void WhenTheUserEntersTheUsernameAndTheEmailAndThePassword(string username, string email, string password)
        {
            _signUpPage.FillSignUpPage(username, email, password);
        }

        [Given(@"User Login with correct details successfully")]
        public void WhenTheUserEntersTheirEmailAndPassword()
        {
            _signInPage.LogIn("bobis@bt.com", "Password01");
        }

        [Then(@"the Home page is displayed")]
        public void ThenTheHomePageIsDisplayed()
        {
            Assert.AreEqual("Home — Conduit", _homePage.PageTitle);
        }
        
        [Then(@"the Conduit Web Page is displayed")]
        public void ThenTheConduitWebPageIsDisplayed()
        {
            Assert.AreEqual("Home — Conduit", _conduitWebpage.PageTitle);
        }
        
        [Then(@"the Error Message '(.*)' is displayed")]
        public void ThenTheErrorMessageIsDisplayed(String errorMsg)
        {
            Assert.IsTrue(_signUpPage.GetErrorMsg().Equals(errorMsg));
        }
    }
}
