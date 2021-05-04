using System;
using System.Collections.Generic;
using System.Text;

namespace ConjuntosAnagramas
{
    class Program
    {
        static int[] getCharCounter(string s)
        {
            int[] array = new int[52];
            foreach (char c in s)
            {
                if (char.IsUpper(c))
                    array[c - 'A' + 26]++;
                else array[c - 'a']++;
            }
            return array;
        }

        static bool Compare(int[] pivotCounter, int[] currentCounter)
        {
            for (int i = 0; i < 52; i++)
                if (pivotCounter[i] != currentCounter[i])
                    return false;
            return true;
        }

        static void Main(string[] args)
        {
            string line;
            string[] arr;
            List<List<string>> dict = new List<List<string>>();
            StringBuilder sb = new StringBuilder();
            bool[] mark;
            int[] pivotCounter;
            while ((line = Console.ReadLine()) != "0")
            {
                arr = line.Trim().Split();
                mark = new bool[arr.Length];
                dict.Clear();
                for (int i = 0; i < arr.Length; mark[i] = true, i++)
                    if (!mark[i])
                    {
                        dict.Add(new List<string>(new string[] { arr[i] }));
                        pivotCounter = getCharCounter(arr[i]);
                        for (int j = i + 1; j < arr.Length; j++)
                        {
                            if(!mark[j] && arr[i].Length == arr[j].Length)
                                if(Compare(pivotCounter,getCharCounter(arr[j])))
                                {
                                    mark[j] = true;
                                    dict[dict.Count - 1].Add(arr[j]);
                                }
                        }
                    }

                foreach (List<string> ls in dict)
                {
                    sb.Remove(0, sb.Length);
                    foreach (string s in ls)
                        sb.Append(s + "-");
                    sb.Remove(sb.Length - 1, 1);
                    Console.WriteLine(sb.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
