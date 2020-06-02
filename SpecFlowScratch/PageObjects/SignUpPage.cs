using OpenQA.Selenium;
using SpecFlowScratch.Util;

namespace SpecFlowScratch.PageObjects
{
    public class SignUpPage
    {
        public SignUpPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver _driver { get; }

        //Page Title = "Sign up — Conduit"
        public string PageTitle => _driver.Title;

        public IWebElement Username => _driver.FindElement(By.CssSelector("div > form > fieldset > fieldset:nth-child(1) > input"));
        public IWebElement Email => _driver.FindElement(By.CssSelector("div > form > fieldset > fieldset:nth-child(2) > input"));
        public IWebElement Password => _driver.FindElement(By.CssSelector("div > form > fieldset > fieldset:nth-child(3) > input"));
        public IWebElement SignUpButton => _driver.FindElement(By.CssSelector("div > form > fieldset > button"));

        //Error Message
        public IWebElement Errormsg => _driver.FindElement(By.CssSelector(".error-messages li"));

        public void FillSignUpPage(string username, string email, string password)
        {
            Username.SendKeys(username);
            Email.SendKeys(email);
            Password.SendKeys(password);
            SignUpButton.Click();
            WaitHelper.WaitForElement(_driver, By.CssSelector(".error-messages"), 7);
        }


        internal string GetErrorMsg()
        {
            return Errormsg.Text;
        }
    }
}
