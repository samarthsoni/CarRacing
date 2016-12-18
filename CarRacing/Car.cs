using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CarRacing
{
    public sealed class Car
    {
        SynchronizedRandomGenerator R;
        
        public int CarID
        {
            get; set;
        }

        public int DestKM
        {
            get; set;
        }

        public Car(int carID, SynchronizedRandomGenerator rd, int destKM)
        {
            CarID = carID;
            R = rd;
            DestKM = destKM;
        }

        //Allows a car to Race. Updates past kilometers on console and updates when a car finsihes race.
        public void Race()
        {
            int pastKM=0;

            while(pastKM<DestKM)
            {
                int a = R.Next(pastKM, DestKM);
                pastKM = pastKM + a;

                if (pastKM >= DestKM)
                {
                    Console.WriteLine("Car:{0}  Finished the race",CarID);
                }
                else
                    Console.WriteLine("Car:{0}  The number of kilometers past:{1}",CarID,pastKM);

                Thread.Sleep(10);
            }
            
            
        }
    }
}
