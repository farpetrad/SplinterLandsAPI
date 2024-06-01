using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLands.DTOs.Models
{
    public class LiquidityPool
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("token_symbol")]
        public string TokenSymbol { get; set; }

        [JsonProperty("resource_quantity")]
        public string ResourceQuantity { get; set; }

        [JsonProperty("resource_volume")]
        public double ResourceVolume { get; set; }

        [JsonProperty("resource_volume_1")]
        public double ResourceVolume1 { get; set; }

        [JsonProperty("resource_volume_30")]
        public double ResourceVolume30 { get; set; }

        [JsonProperty("resource_price")]
        public double ResourcePrice { get; set; }

        [JsonProperty("dec_quantity")]
        public string DecQuantity { get; set; }

        [JsonProperty("dec_volume")]
        public double DecVolume { get; set; }

        [JsonProperty("dec_volume_1")]
        public double DecVolume1 { get; set; }

        [JsonProperty("dec_volume_30")]
        public double DecVolume30 { get; set; }

        [JsonProperty("dec_price")]
        public double DecPrice { get; set; }

        [JsonProperty("total_shares")]
        public string TotalShares { get; set; }

        [JsonProperty("created_date")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("last_updated_date")]
        public DateTimeOffset LastUpdatedDate { get; set; }
    }
}
