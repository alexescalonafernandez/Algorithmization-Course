using System;
using System.Collections.Generic;
using System.Text;

namespace Combinatorics
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[] fibonacci = new int[16];
            fibonacci[0] = fibonacci[1] = 1;
            for (int i = 2; i < 16; i++)
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 16; i++)
                sb.Append(fibonacci[i] + " ");
            Console.WriteLine(sb.ToString());*/
            /*StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 16; i++)
                sb.Append(CountingTechniques.CatalanNumber(i) + " ");
            Console.WriteLine(sb.ToString());
            sb.Remove(0,sb.Length);
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                sum += i;
                sb.Append(sum + " ");
            }
            Console.WriteLine(sb.ToString());*/
            Console.WriteLine(CountingTechniques.CombinationsWithoutRepetition(40, 35));
        }
    }
}
