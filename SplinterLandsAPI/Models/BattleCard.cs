using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class BattleCard
    {
        public string Uid { get; set; } = string.Empty;
        public int Xp { get; set; } = -1;
        public bool Gold { get; set; } = false;
        public Int64 Card_Detail_Id { get; set; } = -1;
        public int Level { get; set; } = -1;
        public int Edition { get; set; } = -1;
        public string? Skin { get; set; } = null;
        public JObject State { get; set; } = new JObject();
        
    }
}
