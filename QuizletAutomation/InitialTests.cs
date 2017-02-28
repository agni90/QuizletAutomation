using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

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

        [Test]
        public void EmailFormIsActive()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            driver.FindElement(By.LinkText("Начать")).Click();
            driver.FindElement(By.XPath("//button[@class='UILink']")).Click();
            string buttonName = (driver.FindElement(By.XPath
                ("//legend[@class='UIFieldset-legend']/span[.='Дата рождения']"))).Text;

            Assert.AreEqual(buttonName, "ДАТА РОЖДЕНИЯ");
            driver.Close();
        }

        [Test]
        public void UserCanRegisterViaEmail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            driver.FindElement(By.LinkText("Начать")).Click();
            driver.FindElement(By.XPath("//button[@class='UILink']")).Click();
            //fill all inputs
            new SelectElement(driver.FindElement(By.Name("birth_day"))).SelectByText("10");
            new SelectElement(driver.FindElement(By.Name("birth_month"))).SelectByText("февраль");
            new SelectElement(driver.FindElement(By.Name("birth_year"))).SelectByText("2001");
            driver.FindElement(By.Name("username")).SendKeys("A16557test0" + Keys.Tab); Thread.Sleep(6000);
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@name='email']")).SendKeys("1657te5st0@gmail.com" + Keys.Tab); Thread.Sleep(6000);
            driver.FindElement(By.Name("password1")).SendKeys("tEST35478" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.Name("password2")).SendKeys("tEST35478" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//span[@class='UICheckbox-fauxInput']")).Click();
            driver.FindElement(By.XPath("//button[@class='UIButton UIButton--fill UIButton--hero']")).Click(); Thread.Sleep(6000);
            string welcomeTitle = (driver.FindElement(By.XPath("//div[@class='OnboardingContainer-title']"))).Text;
            
            Assert.AreEqual(welcomeTitle, "Добро пожаловать в Quizlet!");
            driver.Close();
        }
    }
}
