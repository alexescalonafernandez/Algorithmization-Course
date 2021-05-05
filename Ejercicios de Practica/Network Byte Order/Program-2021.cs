using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkByteOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();
            var cases = int.Parse(Console.ReadLine());
            while (cases-- > 0)
            {
                foreach (var e in Console.ReadLine().Trim().Split())
                {
                    var sb = new StringBuilder();
                    var n = int.Parse(e);
                    while (n > 0)
                    {
                        sb.Insert(0, n % 2);
                        n /= 2;
                    }
                    stack.Push(sb.ToString().PadLeft(8, '0'));
                }
                var reverse = new StringBuilder();
                while (stack.Count > 0)
                {
                    reverse.Append(stack.Pop());
                }
                Console.WriteLine(reverse.ToString());
            }
        }
    }
}
