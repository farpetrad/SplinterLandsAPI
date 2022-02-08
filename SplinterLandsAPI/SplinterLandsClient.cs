using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SplinterLands.DTOs.Enums;
using SplinterLands.DTOs.Models;

namespace SplinterLandsAPI
{
    public class SplinterLandsClient : ISplinterLandsClient
    {
        private readonly ILogger _logger;
        private readonly string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
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
                throw new Exception($"GetCards - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetCards");
                return new CardSet();
            }
        }

        public async Task<CardSet> GetCardsAsync()
        {
            try
            {
                var response = await GetClientResponseAsync("cards/get_details");
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {

                    var set = new CardSet()
                    {
                        Cards = JArray.Parse(response.Content).ToObject<List<Card>>() ?? new List<Card>()
                    };
                    return set;
                }
                throw new Exception($"GetCardsAsync - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetCardsAsync");
                return new CardSet();
            }
        }

        public PlayerBattles GetBattlesForPlayer(string playerName)
        {
            if(string.IsNullOrEmpty(playerName))   throw new ArgumentException("playerName must be provided", nameof(playerName));
            try
            {
                var response = GetClientResponse($"battle/history?player={playerName}", false);
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    var battles = JsonConvert.DeserializeObject<PlayerBattles>(response.Content) ?? new PlayerBattles() { Player = playerName };

                    return battles;
                }
                throw new Exception($"GetBattlesForPlayer - Invalid response {response?.StatusCode}");
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
                throw new Exception($"GetCardDetails - Invalid response {response?.StatusCode}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetCardDetails");
                return new CardDetails();
            }
        }

        public async Task<CardDetails> GetCardDetailsAsync(string Uid)
        {
            if (string.IsNullOrEmpty(Uid)) throw new ArgumentException("Uid must be provided", nameof(Uid));
            try
            {
                var response = await GetClientResponseAsync($"cards/find?ids={Uid}");
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    var details = JsonConvert.DeserializeObject<List<CardDetails>>(response.Content) ?? new List<CardDetails>();
                    return details.First();
                }
                throw new Exception($"GetCardDetailsAsync - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetCardDetailsAsync");
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
                throw new Exception($"GetPlayersCurrentQuest - Invalid response {response?.StatusCode}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetPlayersCurrentQuest");
                return new PlayerQuest() {  Player = playerName };
            }

        }
        public async Task<PlayerQuest> GetPlayerCurrentQuestAsync(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                var response = await GetClientResponseAsync($"players/quests?username={playerName}", false);
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    var quest = JsonConvert.DeserializeObject<List<PlayerQuest>>(response.Content) ?? new List<PlayerQuest>() { new PlayerQuest() { Player = playerName } };
                    return quest.First();
                }
                throw new Exception($"GetPlayerCurrentQuestAsync - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetPlayerCurrentQuestAsync");
                return new PlayerQuest() { Player = playerName };
            }
        }

        public EditionPackPurchases GetPackPurchaesForPlayerByEdition(string playerName, SetEditionEnum edition)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            if (edition == SetEditionEnum.Invalid) throw new ArgumentException("A valid edition must be specified", nameof(edition));
            try
            {
                var response = GetClientResponse($"players/pack_purchases?edition={Convert.ToInt32(edition)}&username={playerName}", false);
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<EditionPackPurchases>(response.Content) ?? new EditionPackPurchases() { Player = playerName };

                }
                throw new Exception($"GetPackPurchaesForPlayerByEdition - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetPackPurchaesForPlayerByEdition");
                return new EditionPackPurchases() { Player = playerName };
            }
        }

        public async Task<EditionPackPurchases> GetPackPurchaesForPlayerByEditionAsync(string playerName, SetEditionEnum edition)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            if (edition == SetEditionEnum.Invalid) throw new ArgumentException("A valid edition must be specified", nameof(edition));
            try
            {
                var response = await GetClientResponseAsync($"players/pack_purchases?edition={Convert.ToInt32(edition)}&username={playerName}", false);
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<EditionPackPurchases>(response.Content) ?? new EditionPackPurchases() { Player = playerName };

                }
                throw new Exception($"GetPackPurchaesForPlayerByEditionAsync - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetPackPurchaesForPlayerByEditionAsync");
                return new EditionPackPurchases() { Player = playerName };
            }
        }

        public List<RentalCard> GetActiveRentalsForPlayer(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                var response = GetClientResponse($"market/active_rentals?owner={playerName}", false);
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<List<RentalCard>>(response.Content) ?? new List<RentalCard>();

                }
                throw new Exception($"GetActiveRentalsForPlayer - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetActiveRentalsForPlayer");
                return new List<RentalCard>();
            }
        }

        public async Task<List<RentalCard>> GetActiveRentalsForPlayerAsync(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                var response = await GetClientResponseAsync($"market/active_rentals?owner={playerName}", false);
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<List<RentalCard>>(response.Content) ?? new List<RentalCard>();

                }
                throw new Exception($"GetActiveRentalsForPlayer - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetActiveRentalsForPlayer");
                return new List<RentalCard>();
            }
        }

        public List<RentalCard> GetActivelyRentaledCardsForPlayer(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                var response = GetClientResponse($"market/active_rentals?renter={playerName}", false);
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<List<RentalCard>>(response.Content) ?? new List<RentalCard>();

                }
                throw new Exception($"GetActivelyRentaledCardsForPlayer - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetActivelyRentaledCardsForPlayer");
                return new List<RentalCard>();
            }
        }

        public async Task<List<RentalCard>> GetActivelyRentaledCardsForPlayerAsync(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                var response = await GetClientResponseAsync($"market/active_rentals?renter={playerName}", false);
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<List<RentalCard>>(response.Content) ?? new List<RentalCard>();

                }
                throw new Exception($"GetActivelyRentaledCardsForPlayer - Invalid response {response?.StatusCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetActivelyRentaledCardsForPlayer");
                return new List<RentalCard>();
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
                throw new Exception($"GetReferralsForPlayer - Invalid response {response?.StatusCode}");
                
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetReferralsForPlayer");
                return new ReferralCollection();
            }
            
        }

        public async Task<ReferralCollection> GetReferralsForPlayerAsync(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                var response = await GetClientResponseAsync($"/players/referrals?username={playerName}");
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<ReferralCollection>(response.Content) ?? new ReferralCollection();

                }
                throw new Exception($"GetReferralsForPlayerAsync - Invalid response {response?.StatusCode}");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetReferralsForPlayerAsync");
                return new ReferralCollection();
            }
        }

        private IRestResponse GetClientResponse(string endPoint, bool api1 = true)
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
            client.UserAgent = UserAgent;

            var request = new RestRequest(endPoint, Method.GET, DataFormat.Json);
            return client.Get(request);
        }

        private async Task<IRestResponse> GetClientResponseAsync(string endPoint, bool api1 = true)
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
            client.UserAgent = UserAgent;

            var request = new RestRequest(endPoint, Method.GET, DataFormat.Json);
            return await client.ExecuteAsync(request);
        }
    }
}