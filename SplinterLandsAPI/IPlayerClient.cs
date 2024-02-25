using SplinterLands.DTOs.Enums;
using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface IPlayerClient
    {
        PlayerQuest GetPlayersCurrentQuest(string playerName);
        Task<PlayerQuest> GetPlayerCurrentQuestAsync(string playerName);
        ReferralCollection GetReferralsForPlayer(string playerName, string token, int page, int pageSize);
        Task<ReferralCollection> GetReferralsForPlayerAsync(string playerName, string token, int page, int pageSize);
        EditionPackPurchases GetPackPurchaesForPlayerByEdition(string playerName, SetEditionEnum edition);
        Task<EditionPackPurchases> GetPackPurchaesForPlayerByEditionAsync(string playerName, SetEditionEnum edition);
        List<RentalCard> GetActiveRentalsForPlayer(string playerName);
        Task<List<RentalCard>> GetActiveRentalsForPlayerAsync(string playerName);
        List<RentalCard> GetActivelyRentaledCardsForPlayer(string playerName);
        Task<List<RentalCard>> GetActivelyRentaledCardsForPlayerAsync(string playerName);
        List<Currency> GetTokenBalancesForPlayer(string playerName);
        Task<List<Currency>> GetTokenBalancesForPlayerAsync(string playerName);
    }
}
