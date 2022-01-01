using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class BattleRound
    {
        public Int64 Num { get; set; } = -1;
        public List<BattleAction> Actions { get; set; } = new List<BattleAction>();
        public override string ToString()
        {
            return $"{{ num: { Num }, }}";
        }
    }
}
