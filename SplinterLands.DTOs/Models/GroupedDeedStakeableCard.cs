namespace SplinterLands.DTOs.Models
{
    public class GroupedDeedStakeableCard
    {
        public uint card_detail_id { get; set; } = 0;
        public double bcx { get; set; } = 0.0d;
        public bool gold { get; set; } = false;
        public uint edition { get; set; } = 0;
        public string card_set { get; set; } = string.Empty;
        public DateTime? last_used_date { get; set; } = null;
        public double land_base_pp { get; set; } = 0.0d;
        public double land_dec_stake_needed { get; set; } = 0.0d;
        public string name { get; set; } = string.Empty;
        public string color { get; set; } = string.Empty;
        public uint rarity { get; set; } = 0;
        public uint tier { get; set; } = 0;
        public string terrain_boost_pp { get;set; } = string.Empty;
        public string terrain_boost { get; set; } = string.Empty;
        public string land_base_pp_with_terrain_boost { get;set; } = string.Empty;
        public string work_per_hour { get; set; } = string.Empty;
        public uint card_count { get; set; } = 0;
    }
}
