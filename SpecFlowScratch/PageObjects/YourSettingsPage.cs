using OpenQA.Selenium;

namespace SpecFlowScratch.PageObjects
{
    public class YourSettingsPage
    {
        public YourSettingsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver _driver { get; }

        public IWebElement LogOutButton => _driver.FindElement(By.CssSelector(".btn-outline-danger"));

        public void ClickLogOutButton()
        {
            LogOutButton.Click();
        }
    }
}
