using System;
using System.Linq;

namespace MultiplicacionJimmy
{
    class Program
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine()), secondSum;
            string[] arr;
            int[] first;
            while (cases-- > 0)
            {
                arr = Console.ReadLine().Split();
                first = arr[0].Select(c => c - '0').ToArray();
                secondSum = arr[1].Select(c => c - '0').Sum();
                Console.WriteLine(first.Sum(e => e * secondSum));

            }
        }
    }
}
