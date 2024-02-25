using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLands.DTOs.Models
{
    public class LandDeedDetails
    {
        public string map_name { get; set; } = string.Empty;
        public uint region_id { get; set; } = 0;
        public uint tract_id { get; set; } = 0;
        public uint plot_id { get; set; } = 0;
        public uint region_number { get; set; } = 0;
        public uint tract_number { get; set; } = 0;
        public uint plot_number { get; set; } = 0;
        public string territory { get; set; } = string.Empty;
        public string region_uid { get; set; } = string.Empty;
        public int resource_id { get; set; } = 0;
        public string resource_symbol { get; set; } = string.Empty;
        public string magic_type { get; set; } = string.Empty;
        public string stats { get; set; } = string.Empty;
        public string deed_uid { get; set; } = string.Empty;
        public string player { get; set; } = string.Empty;
        public DateTime created_date { get; set; } = new DateTime();
        public bool listed { get; set; } = false;
        public uint? lock_days { get; set; } = null;
        public DateTime? unlock_date { get; set; } = null;
        public bool in_use { get; set; } = false;
        public string deed_type { get; set; } = string.Empty;
        public string land_stats { get; set; } = string.Empty;
        public string region_name { get; set; } = string.Empty;
        public DateTime? market_updated_date { get; set; } = null;
        public uint? market_id { get; set; } = null;
        public double? listing_price { get; set; } = null;
        public uint? market_listing_id { get; set; } = null;
        public uint? market_listing_status_id { get; set; } = null;
        public uint? castle { get; set; } = null;
        public uint? keep { get; set; } = null;
        public string rarity { get; set; } = string.Empty;
        public string plot_status { get; set; } = string.Empty;
        public string hex_code { get; set; } = string.Empty;
        public double tax_rate { get; set; } = 0.0d;
        public uint item_detail_id { get; set; } = 0;
        public uint created_block_num { get; set; } = 0;
        public string created_tx { get; set; } = string.Empty;
        public string worksite_type { get; set; } = string.Empty;
        public uint time_crystal_value { get; set; } = 0;
        public uint rarity_sort_value { get; set; } = 0;
        public bool is_construction { get; set; } = false;
    }
}
