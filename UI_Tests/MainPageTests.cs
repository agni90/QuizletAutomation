using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Page_Models;

namespace QuizletAutomation
{
    [TestFixture]
    public class MainPageTests : BaseTest
    {
        [Test]
        public void Given_home_page_When_is_loaded_Then_verify_title()
        {
            HomePage homePage = new HomePage( _chromeDriver);
            Assert.AreEqual(homePage.Title, "Учебные средства и карточки – совершенно бесплатно | Quizlet");
        }

        [Test]
        public void Given_home_page_When_click_getStarted_button_Then_signUp_popup_is_shown()
        {
            HomePage homePage = new HomePage(_chromeDriver);
            homePage.GetStartedButton.Click();
            Assert.AreEqual(homePage.RegistrationPopupTitle.Text, "Зарегистрироваться");
        }

        [Test]
        public void Given_home_page_When_click_signUp_button_Then_signUp_popup_is_shown()
        {
            HomePage homePage = new HomePage(_chromeDriver);
            homePage.SignUpButton.Click();
            Assert.AreEqual(homePage.RegistrationPopupTitle.Text, "Зарегистрироваться");
        }

        [Test]
        public void Given_home_page_When_click_getStarted_button_and_signUp_via_email_Then_signUp_popup_is_shown()
        {
            HomePage homePage = new HomePage(_chromeDriver);
            homePage.GetStartedButton.Click();
            homePage.SignUpWithEmail.Click();
            Assert.AreEqual(homePage.GetBirthdayTitle.Text, "ДАТА РОЖДЕНИЯ");
        }

        [Test]
        public void Given__When__Then()
        {
            HomePage homePage = new HomePage(_chromeDriver);
            homePage.GetStartedButton.Click();
            homePage.SignUpWithEmail.Click();
            homePage.SelectBirthday("10", "февраль", "2001");

        }
    }
}
