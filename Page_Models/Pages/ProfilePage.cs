using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Page_Models
{
    public class ProfilePage
    {
        private Driver _driver;
        const string _latestActivitiesTitle = "//div[@class='OnboardingContainer-title']";

        public ProfilePage(Driver driver)
        {
            _driver = driver;
            driver.InitializePageObject(this);
        }

        [FindsBy(How = How.XPath, Using = _latestActivitiesTitle)]
        public IWebElement WelcomePopupTitle { get; set; }

        public void WaitWelcomePopup()
        {
            _driver.WaitElementUntilItVisible(_latestActivitiesTitle, 5);
        }
    }
}
