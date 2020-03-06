using System;
using System.Collections.ObjectModel;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using static NLog.LogManager;

namespace Framework.Selenium
{
    public class Element : IWebElement
    {
        private static readonly NLog.Logger logger = GetCurrentClassLogger();

        private readonly IWebElement _element;
        private readonly string _name;

        public IWebElement Current => _element ?? throw new System.NullReferenceException("Current IWebElement _element is null.");

        public Element(IWebElement element, string name)
        {
            _element = element;
            _name = name;
        }

        public string TagName => Current.TagName;

        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;

        public bool Selected => Current.Selected;

        public Point Location => Current.Location;

        public Size Size => Current.Size;

        public bool Displayed => Current.Displayed;

        public void Clear()
        {
            logger.Info($"Clearing contents from element: {_name}");
            Current.Clear();
        }

        public void Click()
        {
            logger.Info($"Clicking element: {_name}");
            Current.Click();
        }

        public IWebElement FindElement(By by)
        {
            logger.Info($"Finding element: {_name}");
            return Current.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            logger.Info($"Getting attribute {attributeName} from element: {_name}");
            return Current.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            logger.Info($"Getting ccs value {propertyName} from element: {_name}");
            return Current.GetCssValue(propertyName);
        }

        public string GetProperty(string propertyName)
        {
            logger.Info($"Getting propery {propertyName} from element: {_name}");
            return Current.GetProperty(propertyName);
        }

        public void Hover()
        {
            var actions = new Actions(Driver.Current);
            actions.MoveToElement(Current).Perform();
        }

        public void SendKeys(string text)
        {
            logger.Info($"Sending {text} to element: {_name}");
            Current.SendKeys(text);
        }

        public void Submit()
        {
            logger.Info($"Submitting element: {_name}");
            Current.Submit();
        }
    }
}
