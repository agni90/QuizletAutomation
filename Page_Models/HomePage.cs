using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Page_Models
{
    public class HomePage
    {
        private IWebDriver _driver;
        const string _buttonName = "Начать";
        const string _registrationPopupTitle = "//h3[@class='UIHeading UIHeading--three']/span[.='Зарегистрироваться']";

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string Title
        {
            get
            {
                return _driver.Title;
            }
        }

        [FindsBy(How = How.LinkText, Using = _buttonName)]
        public IWebElement BeginRegistrationButton { get; }

        [FindsBy(How = How.XPath, Using = _registrationPopupTitle)]
        public IWebElement RegistrationPopup { get; }
    }
}
