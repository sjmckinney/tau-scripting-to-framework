using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Royale.PageObjects
{
    public class ConsentBanner
    {
        IWebDriver _driver;
        WebDriverWait _wait;

        public ConsentBanner(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, new System.TimeSpan(30000));
        }
        public ReadOnlyCollection<IWebElement> BannerBtns => _wait.Until(_driver => _driver.FindElements(By.CssSelector("a.banner_continueBtn--3KNKl > span")));
        public IWebElement ContinueBtn(){
            return BannerBtns[1];
        }
    }
}
