using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.Selenium;

namespace Royale.PageObjects
{
    public class ConsentBanner
    {
        WebDriverWait _wait;

        public ConsentBanner()
        {
            _wait = new WebDriverWait(Driver.Current, new System.TimeSpan(30000));
        }
        public ReadOnlyCollection<IWebElement> BannerBtns => _wait.Until(Driver => Driver.FindElements(By.CssSelector("a.banner_continueBtn--3KNKl > span")));

        public void ContinueBtnClick()
        {
            var btn = BannerBtns[1];
            _wait.Until<bool>(Driver => btn.Enabled);
            btn.Click();
        }
    }
}
