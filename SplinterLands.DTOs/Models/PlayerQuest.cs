using Newtonsoft.Json;
using SplinterLands.DTOs.Enums;

namespace SplinterLands.DTOs.Models
{
    public class PlayerQuest
    {
        public string Id { get; set; } = string.Empty;
        public string Player { get; set; } = string.Empty;
        public DateTime Created_Date { get; set; } = DateTime.Now;
        public Int64 Created_Block { get; set; } = -1;
        public string Name { get; set; } = string.Empty;
        public int Total_Items { get; set; } = -1;
        public int Completed_Items { get; set; } = -1;
        public string Claim_Trx_Id { get; set; } = string.Empty;
        public DateTime? Claim_Date { get; set; } = null;
        public int Reward_Qty { get; set; } = -1;
        public string Refresh_Trx_Id { get; set; } = string.Empty;
        public List<Reward> QuestRewards { get; set; } = new List<Reward>();
        public string Rewards {
            get => string.Join(",", QuestRewards.Select(r => r.ToString())); 
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    QuestRewards = JsonConvert.DeserializeObject<List<Reward>>(value) ?? new List<Reward>();
                }
            }
        }
        public LeagueEnum League { get; set; } = LeagueEnum.Unknown;
    }
}
