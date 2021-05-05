using System;
using System.Linq;

namespace AritmeticaPrimaria
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            char[] left, right;
            string[] arr;
            int maxLength, carry, sum, carryOperations;
            while ((line = Console.ReadLine()) != "0 0")
            {
                arr = line.Split();
                maxLength = arr.Max(e => e.Length);
                left = arr[0].PadLeft(maxLength - arr[0].Length, '0').ToCharArray();
                right = arr[1].PadLeft(maxLength - arr[1].Length, '0').ToCharArray();
                carry = carryOperations = 0;
                for (var i = maxLength - 1; i >= 0; i--)
                {
                    sum = (left[i] - '0') + (right[i] - '0') + carry;
                    carry = sum / 10;
                    if (carry > 0)
                        carryOperations++;
                }

                switch (carryOperations)
                {
                    case 0:
                        Console.WriteLine("No carry operation.");
                        break;
                    case 1:
                        Console.WriteLine("1 carry operation.");
                        break;
                    default:
                        Console.WriteLine($"{carryOperations} carry operations.");
                        break;
                }
            }
        }
    }
}
