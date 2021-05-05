using System;
using System.Collections.Generic;
using System.Text;

namespace Bishop
{
    class Program
    {
        static void Main(string[] args)
        {
            int cant = int.Parse(Console.ReadLine()),n;
            while (cant-- > 0)
            {
                n = int.Parse(Console.ReadLine());
                if (n == 0)
                    Console.WriteLine(0);
                else if (n == 1)
                    Console.WriteLine(1);
                else Console.WriteLine(n + (n - 2));
            }

        }
    }
}
