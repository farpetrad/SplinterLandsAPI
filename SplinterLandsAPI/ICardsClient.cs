using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface ICardsClient
    {
        CardSet GetCards();
        CardDetails GetCardDetails(string Uid);
    }
}
