using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuizletAutomation
{
    public class BaseTest
    {
        protected IWebDriver _chromeDriver;

        [SetUp]
        public void InitializeDriver()
        {
            _chromeDriver = new ChromeDriver();
            _chromeDriver.Navigate().GoToUrl("https://quizlet.com");
            _chromeDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseDriver()
        {
            _chromeDriver.Quit();
        }
    }
}
