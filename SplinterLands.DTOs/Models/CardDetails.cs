using Newtonsoft.Json.Linq;

namespace SplinterLands.DTOs.Models
{
    public class CardDetails
    {
        public string Player { get; set; } = string.Empty;
        public string Uid { get; set; } = string.Empty;
        public Int64 Card_Detail_Id { get; set; } = -1;
        public bool Gold { get; set; } = false;
        public Int64 Edition { get; set; } = -1;
        public DateTime? Last_Used_Date { get; set; } = null;
        public string? Last_Used_Player { get; set; } = string.Empty;
        public Card Details { get; set; } = new Card();
    }
}
