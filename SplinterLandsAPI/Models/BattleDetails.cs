using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class BattleDetails
    {
        public string Seed { get; set; } = string.Empty;

        public List<BattleRound> Rounds { get; set; } = new List<BattleRound>();

        public override string ToString()
        {
            return $"{{ seed: { Seed }}}";
        }
    }
}
