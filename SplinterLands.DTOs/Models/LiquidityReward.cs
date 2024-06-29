namespace SplinterLands.DTOs.Models
{
    public class LiquidityReward
    {
        public uint liquidity_pool_id { get; set; } = 0;

        public double reward_total { get; set; } = 0.0d;

        public string token { get; set; } = string.Empty;
    }
}
