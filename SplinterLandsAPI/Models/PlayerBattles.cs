using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class PlayerBattles
    {
        public string Player { get; set; }
        public JArray Battles { get; set; } = new JArray();
    }
}
