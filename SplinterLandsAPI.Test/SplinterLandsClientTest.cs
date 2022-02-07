using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SplinterLands.DTOs.Enums;

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
        }

        [TestMethod]
        public void TestGetPlayerBattles()
        {
            var client = new SplinterLandsClient(Log);
            var battles = client.GetBattlesForPlayer("farpetrad");

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
        }

        [TestMethod]
        public void TestPlayerReferrals()
        {
            var client = new SplinterLandsClient(Log);
            var referral = client.GetReferralsForPlayer("z3ll");

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
        }

        [TestMethod]
        public void TestPlayerActiveRentals()
        {
            var client = new SplinterLandsClient(Log);
            var rentals = client.GetActiveRentalsForPlayer("farpetrad");

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
        }
    }
}