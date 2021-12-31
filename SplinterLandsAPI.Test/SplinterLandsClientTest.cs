using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SplinterLandsAPI.Test
{
    [TestClass]
    public class SplinterLandsClientTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var client = new SplinterLandsClient(null);
            var cardSet = client.GetCards();

            Assert.IsNotNull(cardSet);
            Assert.IsNotNull(cardSet.SetCollection);
            Assert.IsTrue(cardSet.SetCollection.Count > 0);
        }
    }
}