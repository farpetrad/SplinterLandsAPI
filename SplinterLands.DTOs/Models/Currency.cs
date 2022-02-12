namespace SplinterLands.DTOs.Models
{
    public class Currency
    {
        public string Player { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public double Balance { get; set; } = 0.0d;
        public Int64? Last_Reward_Block { get; set; } = null;
        public DateTime? Last_Reward_Time { get; set; } = null;
    }
}
