﻿using Microsoft.Extensions.Logging;
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
                return new CardSet();
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
                return new PlayerBattles() { Player = playerName };
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetBattlesForPlayer");
                return new PlayerBattles() { Player = playerName };
            }
        }

        public Card GetCardDetails(string Uid)
        {
            if(string.IsNullOrEmpty(Uid)) throw new ArgumentException("Uid must be provided", nameof(Uid));
            try
            {
                var response = GetClientResponse($"cards/find?ids={Uid}");
                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK &&
                    response.Content.Length > 0)
                {
                    var details = JsonConvert.DeserializeObject<List<CardDetails>>(response.Content) ?? new List<CardDetails>();
                    return details.First().Details;
                }
                return new Card();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while calling GetCardDetails");
                return new Card();
            }
        }

        private IRestResponse? GetClientResponse(string endPoint)
        {
            var client = new RestClient("https://api.splinterlands.io");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36";

            var request = new RestRequest(endPoint, Method.GET, DataFormat.Json);
            return client.Get(request);
        }
    }
}