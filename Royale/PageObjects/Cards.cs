using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Royale.PageObjects
{
    public class CardsPage : BasePage
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        public CardsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new System.TimeSpan(30000));
        }

        string FormatCardName(string name)
        {
            if(name.Contains(" "))
            {
                return name.Replace(" ", "-").ToLower();
            }
            return name.ToLower();
        }

        public IWebElement GetCardByName(string name)
        {
            name = FormatCardName(name);
            return _wait.Until(_driver => _driver.FindElement(By.CssSelector($"a[href*='{name}'] > img")));
        }
    }
}