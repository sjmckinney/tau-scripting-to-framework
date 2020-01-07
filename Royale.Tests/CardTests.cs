using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;
        WebDriverWait wait;
        string StatsRoyaleUrl = "https://royaleapi.com";

        [SetUp]
        public void BeforeEach()
        {
            var service = ChromeDriverService.CreateDefaultService(Path.GetFullPath("../../../../_drivers"));
            //service.LogPath = "./chromedriver.log";
            //service.EnableVerboseLogging = true;
            driver = new ChromeDriver(service);
            wait = new WebDriverWait(driver, new System.TimeSpan(30000));

        }

        [TearDown]
        public void AfterEach()
        {
            driver.Quit();
        }

        [Test]
        public void Ice_spirit_card_is_on_cards_page()
        {
            //Arrange
            driver.Url = $"{StatsRoyaleUrl}/cards";
            IWebElement el = wait.Until(driver => driver.FindElements(By.CssSelector("a.banner_continueBtn--3KNKl > span"))[1]);
            el.Click();
            //Act
            var iceSpirit = driver.FindElement(By.CssSelector("a[href*='ice-spirit']"));
            //Assert
            Assert.That(iceSpirit.Displayed);
        }
    }
}