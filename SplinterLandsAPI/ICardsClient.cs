using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public interface ICardsClient
    {
        CardSet GetCards();
        Task<CardSet> GetCardsAsync();
        CardDetails GetCardDetails(string Uid);
        Task<CardDetails> GetCardDetailsAsync(string Uid);
    }
}
