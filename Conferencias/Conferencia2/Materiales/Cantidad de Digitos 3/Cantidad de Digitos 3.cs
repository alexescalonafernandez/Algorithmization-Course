using System;
using System.Collections.Generic;
using System.Text;

namespace CantidadDigitos3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());
            long n,commonFactor,rightOperand;
            while (cases-- > 0)
            {
                n = long.Parse(Console.ReadLine());
                commonFactor = n*(n-1);
                rightOperand = (commonFactor * (n - 2)) / 2;
                Console.WriteLine(commonFactor + rightOperand);
            }
        }
    }
}
