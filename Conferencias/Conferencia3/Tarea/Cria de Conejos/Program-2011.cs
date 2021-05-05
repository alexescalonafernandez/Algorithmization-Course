using System;
using System.Collections.Generic;
using System.Text;

namespace CriaConejos
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[1000000 + 2];
            array[0] = array[1] = 1;
            for (int i = 2; i < array.Length; i++)
                array[i] = (array[i - 1] + array[i - 2]) % 300;
            int cases = int.Parse(Console.ReadLine()), n, month, rabbits;
            string[] arr;
            while (cases-- > 0)
            {
                arr = Console.ReadLine().Split();
                n = int.Parse(arr[0]);
                month = int.Parse(arr[1]) + 1;
                rabbits = (2 * n * array[month]) % 300;
                Console.WriteLine(rabbits);
            }
        }
    }
}