using System;
using System.IO;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        public static Element FindElement(By by, string elementName)
        {
            return new Element(Current.FindElement(by), elementName);
        }

        public static Elements FindElements(By by, string elementsName)
        {
            return new Elements(_driver.FindElements(by), elementsName);
        }

        public static void TakeScreenshot(string imageName)
        {
            var unique = DateTime.Now.TimeOfDay.ToString().Replace(":", "");
            var screenShot = ((ITakesScreenshot)Current).GetScreenshot();
            var screenShotFileName = Path.Combine(FW.WORKSPACE_DIRECTORY + "Logs", imageName);
            screenShot.SaveAsFile($"{screenShotFileName}-{unique}.png", ScreenshotImageFormat.Png);
            logger.Info($"Took screenshot {screenShotFileName}-{unique}.png");
        }
    }
}