using System;
using System.Linq;

namespace SumaDigitos
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                Console.WriteLine(line.Trim().Select(e => e - '0').Sum());
            }
        }
    }
}
