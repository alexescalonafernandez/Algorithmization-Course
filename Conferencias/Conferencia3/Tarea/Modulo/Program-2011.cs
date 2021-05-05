using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo
{
    class Program
    {
        static void Main(string[] args)
        {
            int cant = int.Parse(Console.ReadLine()),m,sol,mod;
            bool[] arr = new bool[42];
            while (cant-- > 0)
            {
                sol = 0;
                m = 10;
                while(m-- > 0)
                    if (!arr[mod = int.Parse(Console.ReadLine()) % 42])
                    {
                        arr[mod] = true;
                        sol++;
                    }
                Console.WriteLine(sol);
                for (int i = 0; i < 42; i++)
                    arr[i] = false;
            }
        }
    }
}
