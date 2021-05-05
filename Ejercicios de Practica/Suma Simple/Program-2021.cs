using System;

namespace SumaSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            int n;
            while ((line = Console.ReadLine()) != null)
            {
                n = int.Parse(line.Trim());
                Console.WriteLine(n * (n + 1) / 2);
            }
        }
    }
}
