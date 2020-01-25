using OpenQA.Selenium;

namespace Royale.PageObjects
{
    public class BasePage
    {
        public readonly NavBar NavBar;

        public BasePage(IWebDriver driver)
        {
            NavBar = new NavBar(driver);
        }
    }
}