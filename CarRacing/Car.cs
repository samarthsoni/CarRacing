using System;
using System.Threading;

namespace CarRacing
{
    public sealed class Car
    {
        private readonly SynchronizedRandomGenerator randomGenerator;

        private int CarId { get; }
        private int DestKm { get; }

        public Car(int carId, SynchronizedRandomGenerator rd, int destKm)
        {   
            CarId = carId;
            DestKm = destKm;
            randomGenerator = rd;
        }

        //Allows a car to Race. Updates past kilometers on console and updates when a car finsihes race.
        public void Race()
        {
            var pastKm = 0;

            while(pastKm < DestKm)
            {
                pastKm = pastKm + randomGenerator.Next(pastKm, DestKm); ;

                if (pastKm >= DestKm)
                {
                    Console.WriteLine("Car:{0}  Finished the race",CarId);
                }
                else
                    Console.WriteLine("Car:{0}  The number of kilometers past: {1}",CarId,pastKm);

                Thread.Sleep(10);
            }
        }
    }
}
