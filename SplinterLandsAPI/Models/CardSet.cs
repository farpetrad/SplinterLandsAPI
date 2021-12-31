using Newtonsoft.Json.Linq;

namespace SplinterLandsAPI.Models
{
    public class CardSet
    {
        public List<Card> SetCollection { get; set; } = new List<Card>();
    }
}
