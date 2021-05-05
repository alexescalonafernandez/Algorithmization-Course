using System;
using System.Collections.Generic;
using System.Text;

namespace Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] fib = new long[500];
            fib[0] = fib[1] = 1;
            for (int i = 2; i < fib.Length; i++)
                fib[i] = fib[i - 1] + fib[i - 2];
            int cant = int.Parse(Console.ReadLine()), c;
            while (cant-- > 0)
            {
                c = int.Parse(Console.ReadLine());
                Console.WriteLine(string.Format("{0} {1} {2}", fib[c - 3], fib[c - 2], fib[c - 1]));
            }
        }
    }
}