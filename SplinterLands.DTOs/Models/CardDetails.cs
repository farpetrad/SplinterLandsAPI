using Newtonsoft.Json.Linq;
using SplinterLands.DTOs.Enums;

namespace SplinterLands.DTOs.Models
{
    public class CardDetails
    {
        public string Player { get; set; } = string.Empty;
        public string Uid { get; set; } = string.Empty;
        public Int64 Card_Detail_Id { get; set; } = -1;
        public bool Gold { get; set; } = false;
        public SetEditionEnum Edition { get; set; } = SetEditionEnum.Invalid;
        public DateTime? Last_Used_Date { get; set; } = null;
        public string? Last_Used_Player { get; set; } = string.Empty;
        public Card Details { get; set; } = new Card();
    }
}
