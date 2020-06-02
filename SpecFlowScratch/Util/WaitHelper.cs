using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowScratch.Util
{
    public class WaitHelper
    {
        public static void WaitForElement(IWebDriver driver, By elementLocator, int timeToWait)
        {
            WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            waitForElement.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                ElementIsVisible(elementLocator));
        }
    }
}
