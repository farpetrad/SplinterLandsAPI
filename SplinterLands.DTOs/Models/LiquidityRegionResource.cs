using Newtonsoft.Json;

namespace SplinterLands.DTOs.Models
{
    public class LiquidityRegionResource
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("region_name")]
        public string RegionName { get; set; } = string.Empty;

        [JsonProperty("region_number")]
        public long RegionNumber { get; set; }

        [JsonProperty("region_uid")]
        public string RegionUid { get; set; } = string.Empty;

        [JsonProperty("player")]
        public string Player { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("resource_symbol")]
        public string ResourceSymbol { get; set; } = string.Empty;

        [JsonProperty("created_date")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("last_updated_date")]
        public DateTimeOffset LastUpdatedDate { get; set; }
    }
}
