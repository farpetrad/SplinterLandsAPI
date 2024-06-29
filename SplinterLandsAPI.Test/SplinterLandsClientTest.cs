using Cryptography.ECDSA;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using sl_Hive.Engine;
using SplinterLands.DTOs.Enums;
using System;
using System.Text;
using System.Threading.Tasks;

namespace SplinterLandsAPI.Test
{
    [TestClass]
    public class SplinterLandsClientTest
    {
        public SplinterLandsClientTest()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).AddEnvironmentVariables();

            var Configuration = builder.Build();

            PrivatePostingKey = Configuration["KEY"] ?? string.Empty;
            User = Configuration["HIVEUSERNAME"] ?? string.Empty;

            if(PrivatePostingKey == string.Empty)
            {
                PrivatePostingKey = Environment.GetEnvironmentVariable("KEY") ?? string.Empty;
            }
            if(User == string.Empty)
            {
                User = Environment.GetEnvironmentVariable("HIVEUSERNAME") ?? string.Empty;
            }
        }
        private ILogger Log => new Mock<ILogger>().Object;
        private readonly string User;
        private readonly string PrivatePostingKey;

        [TestMethod]
        public void LoginTest()
        {
            Assert.IsTrue(User != string.Empty);
            Assert.IsTrue(PrivatePostingKey != string.Empty);
            var client = new SplinterLandsClient(Log);
            var ts = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString();
            var hash = Sha256Manager.GetHash(Encoding.ASCII.GetBytes(User + ts));
            var sig = Secp256K1Manager.SignCompressedCompact(hash, CBase58.DecodePrivateWif(PrivatePostingKey));
            var signature = Hex.ToString(sig);
            var result = client.Login(User, signature, ts);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetDeedStakeableGroupedCards()
        {
            var client = new SplinterLandsClient(Log);
            var result = client.GetGroupedDeedStakeableCards(StakeTypesEnum.Worker, "I-296-a840be819c5962", "farpetrad", 0, 100, GroupedDeedStakeableCardsOrderByEnum.name, GroupedDeedStakeableCardsOrderByAscEnum.desc);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.data);
            Assert.IsNotNull(result.data.cards);
            Assert.IsTrue(result.data.cards.Length > 0);
        }

        [TestMethod]
        public void GetDeeedRewardActions()
        {
            var client = new SplinterLandsClient(Log);
            var result = client.GetRewardActionsForDeed("I-302-8f7c5f8449b785");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.data);
            Assert.IsTrue(result.data.Length > 0);
        }

        [TestMethod]
        public void GetDeedDetails()
        {
            var client = new SplinterLandsClient(Log);
            var result = client.GetDeedDetails(1);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void GetWorksiteDetails()
        {
            var deed_uid = "I-294-07d0b7f3a611d9";
            var client = new SplinterLandsClient(Log);
            var result = client.GetActiveWorksite(deed_uid);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestGetCards()
        {
            var client = new SplinterLandsClient(Log);
            var cardSet = client.GetCards();

            Assert.IsNotNull(cardSet);
            Assert.IsNotNull(cardSet.Cards);
            Assert.IsTrue(cardSet.Cards.Count > 0);

            cardSet = null;
            var task = client.GetCardsAsync();
            Task.WaitAll(task);
            cardSet = task.Result;

            Assert.IsNotNull(cardSet);
            Assert.IsNotNull(cardSet.Cards);
            Assert.IsTrue(cardSet.Cards.Count > 0);
        }

        [TestMethod]
        public void TestGetPlayerBattles()
        {
            Assert.IsTrue(User != string.Empty);
            Assert.IsTrue(PrivatePostingKey != string.Empty);
            var client = new SplinterLandsClient(Log);
            var ts = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString();
            var hash = Sha256Manager.GetHash(Encoding.ASCII.GetBytes(User + ts));
            var sig = Secp256K1Manager.SignCompressedCompact(hash, CBase58.DecodePrivateWif(PrivatePostingKey));
            var signature = Hex.ToString(sig);
            var token = client.Login(User, signature, ts);

            var battles = client.GetBattlesForPlayer("ahsoka", 2, "WILD", token, "ahsoka");

            Assert.IsNotNull(battles);
            Assert.IsNotNull(battles.Battles);
            Assert.IsTrue(battles.Battles.Count >= 0);

            battles = null;
            var task = client.GetBattlesForPlayerAsync("ahsoka", 2, "WILD", token, "ahsoka");
            Task.WaitAll(task);
            battles = task.Result;

            Assert.IsNotNull(battles);
            Assert.IsNotNull(battles.Battles);
            Assert.IsTrue(battles.Battles.Count >= 0);
        }

        [TestMethod]
        public void TestGetCardDetails()
        {
            var client = new SplinterLandsClient(Log);
            var cardDetails = client.GetCardDetails("C-B3HJQSQCPC");

            Assert.IsNotNull(cardDetails);
            Assert.IsTrue(cardDetails.Edition != SetEditionEnum.Invalid);
            Assert.IsTrue(cardDetails.Details.Id > 0);

            cardDetails = null;
            var task = client.GetCardDetailsAsync("C-B3HJQSQCPC");
            Task.WaitAll(task);
            cardDetails = task.Result;

            Assert.IsNotNull(cardDetails);
            Assert.IsTrue(cardDetails.Edition != SetEditionEnum.Invalid);
            Assert.IsTrue(cardDetails.Details.Id > 0);
        }

        [TestMethod]
        public void TestGetPlayersQuest()
        {
            var client = new SplinterLandsClient(Log);
            var quest = client.GetPlayersCurrentQuest("farpetrad");

            Assert.IsNotNull(quest);
            Assert.IsTrue(!string.IsNullOrEmpty(quest.Id));
            Assert.IsTrue(!string.IsNullOrEmpty(quest.Name));

            quest = null;
            var task = client.GetPlayerCurrentQuestAsync("farpetrad");
            Task.WaitAll(task);
            quest = task.Result;

            Assert.IsNotNull(quest);
            Assert.IsTrue(!string.IsNullOrEmpty(quest.Id));
            Assert.IsTrue(!string.IsNullOrEmpty(quest.Name));
        }

        [TestMethod]
        public void TestPlayerReferrals()
        {
            Assert.IsTrue(User != string.Empty);
            Assert.IsTrue(PrivatePostingKey != string.Empty);
            var client = new SplinterLandsClient(Log);
            var ts = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString();
            var hash = Sha256Manager.GetHash(Encoding.ASCII.GetBytes(User + ts));
            var sig = Secp256K1Manager.SignCompressedCompact(hash, CBase58.DecodePrivateWif(PrivatePostingKey));
            var signature = Hex.ToString(sig);
            var token = client.Login(User, signature, ts);

            var referral = client.GetReferralsForPlayer("z3ll", token);

            Assert.IsNotNull(referral);
            Assert.IsTrue(referral.Referrals.Count > 0);
            referral = null;

            var task = client.GetReferralsForPlayerAsync("z3ll",  token);
            Task.WaitAll(task);

            referral = task.Result;
            Assert.IsNotNull(referral);
            Assert.IsTrue(referral.Referrals.Count > 0);
        }

        [TestMethod]
        public void TestPlayerPackPurchases()
        {
            var client = new SplinterLandsClient(Log);
            var purchases = client.GetPackPurchaesForPlayerByEdition("z3ll", SetEditionEnum.ChaosLegion);

            Assert.IsNotNull(purchases);
            Assert.IsTrue(purchases.Packs > 0);
            purchases = null;

            var task = client.GetPackPurchaesForPlayerByEditionAsync("z3ll", SetEditionEnum.ChaosLegion);
            Task.WaitAll(task);
            purchases = task.Result;

            Assert.IsNotNull(purchases);
            Assert.IsTrue(purchases.Packs > 0);
        }

        [TestMethod]
        public void TestPlayerActiveRentals()
        {
            var client = new SplinterLandsClient(Log);
            var rentals = client.GetActiveRentalsForPlayer("grabapack");

            Assert.IsNotNull(rentals);
            Assert.IsTrue(rentals.Count >= 0);
            rentals = null;

            var task = client.GetActiveRentalsForPlayerAsync("grabapack");
            Task.WaitAll(task);
            rentals = task.Result;

            Assert.IsNotNull(rentals);
            Assert.IsTrue(rentals.Count >= 0);
        }

        [TestMethod]
        public void TestPlayerCurrentRentals()
        {
            var client = new SplinterLandsClient(Log);
            var rentals = client.GetActivelyRentaledCardsForPlayer("buddy06");

            Assert.IsNotNull(rentals);
            Assert.IsTrue(rentals.Count >= 0);
            rentals = null;

            var task = client.GetActivelyRentaledCardsForPlayerAsync("buddy06");
            Task.WaitAll(task);
            rentals = task.Result;

            Assert.IsNotNull(rentals);
            Assert.IsTrue(rentals.Count >= 0);
        }

        [TestMethod]
        public void TestPlayerTokenBalances()
        {
            var client = new SplinterLandsClient(Log);
            var balances = client.GetTokenBalancesForPlayer("farpetrad");

            Assert.IsNotNull(balances);
            Assert.IsTrue(balances.Count > 0);
            balances = null;

            var task = client.GetTokenBalancesForPlayerAsync("farpetrad");
            Task.WaitAll(task);
            balances = task.Result;

            Assert.IsNotNull(balances);
            Assert.IsTrue(balances.Count > 0);
        }

        [TestMethod]
        public void TestGetLiquidityPools()
        {
            var client = new SplinterLandsClient(Log);

            var pools = client.GetLiquidityPools();
            Assert.IsNotNull(pools);
            Assert.IsTrue(pools.data.Length > 0);

            var task = client.GetLiquidityPoolsAsync();
            Task.WaitAll(task);

            var taskPools = task.Result.data;
            Assert.IsNotNull(taskPools);
            Assert.IsTrue(taskPools.Length > 0);
        }

        [TestMethod]
        public void TestGetLiqidityPoolResources()
        {
            var player = "farpetrad";
            var resource = "GRAIN";
            var client = new SplinterLandsClient(Log);

            var resources = client.GetLiquidityRegionResources(player, resource);
            Assert.IsNotNull(resources);
            Assert.IsTrue((resources?.data?.Length ?? 0) > 0);

            var task = client.GetLiquidityRegionResourcesAsync(player, resource);
            Task.WaitAll(task);

            var taskResources = task.Result.data;
            Assert.IsNotNull(taskResources);
            Assert.IsTrue(taskResources.Length > 0);

        }

        [TestMethod]
        public void TestGetPlayerLiquidityHoldings()
        {
            var player = "farpetrad";
            var resource = "GRAIN";
            var client = new SplinterLandsClient(Log);

            var holdings = client.GetPlayerLiquidityHoldings(player, resource);
            Assert.IsNotNull(holdings);
            Assert.IsTrue((holdings?.data?.Length ?? 0) > 0);

            var task = client.GetPlayerLiquidityHoldingsAsync(player, resource);
            Task.WaitAll(task);
            var taskResources = task.Result.data;
            Assert.IsNotNull(taskResources);
            Assert.IsTrue(taskResources.Length > 0);
        }

        [TestMethod]
        public void TestGetLiquidityPoolById()
        {
            uint poolId = 1;
            var client = new SplinterLandsClient(Log);
            var pool = client.GetLiquidityPoolById(poolId);
            Assert.IsNotNull(pool);
            Assert.IsNotNull(pool.data);

            var task = client.GetLiquidityPoolByIdAsync(poolId);
            Task.WaitAll(task);
            var taskResources = task.Result.data;
            Assert.IsNotNull(taskResources);
        }

        [TestMethod]
        public void TestGetLiquidityPoolRewards()
        {
            var client = new SplinterLandsClient(Log);
            var rewards = client.GetLiquidityRewards();
            Assert.IsNotNull(rewards);
            Assert.IsNotNull(rewards.data);

            var task = client.GetLiquidityRewardsAsync();
            Task.WaitAll(task);
            var taskRewards = task.Result.data;
            Assert.IsNotNull(taskRewards);
        }
    }
}