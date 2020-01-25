using Framework.Models;

namespace Framework.Services
{
    public interface ICardService
    {
        BaseCard GetCardByName(string cardName);
    }
}