using System;
using System.Linq;

namespace Multiplos9
{
    class Program
    {
        static void Main(string[] args)
        {
            string line, store;
            int degree, sum;
            while ((line = Console.ReadLine()) != "0")
            {
                sum = line.Select(e => e - '0').Sum();
                if (sum % 9 != 0)
                {
                    Console.WriteLine($"{line} is not a multiple of 9.");
                    continue;
                }

                if (line.Length == 1)
                {
                    Console.WriteLine("9 is a multiple of 9 and has 9-degree 1.");
                }
                else
                {
                    store = line;
                    line = $"{sum}";
                    degree = 1;
                    do
                    {
                        
                        sum = line.Select(e => e - '0').Sum();
                        degree++;
                        line = $"{sum}";
                    } while (line.Length > 1) ;
                    Console.WriteLine($"{store} is a multiple of 9 and has 9-degree {degree}.");
                }
            }
        }
    }
}
