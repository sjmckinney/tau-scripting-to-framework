using OpenQA.Selenium;

namespace Royale.PageObjects
{
    public class Cards{

        IWebDriver _driver;

        public Cards(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement IceSpriteCard => _driver.FindElement(By.CssSelector("a[href*='ice-spirit']"));

    }
}