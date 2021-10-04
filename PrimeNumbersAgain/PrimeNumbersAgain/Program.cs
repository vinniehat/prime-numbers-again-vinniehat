using System;
using System.Diagnostics;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            Stopwatch timer = new Stopwatch();

            
            // Start Initialization
            PrintBanner();
            n = GetNumber();
            // Initialization Complete
            
            // Start The Algorithm
            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            // Algorithm Complete
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds}.{timer.Elapsed.Milliseconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
            int primeNumber = 0;
            int primeNumbers = 0;
            for (int i = 1; primeNumbers <= n; i++) // Set pN to less than or equal to n, which is what we want to find
            {
                System.Threading.Thread.Sleep(1); // This gives the PC a buffer between each check
                bool boolean = true; // This boolean defines whether or not the current number, i, is prime or not
                
                // Checking if it can be divisible by any number from 2-one below the number itself
                for (int x = 2; x < i; x++)
                {
                    
                    if (i % x == 0) boolean = false;
                    Console.WriteLine(i + " ----- " + x);
                }
                
                // If it is not divisible, then set the primeNumber as the last known pN, and add it to the amt of pN's
                if (boolean == true)
                {
                    primeNumber = i;
                    primeNumbers++;
                }
            }

            return primeNumber;
        }

        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 30 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 30)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}