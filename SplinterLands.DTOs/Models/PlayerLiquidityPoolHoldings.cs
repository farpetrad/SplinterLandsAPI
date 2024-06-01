using Newtonsoft.Json;

namespace SplinterLands.DTOs.Models
{
    public class PlayerLiquidityPoolHoldings
    {
        [JsonProperty("player")]
        public string Player { get; set; } = string.Empty;

        [JsonProperty("token")]
        public string Token { get; set; } = string.Empty;

        [JsonProperty("balance")]
        public string Balance { get; set; } = string.Empty;
    }
}
