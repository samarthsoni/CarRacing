using System;
using System.Threading;

namespace CarRacing
{
    public static class Program
    {
        public static void Main()
        {
            int noOfCars;
            
            Console.WriteLine("Enter the number fo cars:");
            var input = Console.ReadLine();

            while ( !int.TryParse(input,out noOfCars) || noOfCars <= 0)
            {
                Console.WriteLine("Invalid Input. Enter the number fo cars again:");
                input = Console.ReadLine();
            }

            StartRace(noOfCars);
            
            Console.Read();
        }

        //Instantiates different cars and starts race with dedicated thread for each car.
        private static void StartRace(int noOfCars)
        {
            var rd = new SynchronizedRandomGenerator();
            var cars = new Car[noOfCars];
            var result = 0;

            for (var c = 0; c < noOfCars; c++)
            {
                cars[c] = new Car(c, rd, 1000);
            }

            try
            {
                for (var c = 0; c < noOfCars; c++)
                {
                    var newThread = new Thread(cars[c].Race) {Name = c.ToString()};
                    newThread.Start();
                }
            }

            catch (ThreadStateException e)
            {
                Console.WriteLine(e);  // Display text of exception
                result = 1;            // Result says there was an error
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e);  // This exception means that the thread
                                       // was interrupted during a Wait
                result = 1;            // Result says there was an error
            }
            // Even though Main returns void, this provides a return code to 
            // the parent process.
            Environment.ExitCode = result;
        }
    }
}
