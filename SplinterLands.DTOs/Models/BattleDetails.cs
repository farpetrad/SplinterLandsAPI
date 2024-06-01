using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SplinterLands.DTOs.Models
{
    public partial class Details
    {
        [JsonProperty("winner")]
        public string Winner { get; set; } = string.Empty;

        [JsonProperty("loser", NullValueHandling = NullValueHandling.Ignore)]
        public string Loser { get; set; } = string.Empty;

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("team1")]
        public Team? Team1 { get; set; } = null;

        [JsonProperty("team2", NullValueHandling = NullValueHandling.Ignore)]
        public Team? Team2 { get; set; } = null;

        [JsonProperty("seed", NullValueHandling = NullValueHandling.Ignore)]
        public string Seed { get; set; } = string.Empty;
    }
}
