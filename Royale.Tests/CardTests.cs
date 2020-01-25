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
            driver.Url = $"{StatsRoyaleUrl}/cards";

            ConsentBanner consentBanner = new ConsentBanner(driver);
            consentBanner.ContinueBtn().Click();
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
            CardsPage cards = new CardsPage(driver);
            
            //Act
            var iceSpirit = cards.GetCardByName("Ice spirit");

            //Assert
            Assert.That(iceSpirit.Displayed);
        }

        [Test]
        public void Ice_spirit_card_details_are_correct()
        {
            //Arrange
            CardDetails cardDetails = new CardDetails(driver);
            new CardsPage(driver).GetCardByName("Ice spirit").Click();
            
            //Act
            var (cardName, cardDescription) = cardDetails.GetCardName();
            
            //Assert
            Assert.AreEqual("Ice Spirit", cardName);
            Assert.AreEqual("Spawns one lively little Ice Spirit to freeze a group of enemies. Stay frosty.", cardDescription);
        }
    }
}