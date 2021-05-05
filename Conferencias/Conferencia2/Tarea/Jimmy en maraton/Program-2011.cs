using System;
using System.Collections.Generic;
using System.Text;

namespace JimmyMaraton
{
    class Program
    {
        static int[] permutation = new int[15];
        static long sol;
        static long GCD(long a, long b)
        {
            while (b > 0)
            {
                a %= b;
                if (a != b)
                {
                    a ^= b;
                    b ^= a;
                    a ^= b;
                }
            }
            return a;
        }

        static long EfficientDivideOfFactorials(long n, long[] factorialsDivisors)
        {
            Array.Sort(factorialsDivisors);
            long numerator = 1, denominator = 1;
            long gcd;
            int ptr = factorialsDivisors.Length - 1;
            while (ptr >= 0)
            {
                gcd = GCD(n, factorialsDivisors[ptr]);
                numerator *= n / gcd;
                denominator *= factorialsDivisors[ptr] / gcd;
                if ((gcd = GCD(numerator, denominator)) != 1)
                {
                    numerator /= gcd;
                    denominator /= gcd;
                }
                n--;
                if (--factorialsDivisors[ptr] == 0)
                    ptr--;
            }
            return numerator / denominator;
        }

        static void Calculate(int n, int length)
        {
            long[] factorialsDivisors = new long[length + 1];
            List<int> elements = new List<int>();
            List<long> repetitions = new List<long>();
            int index = -1;
            for (int i = 0; i <= length; i++)
            {
                factorialsDivisors[i] = permutation[i];
                if ((index = elements.IndexOf(permutation[i])) == -1)
                {
                    elements.Add(permutation[i]);
                    repetitions.Add(1);
                }
                else repetitions[index]++;
            }
            sol += EfficientDivideOfFactorials(n, factorialsDivisors) * EfficientDivideOfFactorials(length + 1, repetitions.ToArray());
        }

        static void R(int n)
        {
            for (int k1 = 1, add1 = 0; add1 + k1 <= n; k1++)
            {
                permutation[0] = k1;
                if (add1 + k1 == n) 
                    Calculate(n,0);
                for (int k2 = k1, add2 = add1 + k1; add2 + k2 <= n; k2++)
                {
                    permutation[1] = k2;
                    if (add2 + k2 == n) 
                        Calculate(n,1);
                    for (int k3 = k2, add3 = add2 + k2; add3 + k3 <= n; k3++)
                    {
                        permutation[2] = k3;
                        if (add3 + k3 == n)
                            Calculate(n, 2);
                        for (int k4 = k3, add4 = add3 + k3; add4 + k4 <= n; k4++)
                        {
                            permutation[3] = k4;
                            if (add4 + k4 == n)
                                Calculate(n, 3);
                            for (int k5 = k4, add5 = add4 + k4; add5 + k5 <= n; k5++)
                            {
                                permutation[4] = k5;
                                if (add5 + k5 == n)
                                    Calculate(n, 4);
                                for (int k6 = k5, add6 = add5 + k5; add6 + k6 <= n; k6++)
                                {
                                    permutation[5] = k6;
                                    if (add6 + k6 == n)
                                        Calculate(n, 5);
                                    for (int k7 = k6, add7 = add6 + k6; add7 + k7 <= n; k7++)
                                    {
                                        permutation[6] = k7;
                                        if (add7 + k7 == n)
                                            Calculate(n, 6);
                                        for (int k8 = k7, add8 = add7 + k7; add8 + k8 <= n; k8++)
                                        {
                                            permutation[7] = k8;
                                            if (add8 + k8 == n)
                                                Calculate(n, 7);
                                            for (int k9 = k8, add9 = add8 + k8; add9 + k9 <= n; k9++)
                                            {
                                                permutation[8] = k9;
                                                if (add9 + k9 == n)
                                                    Calculate(n, 8);
                                                for (int k10 = k9, add10 = add9 + k9; add10 + k10 <= n; k10++)
                                                {
                                                    permutation[9] = k10;
                                                    if (add10 + k10 == n)
                                                        Calculate(n, 9);
                                                    for (int k11 = k10, add11 = add10 + k10; add11 + k11 <= n; k11++)
                                                    {
                                                        permutation[10] = k11;
                                                        if (add11 + k11 == n)
                                                            Calculate(n, 10);
                                                        for (int k12 = k11, add12 = add11 + k11; add12 + k12 <= n; k12++)
                                                        {
                                                            permutation[11] = k12;
                                                            if (add12 + k12 == n)
                                                                Calculate(n, 11);
                                                            for (int k13 = k12, add13 = add12 + k12; add13 + k13 <= n; k13++)
                                                            {
                                                                permutation[12] = k13;
                                                                if (add13 + k13 == n)
                                                                    Calculate(n, 12);
                                                                for (int k14 = k13, add14 = add13 + k13; add14 + k14 <= n; k14++)
                                                                {
                                                                    permutation[13] = k14;
                                                                    if (add14 + k14 == n)
                                                                        Calculate(n, 13);
                                                                    for (int k15 = k14, add15 = add14 + k14; add15 + k15 <= n; k15++)
                                                                    {
                                                                        permutation[14] = k15;
                                                                        if (add15 + k15 == n)
                                                                            Calculate(n, 14);

                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            long[] cache = new long[15];
            for (int i = 1; i <= 15; i++)
            {
                sol = 0;
                R(i);
                cache[i - 1] = sol;
            }
            int cases = int.Parse(Console.ReadLine());
            while (cases-- > 0)
                Console.WriteLine(cache[int.Parse(Console.ReadLine()) - 1]);
        }
    }
}
