using System;
using System.Collections.Generic;
using System.Linq;

namespace VerballySuccessiveSequence
{
    class Program
    {
        class Token
        {
            public char Value { get; set; }
            public int Count { get; set; }
        }
        static void Main(string[] args)
        {
            var cases = int.Parse(Console.ReadLine());
            char[] arr;
            Token current;
            while (cases-- > 0)
            {
                arr = Console.ReadLine().Trim().ToCharArray();
                current = null;
                var tokens = new List<Token>();
                for (var i = 0; i < arr.Length; i++)
                {
                    if (i == 0)
                    {
                        current = new Token
                        {
                            Value = arr[i],
                            Count = 1
                        };
                    }
                    else if (current?.Value == arr[i])
                    {
                        current.Count++;
                    }
                    else
                    {
                        tokens.Add(current);
                        current = new Token
                        {
                            Value = arr[i],
                            Count = 1
                        };
                    }
                }
                tokens.Add(current);
                var solution = string.Join("", tokens.Select(e => $"{e.Count}{e.Value}"));
                Console.WriteLine(solution);
            }
        }
    }
}
