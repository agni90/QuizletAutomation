using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Page_Models.Pages
{
    public class LoginPopup
    {
        private Driver _driver;
        const string _loginPopupTitle = "//h3[@class='UIHeading UIHeading--three']/span[.='Вход']";
        const string _username = "//div[@class='UIInput-content']/input[@name='username']";
        const string _password = "//div[@class='UIInput-content']/input[@name='password']";
        const string _submitButton = "//button[@class='UIButton UIButton--fill UIButton--hero']";

        public LoginPopup(Driver driver)
        {
            _driver = driver;
            driver.InitializePageObject(this);
        }

        [FindsBy(How = How.XPath, Using = _loginPopupTitle)]
        public IWebElement LoginPopupTitle { get; set; }

        [FindsBy(How = How.XPath, Using = _username)]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.XPath, Using = _password)]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = _submitButton)]
        public IWebElement SubmitButton { get; set; }

        public void EnterCredentials(string username, string password)
        {
            Username.SendKeys(username + Keys.Tab);
            Password.SendKeys(password + Keys.Tab);
        }
        public void SubmitLogin()
        {
            SubmitButton.Click();
        }
    }
}
