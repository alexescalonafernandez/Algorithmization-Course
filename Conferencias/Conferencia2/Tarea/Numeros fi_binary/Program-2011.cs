using System;
using System.Collections.Generic;
using System.Text;

namespace NumerosFibinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = new int[43];
            fibonacci[0] = fibonacci[1] = 1;
            for (int i = 2; i < 43; i++)
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            Stack<int> stack = new Stack<int>();
            int cases = int.Parse(Console.ReadLine()), n, ptr;
            StringBuilder builder = new StringBuilder();
            while (cases-- > 0)
            {
                n = int.Parse(Console.ReadLine());
                while (n > 0)
                {
                    ptr = 0;
                    while (n > fibonacci[ptr])
                        n -= fibonacci[ptr++];
                    stack.Push(ptr);
                    n--;
                }
                ptr = 0;
                builder.Remove(0, builder.Length);
                while (stack.Count != 0)
                {
                    if (stack.Peek() == ptr++)
                    {
                        builder.Insert(0, '1');
                        stack.Pop();
                    }
                    else builder.Insert(0, '0');
                }
                Console.WriteLine(builder.ToString());
            }
        }
    }
}