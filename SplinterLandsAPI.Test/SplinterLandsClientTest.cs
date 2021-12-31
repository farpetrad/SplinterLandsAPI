using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SplinterLandsAPI.Test
{
    [TestClass]
    public class SplinterLandsClientTest
    {
        [TestMethod]
        public void TestGetCards()
        {
            var client = new SplinterLandsClient(null);
            var cardSet = client.GetCards();

            Assert.IsNotNull(cardSet);
            Assert.IsNotNull(cardSet.Cards);
            Assert.IsTrue(cardSet.Cards.Count > 0);
        }

        [TestMethod]
        public void TestGetPlayerBattles()
        {
            var client = new SplinterLandsClient(null);
            var battles = client.GetBattlesForPlayer("farpetrad");

            Assert.IsNotNull(battles);
            Assert.IsNotNull(battles.Battles);
            Assert.IsTrue(battles.Battles.Count > 0);
        }
    }
}