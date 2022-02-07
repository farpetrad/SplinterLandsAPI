using SplinterLands.DTOs.Enums;
using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface IPlayerClient
    {
        PlayerQuest GetPlayersCurrentQuest(string playerName);
        ReferralCollection GetReferralsForPlayer(string playerName);
        EditionPackPurchases GetPackPurchaesForPlayerByEdition(string playerName, SetEditionEnum edition);
        List<RentalCard> GetActiveRentalsForPlayer(string playerName);
        List<RentalCard> GetActivelyRentaledCardsForPlayer(string playerName);
    }
}
