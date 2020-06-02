using OpenQA.Selenium;

namespace SpecFlowScratch.PageObjects
{
    public class ConduitWebPage
    {
        public ConduitWebPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebDriver _driver { get; }

        internal void Open()
        {
            _driver.Navigate().GoToUrl("https://angularjs.realworld.io/#/");
        }

        //Page Title = "Home - Conduit"
        public string PageTitle => _driver.Title;

        public IWebElement HomeButton => _driver.FindElement(By.CssSelector("[href*='#/']"));
        public IWebElement SignInButton => _driver.FindElement(By.CssSelector("[href*='#/login']"));
        public IWebElement SignUpButton => _driver.FindElement(By.CssSelector("[href*='#/register']"));
        
        public IWebElement Logo => _driver.FindElement(By.CssSelector("div.banner > div > h1"));
        public IWebElement Banner => _driver.FindElement(By.CssSelector("div.banner > div > p"));

        public object Email { get; private set; }
        public object Password { get; private set; }

        //return SignInPage
        public void GoToSignInPage()
        {
            SignInButton.Click();
        }

        //return SignUpPage
        public void GoToSignUpPage()
        {
            SignUpButton.Click();
        }
    }
}
