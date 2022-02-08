using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SplinterLands.DTOs.Enums;
using System.Threading.Tasks;

namespace SplinterLandsAPI.Test
{
    [TestClass]
    public class SplinterLandsClientTest
    {
        private ILogger Log => new Mock<ILogger>().Object;

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
            var client = new SplinterLandsClient(Log);
            var battles = client.GetBattlesForPlayer("farpetrad");

            Assert.IsNotNull(battles);
            Assert.IsNotNull(battles.Battles);
            Assert.IsTrue(battles.Battles.Count > 0);

            battles = null;
            var task = client.GetBattlesForPlayerAsync("farpetrad");
            Task.WaitAll(task);
            battles = task.Result;

            Assert.IsNotNull(battles);
            Assert.IsNotNull(battles.Battles);
            Assert.IsTrue(battles.Battles.Count > 0);
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
            var client = new SplinterLandsClient(Log);
            var referral = client.GetReferralsForPlayer("z3ll");

            Assert.IsNotNull(referral);
            Assert.IsTrue(referral.Referrals.Count > 0);
            referral = null;

            var task = client.GetReferralsForPlayerAsync("z3ll");
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
            var rentals = client.GetActiveRentalsForPlayer("farpetrad");

            Assert.IsNotNull(rentals);
            Assert.IsTrue(rentals.Count > 0);
            rentals = null;

            var task = client.GetActiveRentalsForPlayerAsync("farpetrad");
            Task.WaitAll(task);
            rentals = task.Result;

            Assert.IsNotNull(rentals);
            Assert.IsTrue(rentals.Count > 0);
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
    }
}