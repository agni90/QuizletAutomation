using NUnit.Framework;
using Page_Models;

namespace QuizletAutomation
{
    public class BaseTest
    {
        protected Driver _chromeDriver;

        [SetUp]
        public void InitializeDriver()
        {
            _chromeDriver = new Driver();
            _chromeDriver.Initialize();
            _chromeDriver.Navigate("https://quizlet.com");
        }

        [TearDown]
        public void CloseDriver()
        {
            _chromeDriver.Quit();
        }

    }
}
