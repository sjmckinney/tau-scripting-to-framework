using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.WebDriver;

namespace Royale.PageObjects
{
    public class CardsPage : BasePage
    {
        WebDriverWait _wait;

        public CardsPage()
        {
            _wait = new WebDriverWait(Driver.Current, new System.TimeSpan(30000));
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
            return _wait.Until(Current => Current.FindElement(By.CssSelector($"a[href*='{name}'] > img")));
        }
    }
}