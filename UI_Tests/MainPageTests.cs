using NUnit.Framework;
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
        public void Given_register_new_user_via_email_When_fill_required_fields_and_submit_Then_new_user_was_created()
        {
            HomePage homePage = new HomePage(_chromeDriver);
            RegisterNewUserPopup registrationPage = new RegisterNewUserPopup(_chromeDriver);
            var newUser = new NewQuizletUser
            {
                Username = "12NewUser",
                Email = "12newUser@gmail.com",
                Password = "1234qweRty/",
                RetypePassword = "1234qweRty/"
            };

            homePage.GetStartedButton.Click();
            homePage.SignUpWithEmail.Click();
            registrationPage.SelectBirthday("10", "февраль", "2001");
            registrationPage.FillFieldsDuringRegistration(newUser);
            registrationPage.SubmitNewUserCreation();
            Assert.AreEqual(homePage.WelcomePopupTitle.Text, "Добро пожаловать в Quizlet!");            
        }
    }
}
