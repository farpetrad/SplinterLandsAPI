using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using SplinterLands.DTOs.Enums;
using SplinterLands.DTOs.Models;
using System.Net;
using System.Text.RegularExpressions;

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

        private static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string DoQuickRegex(string Pattern, string Match)
        {
            Regex r = new(Pattern, RegexOptions.Singleline);
            return r.Match(Match).Groups[1].Value;
        }

        /// <summary>
        /// Returns a player specific token used for requests
        /// </summary>
        /// <param name="username"></param>
        /// <param name="signature"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Login(string username, string signature, string ts)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException("username must be provided");
            if (string.IsNullOrEmpty(signature)) throw new ArgumentNullException("signature must be provided");

            var bid = "bid_" + SplinterLandsClient.RandomString(20);
            var sid = "sid_" + SplinterLandsClient.RandomString(20);
            
            var options = new RestClientOptions()
            {
                CookieContainer = _cookieJar,
                UserAgent = UserAgent,
                BaseUrl = new Uri("https://api2.splinterlands.com"),
            };
            using var client = new RestClient(options);

            var request = new RestRequest($"players/login?name={username}&ref=&browser_id={bid}&session_id={sid}&sig={signature}&ts={ts}") { Method = Method.Get, RequestFormat = DataFormat.Json };
            var response = client.Get(request);
            if (response != null && response.StatusCode == HttpStatusCode.OK &&
                    response?.Content?.Length > 0)
            {
                var token = DoQuickRegex("\"name\":\"" + username + "\",\"token\":\"([A-Z0-9]{10})\"", response.Content);
                return token;

            }
            return "";
        }

        public async Task<string> LoginAsync(string username, string signature, string ts)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException("username must be provided");
            if (string.IsNullOrEmpty(signature)) throw new ArgumentNullException("signature must be provided");

            var bid = "bid_" + SplinterLandsClient.RandomString(20);
            var sid = "sid_" + SplinterLandsClient.RandomString(20);

            var options = new RestClientOptions()
            {
                CookieContainer = _cookieJar,
                UserAgent = UserAgent,
                BaseUrl = new Uri("https://api2.splinterlands.com"),
            };
            using var client = new RestClient(options);

            var request = new RestRequest($"players/login?name={username}&ref=&browser_id={bid}&session_id={sid}&sig={signature}&ts={ts}") { Method = Method.Get, RequestFormat = DataFormat.Json };
            var response = await client.GetAsync(request);
            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response?.Content?.Length > 0)
            {
                var token = DoQuickRegex("\"name\":\"" + username + "\",\"token\":\"([A-Z0-9]{10})\"", response.Content);
                return token;

            }
            return "";
        }

        public VnexApiResponse<LandWorksiteDetails> GetActiveWorksite(string deed_uid)
        {
            if(string.IsNullOrEmpty(deed_uid)) throw new ArgumentNullException($"${nameof(deed_uid)} must be provided");
            return GetClientResponse<VnexApiResponse<LandWorksiteDetails>>($"land/projects/deed/{deed_uid}/active", api1: false, vnext: true);
        }

        public async Task<VnexApiResponse<LandWorksiteDetails>> GetActiveWorksiteAsync(string deed_uid)
        {
            if (string.IsNullOrEmpty(deed_uid)) throw new ArgumentNullException($"${nameof(deed_uid)} must be provided");
            return await GetClientResponseAsync<VnexApiResponse<LandWorksiteDetails>>($"land/projects/deed/{deed_uid}/active", api1: false, vnext: true);
        }

        public VnexApiResponse<LandDeedDetails> GetDeedDetails(int deedId)
        {
            if (deedId <= 0) throw new ArgumentOutOfRangeException("Invalid deedId");
            return GetClientResponse<VnexApiResponse<LandDeedDetails>>($"land/deeds/{deedId}", api1: false, vnext: true);
        }

        public async Task<VnexApiResponse<LandDeedDetails>> GetDeedDetailsAsync(int deedId)
        {
            if (deedId <= 0) throw new ArgumentOutOfRangeException("Invalid deedId");
            return await GetClientResponseAsync<VnexApiResponse<LandDeedDetails>>($"land/deeds/{deedId}", api1: false, vnext: true);
        }

        public VnexApiResponse<LandProjectRewardAction[]> GetRewardActionsForDeed(string deed_uid, int offset = 0, int limit = 10)
        {
            if (string.IsNullOrEmpty(deed_uid)) throw new ArgumentNullException($"${nameof(deed_uid)} must be provided");
            return GetClientResponse<VnexApiResponse<LandProjectRewardAction[]>>($"land/resources/rewardactions/{deed_uid}?limit={limit}&offset={offset}", api1: false, vnext: true);
        }

        public async Task<VnexApiResponse<LandProjectRewardAction[]>> GetRewardActionsForDeedAsync(string deed_uid, int offset = 0, int limit = 10)
        {
            if (string.IsNullOrEmpty(deed_uid)) throw new ArgumentNullException($"${nameof(deed_uid)} must be provided");
            return await GetClientResponseAsync<VnexApiResponse<LandProjectRewardAction[]>>($"land/resources/rewardactions/{deed_uid}?limit={limit}&offset={offset}", api1: false, vnext: true);
        }

        public VnexApiResponse<LiquidityPool[]> GetLiquidityPools()
        {
            return GetClientResponse<VnexApiResponse<LiquidityPool[]>>("land/liquidity/pools", api1: false, vnext: true);
        }

        public async Task<VnexApiResponse<LiquidityPool[]>> GetLiquidityPoolsAsync()
        {
            return await GetClientResponseAsync<VnexApiResponse<LiquidityPool[]>>("land/liquidity/pools", api1: false, vnext: true); ;
        }

        public VnexApiResponse<LiquidityPool> GetLiquidityPoolById(uint id)
        {
            return GetClientResponse<VnexApiResponse<LiquidityPool>>($"land/liquidity/pools/{id}", api1: false, vnext: true);
        }
        public async Task<VnexApiResponse<LiquidityPool>> GetLiquidityPoolByIdAsync(uint id)
        {
            return await GetClientResponseAsync<VnexApiResponse<LiquidityPool>>($"land/liquidity/pools/{id}", api1: false, vnext: true); ;
        }

        public VnexApiResponse<LiquidityRegionResource[]> GetLiquidityRegionResources(string player, string resource)
        {
            return GetClientResponse<VnexApiResponse<LiquidityRegionResource[]>>($"land/liquidity/resources/{player}/{resource}", api1: false, vnext: true);
        }
        public async Task<VnexApiResponse<LiquidityRegionResource[]>> GetLiquidityRegionResourcesAsync(string player, string resource)
        {
            return await GetClientResponseAsync<VnexApiResponse<LiquidityRegionResource[]>>($"land/liquidity/resources/{player}/{resource}", api1: false, vnext: true);
        }

        public VnexApiResponse<PlayerLiquidityPoolHoldings[]> GetPlayerLiquidityHoldings(string player, string resource)
        {
            return GetClientResponse<VnexApiResponse<PlayerLiquidityPoolHoldings[]>>($"land/liquidity/pools/{player}/{resource}", api1: false, vnext: true);
        }
        public async Task<VnexApiResponse<PlayerLiquidityPoolHoldings[]>> GetPlayerLiquidityHoldingsAsync(string player, string resource)
        {
            return await GetClientResponseAsync<VnexApiResponse<PlayerLiquidityPoolHoldings[]>>($"land/liquidity/pools/{player}/{resource}", api1: false, vnext: true); ;
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

        public PlayerBattles GetBattlesForPlayer(string playerName, int leaderboard, string format, string token, string username)
        {
            if(string.IsNullOrEmpty(playerName))   throw new ArgumentException("playerName must be provided", nameof(playerName));
            try
            {
                return GetClientResponse<PlayerBattles>($"battle/history2?player={playerName}&leaderboard={leaderboard}&format={format}&token={token}&username={username}", false);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetBattlesForPlayer");
                return new PlayerBattles() { Player = playerName };
            }
        }

        public async Task<PlayerBattles> GetBattlesForPlayerAsync(string playerName, int leaderboard, string format, string token, string username)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("playerName must be provided", nameof(playerName));
            try
            {
                return await GetClientResponseAsync<PlayerBattles>($"battle/history2?player={playerName}&leaderboard={leaderboard}&format={format}&token={token}&username={username}", false);
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

        public ReferralCollection GetReferralsForPlayer(string playerName, string token, int page = 1, int pageSize = 3)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                return GetClientResponse<ReferralCollection>($"/players/referral_users?username={playerName}&token={token}&page_size={pageSize}&page={page}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetReferralsForPlayer");
                return new ReferralCollection();
            }
            
        }

        public async Task<ReferralCollection> GetReferralsForPlayerAsync(string playerName, string token, int page = 1, int pageSize = 3)
        {
            if (string.IsNullOrEmpty(playerName)) throw new ArgumentException("Player name must be provided", nameof(playerName));
            try
            {
                return await GetClientResponseAsync<ReferralCollection>($"/players/referral_users?username={playerName}&token={token}&page_size={pageSize}&page={page}");
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
                var options = new RestClientOptions()
                {
                    CookieContainer = _cookieJar,
                    UserAgent = UserAgent,
                    BaseUrl = new Uri(api),
                };
                using var client = new RestClient(options);

                var request = new RestRequest(endPoint) { Method = Method.Get, RequestFormat = DataFormat.Json };
                var response = client.Get(request);

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK && response?.Content?.Length > 0)
                {
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        Error = (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs) =>
                        {
                            int stop = 0;
                        }
                    };
                    return JsonConvert.DeserializeObject<T>(response.Content, settings) ?? new T();

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
            var options = new RestClientOptions()
            {
                CookieContainer = _cookieJar,
                UserAgent = UserAgent,
                BaseUrl = new Uri(api),
            };
            using var client = new RestClient(options);

            var request = new RestRequest(endPoint) { Method = Method.Get, RequestFormat = DataFormat.Json };
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