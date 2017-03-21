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
        public void UserCanRegisterViaEmail()//main
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
            driver.FindElement(By.Name("username")).SendKeys("A6557test10" + Keys.Tab); Thread.Sleep(6000);
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@name='email']")).SendKeys("1517te5st0@gmail.com" + Keys.Tab); Thread.Sleep(6000);
            driver.FindElement(By.Name("password1")).SendKeys("tEST35478" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.Name("password2")).SendKeys("tEST35478" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//span[@class='UICheckbox-fauxInput']")).Click();
            driver.FindElement(By.XPath("//button[@class='UIButton UIButton--fill UIButton--hero']")).Click(); Thread.Sleep(6000);
            string welcomeTitle = (driver.FindElement(By.XPath("//div[@class='OnboardingContainer-title']"))).Text;

            Assert.AreEqual(welcomeTitle, "Добро пожаловать в Quizlet!");
            //driver.Close();
        }

        [Test]
        public void LoginFormIsActive()//main 
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            driver.FindElement(By.XPath("//button[@class='UILink UILink--inverted']/span[.='Вход']")).Click();
            string loginPageTitle = (driver.FindElement(
                By.XPath("//h3[@class='UIHeading UIHeading--three']/span[.='Вход']"))).Text;

            Assert.AreEqual(loginPageTitle, "Вход");
            driver.Close();
        }
        
        [Test]
        public void UserCanLoginWithValidEmail()//main
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            driver.FindElement(By.XPath("//button[@class='UILink UILink--inverted']/span[.='Вход']")).Click();
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@name='username']"))
                .SendKeys("A6557test10" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@name='password']"))
                .SendKeys("tEST35478" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@class='UIButton UIButton--fill UIButton--hero']")).Click(); Thread.Sleep(5000);
            string welcomeTitle = (driver.FindElement(By.XPath("//div[@class='OnboardingContainer-title']"))).Text;

            Assert.AreEqual(welcomeTitle, "Добро пожаловать в Quizlet!");
            driver.Close();
        }

        [Test]
        public void UserCanOpenCreateFirstModuleOnlyPage()//profile
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            driver.FindElement(By.XPath("//button[@class='UILink UILink--inverted']/span[.='Вход']")).Click();
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@name='username']"))
                .SendKeys("A6557test10" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@name='password']"))
                .SendKeys("tEST35478" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@class='UIButton UIButton--fill UIButton--hero']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@class='OnboardingCard-cardActionWrapper'][1]")).Click(); Thread.Sleep(3000);
            driver.FindElement(By.LinkText("Создать учебный модуль")).Click(); Thread.Sleep(8000);
            string newModuleTitle = (driver.FindElement(By.XPath("//div[@class='CreateSetHeader-title']"))).Text;

            Assert.AreEqual(newModuleTitle, "Создать новый учебный модуль");
            driver.Close();
        }

        [Test]
        //ToDo
        public void UserCanAddWordsToModule() //ProfileWindow
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://quizlet.com");
            driver.FindElement(By.XPath("//button[@class='UILink UILink--inverted']/span[.='Вход']")).Click();
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@name='username']"))
                .SendKeys("A6557test10" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@name='password']"))
                .SendKeys("tEST35478" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@class='UIButton UIButton--fill UIButton--hero']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div[@class='SiteHeader-createInner']/span[@class='SiteHeader-linkText']")).Click(); Thread.Sleep(5000);

            driver.FindElement(By.XPath("//*[@id=\"SetPageTarget\"]/div/div[1]/div[2]/div/div/label/div/div[1]/div[2]/textarea"))
                .SendKeys("BasicWords"); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@class='LanguageBarSide LanguageBarSide--word']/span[@class='LanguageBarSide-selectLanguageLink']"))
                .Click(); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@class='UIInput-content']/input[@role='combobox']"))
                .SendKeys("Английский" + Keys.Enter); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//div[@class='LanguageBarSide LanguageBarSide--def']/span[@class='LanguageBarSide-selectLanguageLink']"))
                .Click(); Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//*[@id=\"react - select - 3--value\"]/div[2]/label/div/input"))
               // .SendKeys("Русский" + Keys.Enter); Thread.Sleep(3000);

            driver.FindElement(By.XPath("//*[@id=\"SetPageTarget\"]/div/div[2]/div/div[2]/div[1]/div[1]/div[1]/div/div[3]/div[1]/div/div/div[1]/div/div/label/div/div[1]/div[2]/textarea"))
                .SendKeys("World" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"SetPageTarget\"]/div/div[2]/div/div[2]/div[1]/div[1]/div[1]/div/div[3]/div[1]/div/div/div[2]/div/div/label/div/div[1]/div[2]/textarea"))
                .SendKeys("Мир" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"SetPageTarget\"]/div/div[2]/div/div[2]/div[1]/div[1]/div[3]/div/div[3]/div[1]/div/div/div[1]/div/div/label/div/div[1]/div[2]/textarea"))
                .SendKeys("Test" + Keys.Tab); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"SetPageTarget\"]/div/div[2]/div/div[2]/div[1]/div[1]/div[3]/div/div[3]/div[1]/div/div/div[2]/div/div/label/div/div[1]/div[2]/textarea"))
                .SendKeys("Тест" + Keys.Enter); Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@class='UIButton']/span[.='Да']")).Click();
            driver.FindElement(By.XPath("//button[@class='UIButton']/span[.='Создать']")).Click(); Thread.Sleep(6000);

            string moduleTitle = (driver.FindElement(By.XPath("//h3[@class='UIHeading UIHeading--three']/span[.='Вы создали модуль']"))).Text;

            Assert.AreEqual(moduleTitle, "Вы создали модуль");
            //driver.Close();
        }
        }
}
