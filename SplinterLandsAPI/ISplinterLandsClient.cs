using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    internal interface ISplinterLandsClient
    {
        CardSet GetCards();
        CardDetails GetCardDetails(string Uid);
        PlayerBattles GetBattlesForPlayer(string playerName);
    }
}
