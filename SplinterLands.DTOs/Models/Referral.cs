namespace SplinterLands.DTOs.Models
{
    public class Referral
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? Join_Date { get; set; } = null;
        public bool Starter_Pack_Purchase { get; set; } = false;
        public int Rating { get; set; } = -1;
        public int Battles { get; set; } = -1;
        public int Avatar_Id { get; set; } = -1;
        public string? Display_Name { get; set; } = null;
        public string? Title_Pre { get; set; } = null;
        public string? Title_Post { get; set; } = null;
        public int League { get; set; } = -1;
    }
}
