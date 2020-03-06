using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public class Elements : ReadOnlyCollection<IWebElement>
    {
        private readonly IList<IWebElement> _elements;
        private readonly string _name;

        public Elements(IList<IWebElement> list, string name) : base(list)
        {
            _elements = list;
            _name = name;
        }

        //public By FoundBy { get; set; }
        public bool IsEmpty => Count == 0;
    }
}
