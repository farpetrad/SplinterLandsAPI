using Newtonsoft.Json.Linq;

namespace SplinterLands.DTOs.Models
{
    public class PlayerBattles
    {
        public string Player { get; set; } = String.Empty;
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
