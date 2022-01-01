using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class Team
    {
        public string Player { get; set; } = string.Empty;
        public Int64 Rating { get; set; } = -1;
        public string Color { get; set; } = string.Empty;
        public JObject Summoner { get; set; } = new JObject();
        public List<JObject> Monsters { get; set; } = new List<JObject>();
    }
}
