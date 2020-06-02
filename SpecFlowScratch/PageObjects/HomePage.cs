using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowScratch.Util;

namespace SpecFlowScratch.PageObjects
{
    public class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebDriver _driver;

        //Page Title = "Home - Conduit"
        public string PageTitle => _driver.Title;

        private IWebElement Settings => _driver.FindElement(By.CssSelector("[ui-sref='app.settings']"));
        private IWebElement UserName => _driver.FindElement(By.CssSelector("li:nth-child(4) > a"));

        public YourSettingsPage GoToSettingsPage()
        {
            Settings.Click();
            WaitHelper.WaitForElement(_driver, By.CssSelector(".ng-valid-email"), 10);
            return new YourSettingsPage(_driver);
        }

        public string GetUser()
        {
            return UserName.Text;
        }


        protected void WaitForSettingsPage()
        {
            WebDriverWait waitForElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
            waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                ElementIsVisible(By.XPath("//*[text() = 'Or click here to logout.']")));
        }

        protected void WaitForSignUpPage()
        {
            WebDriverWait waitForElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                ElementIsVisible(By.CssSelector("div:nth-child(1) > li")));
        }



    }
}
