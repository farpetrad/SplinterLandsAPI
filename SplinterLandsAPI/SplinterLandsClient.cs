using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using SplinterLandsAPI.Models;

namespace SplinterLandsAPI
{
    public class SplinterLandsClient : ISplinterLandsClient
    {
        private readonly ILogger _logger;
        public SplinterLandsClient(ILogger logger)
        {
            _logger = logger;
        }
        public CardSet GetCards()
        {
            try
            {
                var client = new RestClient("https://api.splinterlands.io/cards/");
                client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";

                var request = new RestRequest("get_details", Method.GET, DataFormat.Json);
                var response = client.Get(request);
                if(response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {

                    var set = new CardSet()
                    {
                        SetCollection = JArray.Parse(response.Content).ToObject<List<Card>>()
                    };
                    var summoners = set.SetCollection.Where(c => c.Type == "Summoner").ToList();
                    return set;
                }
                return new CardSet();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetCards");
                return new CardSet();
            }
        }
    }
}