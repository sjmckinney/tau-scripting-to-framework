using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public static void Init()
        {
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
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