using SplinterLandsAPI.Models;

namespace SplinterLandsAPI
{
    internal interface ISplinterLandsClient
    {
        CardSet GetCards();
        PlayerBattles GetBattlesForPlayer(string playerName);
    }
}
