using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class BattleDetails
    {
        public string Seed { get; set; } = string.Empty;

        public List<BattleRound> Rounds { get; set; } = new List<BattleRound>();
        public JObject Team1 { get; set; } = new JObject();
        public JObject Team2 { get; set; } = new JObject();
        public JArray Pre_Battle { get; set; } = new JArray();

        public string Winner { get; set; } = string.Empty;
        public string Loser { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{{ seed: { Seed }}}";
        }
    }
}
