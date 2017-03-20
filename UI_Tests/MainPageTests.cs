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
    }
}
