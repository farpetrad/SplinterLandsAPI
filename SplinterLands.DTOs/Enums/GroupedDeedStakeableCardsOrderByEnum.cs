using System.ComponentModel;

namespace SplinterLands.DTOs.Enums
{
    public enum GroupedDeedStakeableCardsOrderByEnum
    {
        [Description("land_deed_pp")]
        land_deed_pp = 1,
        [Description("land_dec_stake_needed")]
        land_dec_stake_needed = 2,
        [Description("tier")]
        tier = 3,
        [Description("card_count")]
        card_count = 4,
        [Description("name")]
        name = 5,
        [Description("bcx")]
        bcx = 6,
        [Description("gold")]
        gold = 7,
        [Description("edition")]
        edition = 8,
        [Description("color")]
        color = 9,
        [Description("rarity")]
        rarity = 10,
        [Description("land_adjusted_pp")]
        land_adjusted_pp = 11,
        [Description("land_work_per_hour")]
        land_work_per_hour = 12,
        [Description("last_used_date")]
        last_used_date = 13,
    }
}
