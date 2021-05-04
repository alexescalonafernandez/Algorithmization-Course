using System;
using System.Collections.Generic;
using System.Text;

namespace JimmyAritmetica
{
    class Program
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());
            Stack<char> stack = new Stack<char>();
            string line;
            Dictionary<char,char> dict = new Dictionary<char,char>();
            dict.Add(')','(');
            dict.Add('}','{');
            dict.Add(']','[');
            bool validated;
            while (cases-- > 0)
            {
                stack.Clear();
                line = Console.ReadLine();
                validated = false;
                for (int i = 0; i < line.Length &&!validated; i++)
                {
                    if(line[i] == '(' || line[i] == '{' || line[i] == '[')
                        stack.Push(line[i]);
                    else if (line[i] == ')' || line[i] == '}' || line[i] == ']')
                    {
                        if (stack.Count == 0 || dict[line[i]] != stack.Peek())
                        {
                            Console.WriteLine("incorrecta");
                            Console.WriteLine("posicion del error:{0}", i + 1);
                            Console.WriteLine("no se esperaba un {0}", line[i]);
                            validated = true;
                        }
                        else stack.Pop();
                    }
                }
                if (!validated)
                {
                    if (stack.Count == 0)
                        Console.WriteLine("correcta");
                    else
                    {
                        Console.WriteLine("incorrecta");
                        Console.WriteLine("expresion incompleta");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
