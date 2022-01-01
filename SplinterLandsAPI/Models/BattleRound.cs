using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class BattleRound
    {
        public Int64 Num { get; set; } = -1;
        public JArray Actions { get; set; } = new JArray();
        public override string ToString()
        {
            return $"{{ num: { Num }, }}";
        }
    }
}
