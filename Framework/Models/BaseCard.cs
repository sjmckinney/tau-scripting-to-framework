using Newtonsoft.Json;

namespace Framework.Models
{
    public class BaseCard
    {
        //[JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public virtual string CardName { get; set; }

        public virtual string CardDescription { get; set; }

        //[JsonProperty("icon")]
        public string Icon { get; set; }

        //[JsonProperty("cost")]
        public long Cost { get; set; }

        //[JsonProperty("rarity")]
        public string Rarity { get; set; }

        //[JsonProperty("type")]
        public string Type { get; set; }

        //[JsonProperty("arena")]
        public long Arena { get; set; }
    }
}
