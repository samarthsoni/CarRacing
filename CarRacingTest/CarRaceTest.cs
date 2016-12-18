using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRacing;

namespace CarRacingTest
{
    [TestClass]
    public class CarRaceTest
    {
        [TestMethod]
        public void Test_RandomGen_Next()
        {
            int minValue = 30;
            int maxValue = 50;
            SynchronizedRandomGenerator rd = new SynchronizedRandomGenerator();

            int rno = rd.Next(minValue, maxValue);

            Assert.IsTrue(rno <= maxValue && rno >= minValue, "Random Number not correctly generated.");

        }
    }
}
