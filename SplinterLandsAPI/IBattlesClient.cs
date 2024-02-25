using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface IBattlesClient
    {
        PlayerBattles GetBattlesForPlayer(string playerName, int leaderboard, string format, string token, string username);
        Task<PlayerBattles> GetBattlesForPlayerAsync(string playerName, int leaderboard, string format, string token, string username);
    }
}
