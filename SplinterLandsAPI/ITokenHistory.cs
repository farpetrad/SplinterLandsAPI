using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface ITokenHistory
    {
        List<TokenHistoryRecord> GetTokenHistory(string player, string tokenType, string token, int limit = 50, string from = "&last_update_date=");
        Task<List<TokenHistoryRecord>> GetTokenHistoryAsync(string player, string tokenType, string token, int limit = 50, string from = "&last_update_date=");
        List<ExchangeHistoryRecord> GetExchangeHistory(string player, string tokenType, string token, uint limit = 50, uint offset = 0);
        Task<List<ExchangeHistoryRecord>> GetExchangeHistoryAsync(string player, string tokenType, string token, uint limit = 50, uint offset = 0);
    }
}
