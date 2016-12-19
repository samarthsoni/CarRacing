using System;

namespace CarRacing
{
    public sealed class SynchronizedRandomGenerator
    {
        private Random randomGenerator;

        public SynchronizedRandomGenerator()
        {
            randomGenerator = new Random();
        }

        //Generates and returns a random number in specific range
        public int Next(int minValue,int maxValue)
        {
            lock(this)
            {
                return randomGenerator.Next(minValue, maxValue);
            }
        }
    }
}
