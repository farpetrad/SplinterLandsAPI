using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class PlayerBattles
    {
        public string Player { get; set; }
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
