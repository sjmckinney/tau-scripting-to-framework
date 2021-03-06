﻿using System;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public sealed class WaitConditions
    {
        public static Func<IWebDriver, bool> ElementDisplayed(IWebElement element)
        {
            bool condition(IWebDriver driver) => element.Displayed;
            return condition;
        }
    }
}
