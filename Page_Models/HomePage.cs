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
        const string _birth_day = "birth_day";
        const string _birth_month = "birth_month";
        const string _birth_year = "birth_year";
        const string _username = "username";
        const string _email = "//div[@class='UIInput-content']/input[@name='email']";
        const string _password = "password1";
        const string _returnPassword = "password2";
        const string _acceptCheckbox = "//span[@class='UICheckbox-fauxInput']";
        const string _signUpButtonAfterRegistration = "//button[@class='UIButton UIButton--fill UIButton--hero']";
        const string _welcomePopupTitle = "//div[@class='OnboardingContainer-title']";


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

        [FindsBy(How = How.Name, Using = _birth_day)]
        public IWebElement BirthDayField { get; set; }

        [FindsBy(How = How.Name, Using = _birth_month)]
        public IWebElement BirthMonthField { get; set; }

        [FindsBy(How = How.Name, Using = _birth_year)]
        public IWebElement BirthYearField { get; set; }

        [FindsBy(How = How.Name, Using = _username)]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.XPath, Using = _email)]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.Name, Using = _password)]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = _returnPassword)]
        public IWebElement ReturnPassword { get; set; }

        [FindsBy(How = How.XPath, Using = _acceptCheckbox)]
        public IWebElement AcceptCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = _signUpButtonAfterRegistration)]
        public IWebElement SignupButtonAfterRegitration { get; set; }

        [FindsBy(How = How.XPath, Using = _welcomePopupTitle)]
        public IWebElement WelcomePopupTitle { get; set; }  


        public void SelectBirthday(string day, string month, string year)
        {
            new SelectElement(BirthDayField).SelectByText(day);
            new SelectElement(BirthMonthField).SelectByText(month);
            new SelectElement(BirthYearField).SelectByText(year);
        }
        public void FillFieldsDuringRegistration(NewQuizletUser newUser)
        {

        }

    }
}
