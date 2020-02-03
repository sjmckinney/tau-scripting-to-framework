using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.Selenium;

namespace Royale.PageObjects
{
    public class ConsentBanner
    {
        WebDriverWait _wait;

        public ConsentBanner(IWebDriver driver)
        {
            _wait = new WebDriverWait(Driver.Current, new System.TimeSpan(30000));
        }
        public ReadOnlyCollection<IWebElement> BannerBtns => _wait.Until(Current => Current.FindElements(By.CssSelector("a.banner_continueBtn--3KNKl > span")));

        public IWebElement ContinueBtn()
        {
            return BannerBtns[1];
        }

        public void ContinueBtnClick()
        {
            var btn = ContinueBtn();
            _wait.Until(Current => btn.Enabled);
            btn.Click();
            _wait.Until(Current => !btn.Displayed);
        }
    }
}
