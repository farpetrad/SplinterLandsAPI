using Newtonsoft.Json.Linq;

namespace SplinterLands.DTOs.Models
{
    public class BattleDetails
    {
        public string Seed { get; set; } = string.Empty;

        public List<BattleRound> Rounds { get; set; } = new List<BattleRound>();
        public Team Team1 { get; set; } = new Team();
        public Team Team2 { get; set; } = new Team();
        public JArray Pre_Battle { get; set; } = new JArray();

        public string Winner { get; set; } = string.Empty;
        public string Loser { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{{ seed: { Seed }}}";
        }
    }
}
