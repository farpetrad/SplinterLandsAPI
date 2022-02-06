using SplinterLands.DTOs.Enums;

namespace SplinterLands.DTOs.Models
{
    public class EditionPackPurchases
    {
        public SetEditionEnum Edition { get; set; } = SetEditionEnum.Alpha;
        public string Player { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
        public int Packs { get; set; } = 0;
        public int Bonus_Packs { get; set; } = 0;
    }
}
