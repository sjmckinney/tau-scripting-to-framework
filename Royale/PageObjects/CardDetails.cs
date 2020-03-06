using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using Framework.Selenium;

namespace Royale.PageObjects
{
    public class CardDetails : BasePage
    {
        WebDriverWait _wait;

        public CardDetails()
        {
            _wait = new WebDriverWait(Driver.Current, new System.TimeSpan(3000));
        }

        public BaseCard GetBaseCard()
        {
            var (cardName, cardDescription) = GetCardDetails(); 
            
            return new BaseCard
            {
                CardName = cardName,
                CardDescription = cardDescription
            };
        }

        public (string cardName, string cardDescription) GetCardDetails()
        {
            _wait.Until<bool>(Driver => Driver.Title.Contains("Analytics"));
            var cardName = Driver.FindElement(By.CssSelector("#page_content > div.ui.container.sidemargin0 h1"), "card name").Text.Trim();
            var cardDescription = Driver.FindElement(By.CssSelector("#page_content > div.ui.container.sidemargin0 p"), "card description").Text.Trim();
            return (cardName, cardDescription);
        }
    }
}