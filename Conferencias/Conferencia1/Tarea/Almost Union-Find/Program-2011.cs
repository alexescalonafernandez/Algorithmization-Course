using System;
using System.Collections.Generic;
using System.Text;

namespace AlmostUnionFind
{
    class Program
    {
        static List<List<int>> set;

        static int IndexOf(int n)
        {
            for(int i = set.Count-1; i >= 0; i--)
                if(set[i].Contains(n))
                    return i;
            return -1;
        }
        static void Main(string[] args)
        {
            set = new List<List<int>>();
            int n, m, pIndex, qIndex, sum;
            string str;
            string[] arr;
            while ((str = Console.ReadLine()) != null)
            {
                arr = str.Split();
                set.Clear();
                n = int.Parse(arr[0]);
                m = int.Parse(arr[1]);
                for (int i = 0; i < n; i++)
                    set.Add(new List<int>(new int[] { i + 1 }));
                while (m-- > 0)
                {
                    arr = Console.ReadLine().Split();
                    pIndex = IndexOf(int.Parse(arr[1]));
                    if (arr[0] == "3")
                    {
                        sum = 0;
                        foreach (int v in set[pIndex])
                            sum += v;
                        Console.WriteLine(set[pIndex].Count + " " + sum);
                    }
                    else
                    {
                        qIndex = IndexOf(int.Parse(arr[2]));
                        if (pIndex != qIndex)
                        {
                            if (arr[0] == "1")
                            {
                                set[pIndex].AddRange(set[qIndex]);
                                set.RemoveAt(qIndex);
                            }
                            else
                            {
                                set[qIndex].Add(int.Parse(arr[1]));
                                set[pIndex].Remove(int.Parse(arr[1]));
                            }
                        }
                    }
                }
            }
        }
    }
}
