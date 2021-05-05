using System;
using System.Collections.Generic;
using System.Text;

namespace FactorizandoNumerosGrandes
{
    class Program
    {
        static bool[] composites;
        static List<long> factors;
        static void InitializeErathostenesSieve(int n)
        {
            composites = new bool[n + 1];
            composites[0] = composites[1] = true;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(n));
            for (int i = 2; i <= sqrt; i++)
                if (!composites[i])
                    for (int j = i + i; j <= n; j += i)
                        composites[j] = true;
        }

        static void Facotorizate(long n)
        {
            factors.Clear();
            long sqrt = (long)Math.Ceiling(Math.Sqrt(n));
            for (int i = 2; n >= sqrt && i < composites.Length; i++)
                if (!composites[i] && n % i == 0)
                {
                    for (int j = i; n % i == 0; j += i)
                    {
                        factors.Add(i);
                        n /= i;
                    }
                    sqrt = (long)Math.Ceiling(Math.Sqrt(n));
                }
            if (n != 1)
                factors.Add(n);
        }

        static void Main(string[] args)
        {
            InitializeErathostenesSieve(1000000);
            factors = new List<long>();
            long n;
            while ((n = long.Parse(Console.ReadLine())) != -1)
            {
                Facotorizate(n);
                foreach (long f in factors)
                    Console.WriteLine("    " + f);
                Console.WriteLine();
            }
        }
    }
}