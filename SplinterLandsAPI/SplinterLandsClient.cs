using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using SplinterLands.DTOs.Enums;
using SplinterLands.DTOs.Models;
using System.Net;

namespace SplinterLandsAPI
{
    public class SplinterLandsClient : ISplinterLandsClient
    {
        private readonly ILogger _logger;
        private readonly string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";
        private readonly CookieContainer _cookieJar = new CookieContainer();
        public SplinterLandsClient(ILogger logger)
        {
            _logger = logger;
        }

        public LandWorksiteDetailsResponse GetActiveWorksite(string deed_uid)
        {
            if(string.IsNullOrEmpty(deed_uid)) throw new ArgumentException($"${nameof(deed_uid)} must be provided");
            return GetClientResponse<LandWorksiteDetailsResponse>($"land/projects/deed/{deed_uid}/active", api1: false, vnext: true);
        }

        public async Task<LandWorksiteDetailsResponse> GetActiveWorksiteAsync(string deed_uid)
        {
            if (string.IsNullOrEmpty(deed_uid)) throw new ArgumentException($"${nameof(deed_uid)} must be provided");
            return await GetClientResponseAsync<LandWorksiteDetailsResponse>($"land/projects/deed/{deed_uid}/active", api1: false, vnext: true);
        }

        public CardSet GetCards()
        {
            try
            {
                var set = new CardSet()
                {
                    Cards = GetClientResponse<List<Card>>("cards/get_details")
                };
                return set;
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
                var set = new CardSet()
                {
                    Cards = await GetClientResponseAsync<List<Card>>("cards/get_details")
                };
                return set;
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
                return GetClientResponse<PlayerBattles>($"battle/history?player={playerName}", false);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetBattlesForPlayer");
                return new PlayerBattles() { Player = playerName };
            }
        }

        public async Task<PlayerBattles> GetBattlesForPlayerAsync(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("playerName must be provided", nameof(playerName));
            try
            {
                return await GetClientResponseAsync<PlayerBattles>($"battle/history?player={playerName}", false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetBattlesForPlayerAsync");
                return new PlayerBattles() { Player = playerName };
            }
        }

        public CardDetails GetCardDetails(string Uid)
        {
            if(string.IsNullOrEmpty(Uid)) throw new ArgumentException("Uid must be provided", nameof(Uid));
            try
            {
                return GetClientResponse<List<CardDetails>>($"cards/find?ids={Uid}").First();
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
                return (await GetClientResponseAsync<List<CardDetails>>($"cards/find?ids={Uid}")).First();
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
                return GetClientResponse<List<PlayerQuest>>($"players/quests?username={playerName}", false).First();
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
                return (await GetClientResponseAsync<List<PlayerQuest>>($"players/quests?username={playerName}", false)).First();
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
                return GetClientResponse<EditionPackPurchases>($"players/pack_purchases?edition={Convert.ToInt32(edition)}&username={playerName}", false);
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
                return await GetClientResponseAsync<EditionPackPurchases>($"players/pack_purchases?edition={Convert.ToInt32(edition)}&username={playerName}", false);
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
                return GetClientResponse<List<RentalCard>>($"market/active_rentals?owner={playerName}", false);
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
                return await GetClientResponseAsync<List<RentalCard>>($"market/active_rentals?owner={playerName}", false);
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
                return GetClientResponse<List<RentalCard>>($"market/active_rentals?renter={playerName}", false);
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
               return await GetClientResponseAsync<List<RentalCard>>($"market/active_rentals?renter={playerName}", false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetActivelyRentaledCardsForPlayer");
                return new List<RentalCard>();
            }
        }

        public List<Currency> GetTokenBalancesForPlayer(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                return GetClientResponse<List<Currency>>($"players/balances?username={playerName}", false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetTokenBalancesForPlayer");
                return new List<Currency>();
            }
        }
        public async Task<List<Currency>> GetTokenBalancesForPlayerAsync(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                return await GetClientResponseAsync<List<Currency>>($"players/balances?username={playerName}", false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetTokenBalancesForPlayerAsync");
                return new List<Currency>();
            }
        }

        public ReferralCollection GetReferralsForPlayer(string playerName)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                return GetClientResponse<ReferralCollection>($"/players/referrals?username={playerName}");
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
                return await GetClientResponseAsync<ReferralCollection>($"/players/referrals?username={playerName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetReferralsForPlayerAsync");
                return new ReferralCollection();
            }
        }

        private T GetClientResponse<T>(string endPoint, bool api1 = true, bool vnext = false) where T: new()
        {
            try
            {
                string api = string.Empty;
                if (api1)
                {
                    api = "https://api.splinterlands.io";
                }
                else if (!vnext)
                {
                    api = "https://api2.splinterlands.com";
                }
                else if (vnext)
                {
                    api = "https://vapi.splinterlands.com";
                }
                var client = new RestClient(api);
                client.UserAgent = UserAgent;
                client.CookieContainer = _cookieJar;

                var request = new RestRequest(endPoint, Method.GET, DataFormat.Json);
                var response = client.Get(request);

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    return JsonConvert.DeserializeObject<T>(response.Content) ?? new T();

                }
                throw new Exception($"GetClientResponse - Invalid response {response?.StatusCode}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured executing rest request");
                throw;
            }
        }

        private async Task<T> GetClientResponseAsync<T>(string endPoint, bool api1 = true, bool vnext = false) where T: new()
        {
            string api = string.Empty;
            if (api1)
            {
                api = "https://api.splinterlands.io";
            }
            else if(!vnext)
            {
                api = "https://api2.splinterlands.com";
            } else if(vnext)
            {
                api = "https://vapi.splinterlands.com";
            }
            var client = new RestClient(api);
            client.UserAgent = UserAgent;
            client.CookieContainer = _cookieJar;

            var request = new RestRequest(endPoint, Method.GET, DataFormat.Json);
            var response = await client.ExecuteAsync(request);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
            {
                return JsonConvert.DeserializeObject<T>(response.Content) ?? new T();

            }
            throw new Exception($"GetClientResponseAsync - Invalid response {response?.StatusCode}");
        }
    }
}