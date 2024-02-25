using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SplinterLands.DTOs.Models
{
    public partial class Details
    {
        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("loser", NullValueHandling = NullValueHandling.Ignore)]
        public string Loser { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("team1")]
        public Team Team1 { get; set; }

        [JsonProperty("team2", NullValueHandling = NullValueHandling.Ignore)]
        public Team Team2 { get; set; }

        [JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
        public string Seed { get; set; }
    }
}
