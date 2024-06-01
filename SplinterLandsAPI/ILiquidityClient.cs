using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface ILiquidityClient
    {
        VnexApiResponse<LiquidityPool[]> GetLiquidityPools();
        Task<VnexApiResponse<LiquidityPool[]>> GetLiquidityPoolsAsync();
        VnexApiResponse<LiquidityRegionResource[]> GetLiquidityRegionResources(string player, string resource);
        Task<VnexApiResponse<LiquidityRegionResource[]>> GetLiquidityRegionResourcesAsync(string player, string resource);
        VnexApiResponse<PlayerLiquidityPoolHoldings[]> GetPlayerLiquidityHoldings(string player, string resource);
        Task<VnexApiResponse<PlayerLiquidityPoolHoldings[]>> GetPlayerLiquidityHoldingsAsync(string player, string resource);
        VnexApiResponse<LiquidityPool> GetLiquidityPoolById(uint id);
        Task<VnexApiResponse<LiquidityPool>> GetLiquidityPoolByIdAsync(uint id);
    }
}
