using OpenQA.Selenium;
using SpecFlowScratch.Util;

namespace SpecFlowScratch.PageObjects
{
    public class SignInPage
    {
        public SignInPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver _driver { get; }

        private IWebElement Email => _driver.FindElement(By.CssSelector("div > form > fieldset > fieldset:nth-child(2) > input"));
        private IWebElement Password => _driver.FindElement(By.CssSelector("div > form > fieldset > fieldset:nth-child(3) > input"));
        private IWebElement SignInButton => _driver.FindElement(By.CssSelector("div > form > fieldset > button"));


        public void LogIn(string email, string password)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);
            SignInButton.Click();
            WaitHelper.WaitForElement(_driver, By.CssSelector(".nav-pills"), 10);
        }
    }
}
