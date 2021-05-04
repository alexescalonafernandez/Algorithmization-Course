using System;
using System.Collections.Generic;
using System.Text;

namespace Tunel
{
    class Program
    {
        static Queue<string> GetCars(int n)
        {
            Queue<string> queue = new Queue<string>();
            while (n-- > 0)
                queue.Enqueue(Console.ReadLine());
            return queue;
        }
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine()),n;
            Queue<string> before, after;
            List<string> speedUp = new List<string>();
            string car, s;
            while (cases-- > 0)
            {
                n = int.Parse(Console.ReadLine());
                before = GetCars(n);
                after = GetCars(n);
                speedUp.Clear();
                while (before.Count != 0)
                {
                    car = before.Dequeue();
                    if (!speedUp.Contains(car))
                    {
                        while (after.Peek() != car)
                            speedUp.Add(after.Dequeue());
                        after.Dequeue();
                    }
                }
                Console.WriteLine(speedUp.Count);
            }
        }
    }
}
