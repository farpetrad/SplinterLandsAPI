using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            Assert.IsTrue(cardDetails.Id > 0);
        }
    }
}