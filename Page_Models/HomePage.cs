using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Page_Models
{
    public class HomePage
    {
        private Driver _driver;
        const string _buttonName = "Начать";
        const string _registrationPopupTitle = "//h3[@class='UIHeading UIHeading--three']/span[.='Зарегистрироваться']";
        const string _signUpButton = "//button[@class='UIButton']";
        const string _signUpWithEmail = "//button[@class='UILink']";
        const string _birthdayTitle = "//legend[@class='UIFieldset-legend']/span[.='Дата рождения']";
        const string _welcomePopupTitle = "//div[@class='OnboardingContainer-title']";

        public HomePage(Driver driver)
        {
            _driver = driver;
            driver.InitializePageObject(this);
        }

        public string Title
        {
            get
            {
                return _driver.GetTitle();
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

        [FindsBy(How = How.XPath, Using = _welcomePopupTitle)]
        public IWebElement WelcomePopupTitle { get; set; }

        public void WaitWelcomePopup()
        {
            _driver.WaitElementUntilItVisible(_welcomePopupTitle, 5);
        }
    }
}
