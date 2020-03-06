using System.Collections.Generic;
using NUnit.Framework;
using Framework.Services;
using Framework.Models;
using Royale.PageObjects;
using Royale.Tests.Base;

namespace Royale.Tests
{
    public class CardTests : TestBase
    {
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

        static string[] cardNames = {"Ice Spirit", "Mirror1"};

        [Test, Category("cards1")]
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