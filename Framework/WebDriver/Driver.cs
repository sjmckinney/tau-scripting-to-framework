using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.WebDriver
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
    }
}