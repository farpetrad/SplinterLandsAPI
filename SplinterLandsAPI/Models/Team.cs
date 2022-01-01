using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class Team
    {
        public string Player { get; set; } = string.Empty;
        public Int64 Rating { get; set; } = -1;
        public string Color { get; set; } = string.Empty;
        public BattleCard Summoner { get; set; } = new BattleCard();
        public List<BattleCard> Monsters { get; set; } = new List<BattleCard>();
    }
}
