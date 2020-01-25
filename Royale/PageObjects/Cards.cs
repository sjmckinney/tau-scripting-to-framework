using OpenQA.Selenium;

namespace Royale.PageObjects
{
    public class CardsPage : BasePage
    {
        IWebDriver _driver;

        public CardsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        string FormatCardName(string name)
        {
            if(name.Contains(" "))
            {
                return name.Replace(" ", "-").ToLower();
            }
            return name;
        }

        public IWebElement GetCardByName(string name)
        {
            name = FormatCardName(name);
            return _driver.FindElement(By.CssSelector($"a[href*='{name}'] > img"));
        }
    }
}