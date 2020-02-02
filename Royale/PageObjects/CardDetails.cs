using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.Models;

namespace Royale.PageObjects
{
    public class CardDetails : BasePage
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        public CardDetails(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new System.TimeSpan(3000));
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
            _wait.Until<bool>(_driver => _driver.Title.Contains("Analytics"));
            var cardName = _driver.FindElement(By.CssSelector("#page_content > div.ui.container.sidemargin0 h1")).Text.Trim();
            var cardDescription = _driver.FindElement(By.CssSelector("#page_content > div.ui.container.sidemargin0 p")).Text.Trim();
            return (cardName, cardDescription);
        }
    }
}