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
        const string _signUpButton = "//button[@class='UIButton']";
        const string _signUpWithEmail = "//button[@class='UILink']";
        const string _birthdayTitle = "//legend[@class='UIFieldset-legend']/span[.='Дата рождения']";

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public string Title
        {
            get
            {
                return _driver.Title;
            }
        }

        [FindsBy(How = How.LinkText, Using = _buttonName)]
        public IWebElement GetStartedButton { get; set; }
      
        [FindsBy(How = How.XPath, Using = _registrationPopupTitle)]
        public IWebElement RegistrationPopupTitle { get; set; }

        [FindsBy(How = How.XPath, Using = _signUpButton)]
        public IWebElement SignUpButton { get; set; }

        [FindsBy(How = How.XPath, Using = _signUpWithEmail)]
        public IWebElement SignUpWithEmail { get; set; }

        [FindsBy(How = How.XPath, Using = _birthdayTitle)]
        public IWebElement GetBirthdayTitle { get; set; }

    }
}
