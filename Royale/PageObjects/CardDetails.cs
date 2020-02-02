using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using Framework.WebDriver;

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
            _wait.Until<bool>(Current => Current.Title.Contains("Analytics"));
            var cardName = Driver.Current.FindElement(By.CssSelector("#page_content > div.ui.container.sidemargin0 h1")).Text.Trim();
            var cardDescription = Driver.Current.FindElement(By.CssSelector("#page_content > div.ui.container.sidemargin0 p")).Text.Trim();
            return (cardName, cardDescription);
        }
    }
}