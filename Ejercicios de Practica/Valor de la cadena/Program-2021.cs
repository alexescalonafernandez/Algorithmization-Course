using System;
using System.Linq;

namespace ValorCadena
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                Console.WriteLine(line.Select(e => (int) e).Sum());
            }
        }
    }
}
