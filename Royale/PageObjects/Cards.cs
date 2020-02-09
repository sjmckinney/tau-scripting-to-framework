using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.Selenium;

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
                name = name.Replace(" ", "-");
            }

            if(name.Contains("."))
            {
                name = name.Replace(".", "");
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