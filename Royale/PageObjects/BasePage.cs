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
            NavBar = new NavBar();
            Cards = new CardsPage();
            CardDetails = new CardDetails();
        }
    }
}