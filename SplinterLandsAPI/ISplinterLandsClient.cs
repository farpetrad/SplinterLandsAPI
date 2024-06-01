using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface ISplinterLandsClient : IBattlesClient, ICardsClient, IPlayerClient, ILandClient, ILogin, ILiquidityClient
    {
        
    }
}
