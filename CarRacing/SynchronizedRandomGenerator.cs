using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    public sealed class SynchronizedRandomGenerator
    {
        Random rnd;

        public SynchronizedRandomGenerator()
        {
            rnd = new System.Random();
        }

        //Generates and returns a random number in specific range
        public int Next(int minValue,int maxValue)
        {
            lock(this)
            {
                return rnd.Next(minValue, maxValue);
            }
        }
    }
}
