using System;
using System.Linq;

namespace PasteoVacas
{
    class Program
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine()), consecutives, max;
            while (cases-- > 0)
            {
                Console.ReadLine();
                var cows = Console.ReadLine().Split().Select(e => int.Parse(e));
                max = consecutives = 0;
                foreach (var e in cows)
                {
                    if (e % 2 == 0)
                        consecutives++;
                    else
                    {
                        max = Math.Max(max, consecutives);
                        consecutives = 0;
                    }
                }
                Console.WriteLine(Math.Max(max, consecutives));
            }
        }
    }
}
