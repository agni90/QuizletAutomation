using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QuizletAutomation
{
    [TestFixture]
    public class InitialTests
    {
        [Test]
        public void NavigateToMainPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            string title = (driver.Title).ToString();

            Assert.AreEqual(title, "Учебные средства и карточки – совершенно бесплатно | Quizlet");
            driver.Close();
        }

        [Test]
        public void RegistrationViaBeginButtonIsOpened()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            driver.FindElement(By.LinkText("Начать")).Click();
            string title = (driver.FindElement(By.XPath
                ("//h3[@class='UIHeading UIHeading--three']/span[.='Зарегистрироваться']"))).Text;

            Assert.AreEqual(title, "Зарегистрироваться");
            driver.Close();
        }

        [Test]
        public void RegistrationViaRegisterButtonIsOpened()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            driver.FindElement(By.XPath("//button[@class='UIButton']")).Click();
            string title = (driver.FindElement(By.XPath
                ("//h3[@class='UIHeading UIHeading--three']/span[.='Зарегистрироваться']"))).Text;

            Assert.AreEqual(title, "Зарегистрироваться");
            driver.Close();
        }
    }
}
