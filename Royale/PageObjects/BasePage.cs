using System;
using Framework.WebDriver;

namespace Royale.PageObjects
{
    public class BasePage
    {
        [ThreadStatic]
        public static NavBar NavBar;

        [ThreadStatic]
        public static CardsPage Cards;

        [ThreadStatic]
        public static CardDetails CardDetails;

        public static void Init()
        {
            NavBar = new NavBar(Driver.Current);
            Cards = new CardsPage(Driver.Current);
            CardDetails = new CardDetails(Driver.Current);
        }
    }
}