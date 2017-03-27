using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Page_Models
{
    public class Driver
    {
        private IWebDriver ChromeDriver;

        public void Initialize()
        {
            ChromeDriver = new ChromeDriver();
            ChromeDriver.Manage().Window.Maximize();
        }

        public void Navigate(string url)
        {
            ChromeDriver.Navigate().GoToUrl(url);
        }

        public void InitializePageObject(object page)
        {
            PageFactory.InitElements(ChromeDriver, page);
        }

        public string GetTitle()
        {
            return ChromeDriver.Title;
        }

        public void Quit()
        {
            ChromeDriver.Quit();
        }

        public void WaitElementUntilItVisible(string xpath, int seconds)
        {
            if (ChromeDriver != null)
            {
                var sleep = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(seconds));
                sleep.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
            }
        }

        public void WaitElementUntilTextChanged(string xpath, int seconds)
        {
            if (ChromeDriver != null)
            {
                var sleep = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(seconds));
                sleep.Until(ExpectedConditions.InvisibilityOfElementWithText(By.XPath(xpath), "New Wrestler"));
            }
        }
    }
}
