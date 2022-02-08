using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface IBattlesClient
    {
        PlayerBattles GetBattlesForPlayer(string playerName);
        Task<PlayerBattles> GetBattlesForPlayerAsync(string playerName);
    }
}
