using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface ILiquidityClient
    {
        VnexApiResponse<LiquidityPool[]> GetLiquidityPools();
        Task<VnexApiResponse<LiquidityPool[]>> GetLiquidityPoolsAsync();
    }
}
