using System;
using System.Collections.Generic;
using System.Text;

namespace NumerosPrimos
{
    class Program
    {
        static bool[] composites;

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

        static void Main(string[] args)
        {
            InitializeErathostenesSieve(1000000);
            int cases = int.Parse(Console.ReadLine()), n;
            bool flag;
            while (cases-- > 0)
            {
                n = int.Parse(Console.ReadLine());
                flag = true;
                while (flag && n > 0)
                {
                    flag = !composites[n];
                    n /= 10;
                }
                Console.WriteLine(flag ? "SI" : "NO");
            }
        }
    }
}