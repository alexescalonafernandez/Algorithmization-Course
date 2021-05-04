using System;
using System.Collections.Generic;
using System.Text;

namespace Perfil
{
    class Program
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine()), n, sol, y;
            Stack<int> heigth = new Stack<int>();
            while (cases-- > 0)
            {
                n = int.Parse(Console.ReadLine().Split(' ')[0]);
                heigth.Clear();
                heigth.Push(sol = 0);
                while(n-- > 0)
                {
                    y = int.Parse(Console.ReadLine().Split(' ')[1]);
                    while (heigth.Peek() > y)
                        heigth.Pop();
                    if (y > heigth.Peek())
                    {
                        sol++;
                        heigth.Push(y);
                    }
                }
                Console.WriteLine(sol);
            }
        }
    }
}
