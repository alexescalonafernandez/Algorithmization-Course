using System;
using System.Linq;

namespace Digital
{
    class Program
    {
        static void Main(string[] args)
        {
            string number;
            while ((number = Console.ReadLine()) != null)
            {
                while (number.Length > 1)
                {
                    number = $"{number.Select(e => e - '0').Sum()}";
                }
                Console.WriteLine(number);
            }
        }
    }
}
