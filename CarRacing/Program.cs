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
        static void Main(string[] args)
        {
            int NoOfCars;
            SynchronizedRandomGenerator rd = new SynchronizedRandomGenerator();

            Console.WriteLine("Enter the number fo cars:");
            string input = Console.ReadLine();
            while(int.TryParse(input,out NoOfCars)==false)
            {
                Console.WriteLine("Invalid Input. Enter the number fo cars again:");
                input = Console.ReadLine();
            }


            Car[] cars = new Car[NoOfCars];
            int result = 0;
            for (int c = 0; c < NoOfCars; c++)
            {
                cars[c] = new Car(c, rd, 1000);
            }

            try
            {
                for (int c = 0; c < NoOfCars; c++)
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

            Console.Read();
        }
    }
}
