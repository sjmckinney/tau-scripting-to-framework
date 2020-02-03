using System;
using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("");

        public static void Init()
        {
            var service = ChromeDriverService.CreateDefaultService(Path.GetFullPath("../../../../_drivers"));
            //service.LogPath = "./chromedriver.log";
            //service.EnableVerboseLogging = true;
            _driver = new ChromeDriver(service);
        }

        public static void Quit()
        {
            _driver.Quit();
        }

        public static IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }
    }
}