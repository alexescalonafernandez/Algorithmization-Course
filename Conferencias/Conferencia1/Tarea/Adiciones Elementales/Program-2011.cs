using System;
using System.Collections.Generic;
using System.Text;

namespace AdicionesElementales
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = new List<string>();
            elements.Add("{}");
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= 15; i++)
            {
                sb.Remove(0, sb.Length);
                sb.Append('{');
                for (int j = 0; j < i; j++)
                    sb.Append(elements[j] + ",");
                sb.Remove(sb.Length - 1, 1);
                sb.Append('}');
                elements.Add(sb.ToString());
            }
            int cases = int.Parse(Console.ReadLine()), ptr, counter;
            string s;
            int[] indexes = new int[2];
            while (cases-- > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    counter = 0;
                    s = Console.ReadLine();
                    ptr = s.Length - 1;
                    while (s[ptr--] == '}')
                        counter++;
                    indexes[i] = counter - 1;
                }
                Console.WriteLine(elements[indexes[0] + indexes[1]]);
            }
        }
    }
}
