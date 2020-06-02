using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowScratch.PageObjects;
using BoDi;
using TechTalk.SpecFlow;


namespace SpecFlowScratch.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public IWebDriver _driver;

        ConduitWebPage _conduitWebpage;

        private readonly IObjectContainer objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        /// <summary>
        /// This denotes the beginning of all your tests
        /// the Sign in page is the beginning
        /// </summary>
        [BeforeScenario]
        public void StartDriver()
        {
            _driver = new ChromeDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            _driver.Manage().Window.Maximize();
            _conduitWebpage = new ConduitWebPage(_driver);
            _conduitWebpage.Open();
            _conduitWebpage.GoToSignInPage();
        }


        [AfterScenario()]
        public void CloseBrowser()
        {
            _driver?.Quit();
        }

    }
}
