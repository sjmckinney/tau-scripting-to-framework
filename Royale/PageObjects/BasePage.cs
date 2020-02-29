using System;
using static NLog.LogManager;

namespace Royale.PageObjects
{
    public class BasePage
    {
        private static readonly NLog.Logger logger = GetCurrentClassLogger();

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
            logger.Info("Compeleted BasePage.Init()");
        }
    }
}