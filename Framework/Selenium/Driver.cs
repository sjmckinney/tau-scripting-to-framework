using System;
using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium;
using static NLog.LogManager;

namespace Framework.Selenium
{
    public static class Driver
    {
        private static readonly NLog.Logger logger = GetCurrentClassLogger();
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

        public static void TakeScreenshot(string imageName)
        {
            var unique = DateTime.Now.TimeOfDay;
            var screenShot = ((ITakesScreenshot)Current).GetScreenshot();
            var screenShotFileName = Path.Combine(FW.WORKSPACE_DIRECTORY + "Logs", imageName);
            screenShot.SaveAsFile($"{screenShotFileName}-{unique}.png", ScreenshotImageFormat.Png);
            logger.Info($"Took screenshot {screenShotFileName}-{unique}.png");
        }
    }
}