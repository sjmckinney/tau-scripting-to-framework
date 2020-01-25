using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.PageObjects;
using Framework.Models;
using Framework.Services;

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

        static string[] cardNames = {"Ice Spirit", "Mirror"};

        [TestCaseSource("cardNames")]
        public void Card_details_are_correct_on_card_details_page(string cardName)
        {
            //Arrange
            CardDetails cardDetails = new CardDetails(driver);
            new CardsPage(driver).GetCardByName(cardName).Click();
            
            //Act
            var card = new InMemoryCardService().GetCardByName(cardName);
            var cardOnPage = cardDetails.GetBaseCard();

            //Assert
            Assert.AreEqual(card.CardName, cardOnPage.CardName);
            Assert.AreEqual(card.CardDescription, cardOnPage.CardDescription);
        }
    }
}