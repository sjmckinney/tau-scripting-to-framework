using System.Collections.Generic;
using NUnit.Framework;
using Royale.PageObjects;
using Framework.Services;
using Framework.Selenium;
using Framework.Models;
using Framework;

namespace Royale.Tests
{
    public class CardTests
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            FW.SetConfig();
        }
        
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            BasePage.Init();
            Driver.Current.Url = $"{FW.Config.Test.Url}/cards";
            
            ConsentBanner consentBanner = new ConsentBanner(Driver.Current);
            consentBanner.ContinueBtnClick();
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        static IList<BaseCard> apiCards = new Framework.Services.ApiCardServices().GetAllCards();

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_is_displayed_on_cards_page(BaseCard baseCard)
        {       
            //Act
            var cardOnPage = BasePage.Cards.GetCardByName(baseCard.CardName);

            //Assert
            Assert.That(cardOnPage.Displayed);
        }

        static string[] cardNames = {"Ice Spirit", "Mirror"};

        [Test, Category("cards")]
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