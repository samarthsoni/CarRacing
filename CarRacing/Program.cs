using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarRacing
{
    class Program
    {
        static private readonly int raceDistance = 1000;
        static void Main(string[] args)
        {
            int noOfCars;
            
            Console.WriteLine("Enter the number fo cars:");
            string input = Console.ReadLine();
            while(int.TryParse(input,out noOfCars) ==false || noOfCars <= 0)
            {
                Console.WriteLine("Invalid Input. Enter the number of cars again:");
                input = Console.ReadLine();
            }

            start_race(noOfCars);
            
            Console.Read();
        }

        //Instantiates different cars and starts race with dedicated thread for each car.
        static void start_race(int noOfCars)
        {
            SynchronizedRandomGenerator randomGenerator = new SynchronizedRandomGenerator();
            Car[] cars = new Car[noOfCars];
            int result = 0;

            for (int c = 0; c < noOfCars; c++)
            {
                cars[c] = new Car(c, randomGenerator, raceDistance);
            }

            try
            {
                for (int c = 0; c < noOfCars; c++)
                {
                    Thread newThread = new Thread(new ThreadStart(cars[c].Race));
                    newThread.Name = c.ToString();
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
