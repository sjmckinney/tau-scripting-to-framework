using System.Collections.Generic;
using System.Linq;
using Framework.Models;
using RestSharp;
using Newtonsoft.Json;
using static NLog.LogManager;

namespace Framework.Services
{
    public class ApiCardServices : ICardService
    {
        private static readonly NLog.Logger logger = GetCurrentClassLogger();
        public const string API_URL = "https://statsroyale.com/api/cards";

        public IList<BaseCard> GetAllCards()
        {
            var client = new RestClient(API_URL);
            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            var response = client.Execute(request);

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new System.Exception($"The request failed with status code {response.StatusCode}");
            }
            var cards = JsonConvert.DeserializeObject<IList<BaseCard>>(response.Content);
            
            return cards;
        }
        
        public BaseCard GetCardByName(string cardName)
        {
            var cards = GetAllCards();
            return cards.FirstOrDefault(card => card.CardName == cardName);
        }
    }
}