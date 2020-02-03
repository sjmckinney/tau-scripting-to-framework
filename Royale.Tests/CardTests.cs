using NUnit.Framework;
using Royale.PageObjects;
using Framework.Services;
using Framework.Selenium;

namespace Royale.Tests
{
    public class CardTests
    {
        string StatsRoyaleUrl = "https://royaleapi.com";

        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            BasePage.Init();
            Driver.Current.Url = $"{StatsRoyaleUrl}/cards";

            ConsentBanner consentBanner = new ConsentBanner(Driver.Current);
            consentBanner.ContinueBtnClick();
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        [Test, Category("cards")]
        public void Ice_spirit_card_is_on_cards_page()
        {       
            //Act
            var iceSpirit = BasePage.Cards.GetCardByName("Ice Spirit");

            //Assert
            Assert.That(iceSpirit.Displayed);
        }

        static string[] cardNames = {"Ice Spirit", "Mirror"};

        [Test, Category("Cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_details_are_correct_on_card_details_page(string cardName)
        {
            //Arrange
            BasePage.Cards.GetCardByName(cardName).Click();
            
            //Act
            var card = new InMemoryCardService().GetCardByName(cardName);
            var cardOnPage = BasePage.CardDetails.GetBaseCard();

            //Assert
            Assert.AreEqual(card.CardName, cardOnPage.CardName);
            Assert.AreEqual(card.CardDescription, cardOnPage.CardDescription);
        }
    }
}