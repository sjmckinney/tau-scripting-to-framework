using OpenQA.Selenium;

namespace Royale.PageObjects
{
    public class NavBar
    {
        IWebDriver _driver;

        public NavBar(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}