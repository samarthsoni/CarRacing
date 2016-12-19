using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRacing;

namespace CarRacingTest
{
    [TestClass]
    public class RandomGeneratorFixture
    {
        private const int MinValue = 30;
        private const int MaxValue = 50;
        private SynchronizedRandomGenerator randomGenerator;

        [TestInitialize]
        public void SetUp()
        {
            randomGenerator = new SynchronizedRandomGenerator();
        }

        [TestMethod]
        public void Test_RandomGen_Next()
        {
            var rno = randomGenerator.Next(MinValue, MaxValue);
            Assert.IsTrue(rno <= MaxValue && rno >= MinValue, "Random Number not correctly generated.");
        }
    }
}
