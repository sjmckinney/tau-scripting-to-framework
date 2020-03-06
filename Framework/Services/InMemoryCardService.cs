using Framework.Models;

namespace Framework.Services
{
    public class InMemoryCardService : ICardService
    {
        public BaseCard GetCardByName(string cardName)
        {
            switch(cardName)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();
                case "Mirror":
                    return new MirrorCard();
                default:
                    throw new System.ArgumentException($"Unknown card type: {cardName}"); 
            }
        }
    }
}