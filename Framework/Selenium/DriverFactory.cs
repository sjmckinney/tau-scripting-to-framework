using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Build(string browserName)
        {
            switch(browserName.ToLower())
            {
                case "chrome":
                    var service = ChromeDriverService.CreateDefaultService($"{FW.WORKSPACE_DIRECTORY}_drivers");
                    //service.LogPath = "./chromedriver.log";
                    //service.EnableVerboseLogging = true;
                    return new ChromeDriver(service);
                case "firefox":
                    return new FirefoxDriver();
                default:
                throw new System.ArgumentException($"{browserName} not supported.");
            }
        }
    }
}