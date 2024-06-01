using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface ILiquidityClient
    {
        VnexApiResponse<LiquidityPool[]> GetLiquidityPools();
        Task<VnexApiResponse<LiquidityPool[]>> GetLiquidityPoolsAsync();
        VnexApiResponse<LiquidityRegionResource[]> GetLiquidityRegionResources(string player, string resource);
        Task<VnexApiResponse<LiquidityRegionResource[]>> GetLiquidityRegionResourcesAsync(string player, string resource);
    }
}
