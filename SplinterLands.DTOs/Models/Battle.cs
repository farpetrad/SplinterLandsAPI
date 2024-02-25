

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SplinterLands.DTOs.Models
{
    public class Battle
    {
        public string Battle_queue_id_1 { get; set; } = string.Empty;
        public string Battle_queue_id_2 { get; set; } = string.Empty;
        public string Player_1 { get; set; } = string.Empty;
        public string Player_2 { get; set; } = string.Empty;
        public string Winner { get; set; } = string.Empty;
        public int Player_1_rating_initial { get; set; } = -1;
        public int Player_2_rating_initial { get; set; } = -1;
        public int Player_1_rating_final { get; set; } = -1;
        public int Player_2_rating_final { get; set; } = -1;
        public Details Details { get; set; } = new Details();
        public DateTime? Created_Date { get; set; } = null;
        public string Match_Type { get;set; } = string.Empty;
        public int Mana_Cap { get; set; } = -1;
        public int Current_Streak { get; set; } = -1;
        public string Ruleset { get; set; } = string.Empty;
        public string Inactive { get; set; } = string.Empty;
        public string Settings
        {
            get => BattleSettings == null ? "" : BattleSettings.ToString();
            set => BattleSettings = value != null ? (JsonConvert.DeserializeObject<BattleSettings>(value)) ?? new BattleSettings() 
                : new BattleSettings();
        }
        public BattleSettings BattleSettings { get; set; } = new BattleSettings();
        public Int64 Block_Num { get; set; } = -1;
        public Int64 Rshares { get; set; } = -1;
        public JValue? Dec_Info { get; set; } = null;
        public Int64 Leaderboard { get; set; } = -1;
        public string Reward_Dec { get; set; } = string.Empty;
        public string? Reward_Sps { get; set; } = string.Empty;
    }
}
