using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Page_Models
{
    public class RegisterNewUserPopup
    {
        private Driver _driver;
        const string _birth_day = "birth_day";
        const string _birth_month = "birth_month";
        const string _birth_year = "birth_year";
        const string _username = "username";
        const string _email = "//div[@class='UIInput-content']/input[@name='email']";
        const string _password = "password1";
        const string _returnPassword = "password2";
        const string _acceptCheckbox = "//span[@class='UICheckbox-fauxInput']";
        const string _signUpButtonAfterRegistration = "//button[@class='UIButton UIButton--fill UIButton--hero']";
        
        public RegisterNewUserPopup(Driver driver)
        {
            _driver = driver;
            driver.InitializePageObject(this);
        }

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

        
        public void SelectBirthday(string day, string month, string year)
        {
            new SelectElement(BirthDayField).SelectByText(day);
            new SelectElement(BirthMonthField).SelectByText(month);
            new SelectElement(BirthYearField).SelectByText(year);
        }
        public void FillFieldsDuringRegistration(NewQuizletUser newUser)
        {
            Username.SendKeys(newUser.Username + Keys.Tab);
            Email.SendKeys(newUser.Email + Keys.Tab);
            Password.SendKeys(newUser.Password + Keys.Tab);
            ReturnPassword.SendKeys(newUser.RetypePassword + Keys.Tab);
            AcceptCheckbox.Click();            
        }
        public void SubmitNewUserCreation()
        {
            SignupButtonAfterRegitration.Click();
        }

    }
}
