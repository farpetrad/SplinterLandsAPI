using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SplinterLands.DTOs.Models;

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
                var response = GetClientResponse("cards/get_details");
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {

                    var set = new CardSet()
                    {
                        Cards = JArray.Parse(response.Content).ToObject<List<Card>>() ?? new List<Card>()
                    };
                    return set;
                }
                throw new Exception($"Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetCards");
                return new CardSet();
            }
        }

        public PlayerBattles GetBattlesForPlayer(string playerName)
        {
            if(string.IsNullOrEmpty(playerName))   throw new ArgumentException("playerName must be provided", nameof(playerName));
            try
            {
                var response = GetClientResponse($"battle/history?player={playerName}");
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    var battles = JsonConvert.DeserializeObject<PlayerBattles>(response.Content) ?? new PlayerBattles() { Player = playerName };

                    return battles;
                }
                throw new Exception($"Invalid response {response?.StatusCode}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetBattlesForPlayer");
                return new PlayerBattles() { Player = playerName };
            }
        }

        public CardDetails GetCardDetails(string Uid)
        {
            if(string.IsNullOrEmpty(Uid)) throw new ArgumentException("Uid must be provided", nameof(Uid));
            try
            {
                var response = GetClientResponse($"cards/find?ids={Uid}");
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    var details = JsonConvert.DeserializeObject<List<CardDetails>>(response.Content) ?? new List<CardDetails>();
                    return details.First();
                }
                throw new Exception($"Invalid response {response?.StatusCode}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetCardDetails");
                return new CardDetails();
            }
        }

        public PlayerQuest GetPlayersCurrentQuest(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                var response = GetClientResponse($"players/quests?username={playerName}", false);
                if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    var quest = JsonConvert.DeserializeObject<List<PlayerQuest>>(response.Content) ?? new List<PlayerQuest>() { new PlayerQuest() { Player = playerName } };
                    return quest.First();
                }
                throw new Exception($"Invalid response {response?.StatusCode}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetPlayersCurrentQuest");
                return new PlayerQuest() {  Player = playerName };
            }

        }

        public ReferralCollection GetReferralsForPlayer(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                var response = GetClientResponse($"/players/referrals?username={playerName}");
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<ReferralCollection>(response.Content) ?? new ReferralCollection();

                }
                throw new Exception($"Invalid response {response?.StatusCode}");
                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetReferralsForPlayer");
                return new ReferralCollection();
            }
            
        }

        private IRestResponse? GetClientResponse(string endPoint, bool api1 = true)
        {
            string api = string.Empty;
            if (api1)
            {
                api = "https://api.splinterlands.io";
            }
            else
            {
                api = "https://api2.splinterlands.com";
            }
            var client = new RestClient(api);
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";

            var request = new RestRequest(endPoint, Method.GET, DataFormat.Json);
            return client.Get(request);
        }
    }
}