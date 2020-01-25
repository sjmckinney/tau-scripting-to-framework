using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.PageObjects;

namespace Royale.Tests
{
    public class CardTests
    {
        IWebDriver driver;
        string StatsRoyaleUrl = "https://royaleapi.com";

        [SetUp]
        public void BeforeEach()
        {
            var service = ChromeDriverService.CreateDefaultService(Path.GetFullPath("../../../../_drivers"));
            //service.LogPath = "./chromedriver.log";
            //service.EnableVerboseLogging = true;
            driver = new ChromeDriver(service);
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
            ConsentBanner consentBanner = new ConsentBanner(driver);
            Cards cards = new Cards(driver);
            consentBanner.ContinueBtn().Click();
            //Act
            var iceSpirit = cards.IceSpriteCard;
            //Assert
            Assert.That(iceSpirit.Displayed);
        }
    }
}