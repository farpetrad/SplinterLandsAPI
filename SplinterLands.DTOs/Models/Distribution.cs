using SplinterLands.DTOs.Enums;

namespace SplinterLands.DTOs.Models
{
    public class Distribution
    {
        public int Card_Detail_Id { get; set; } = -1;
        public bool Gold { get; set; } = false;
        public SetEditionEnum Edition { get; set; } = SetEditionEnum.Invalid;
        public int Num_Cards { get; set; } = -1;
        public int Total_Xp { get; set; } = -1;
        public int Num_Burned { get; set; } = -1;
        public int Total_Burned_Xp { get; set; } = -1;
    }
}
