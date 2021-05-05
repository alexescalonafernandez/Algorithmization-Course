using System;
using System.Collections.Generic;
using System.Text;

namespace Towers
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] factorial = new long[21];
            factorial[0] = factorial[1] = 1;
            for (int i = 2; i < 21; i++)
                factorial[i] = i * factorial[i - 1];
            int cases = int.Parse(Console.ReadLine());
            while (cases-- > 0)
                Console.WriteLine(factorial[int.Parse(Console.ReadLine())]);
        }
    }
}
