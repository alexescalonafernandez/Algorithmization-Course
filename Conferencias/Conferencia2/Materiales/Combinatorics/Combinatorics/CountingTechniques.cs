using System;
using System.Collections.Generic;
using System.Text;

namespace Combinatorics
{
    class CountingTechniques
    {
        private static long GCD(long a, long b)
        {
            while (b > 0)
            {
                a %= b;
                Swap(ref a, ref b);
            }
            return a;
        }

        private static void Swap(ref long a, ref long b)
        {
            if (a != b)
            {
                a ^= b;
                b ^= a;
                a ^= b;
            }
        }

        /* Calcula n!/(f1!*f2!*...*fn!) tratando de evitar un overflow tanto en
         * el numerado como en el denominador ideal cuando se asegura que el resultado
         * de la operación se encuentra dentro del rango de un long.
         * */
        private static long EfficientDivideOfFactorials(long n, long[] factorialsDivisors)
        {
            if (n == 0)
                return 1;
            //ordena ascendente
            Array.Sort(factorialsDivisors);
            long numerator = 1, denominator = 1;
            long gcd;
            int ptr = 0;
            while (ptr < factorialsDivisors.Length && factorialsDivisors[ptr] == 0)
                factorialsDivisors[ptr++] = 1;
            ptr = factorialsDivisors.Length - 1;
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

        private static long Factorial(long n)
        {
            if (n == 0)
                return 1;
            else
            {
                long fact = 1;
                while (n > 1)
                    fact *= n--;
                return fact;
            }
        }

        /* Ejemplo: subconjuntos posible de a,b,c son:
         * {a,b,c}
         * {a,b}
         * {a,c}
         * {b,c}
         * {a}
         * {b}
         * {c}
         * {}
         * Se cumple que para n elementos la cantidad de subconjuntos es pow(2,n)
         * */
        public static long SubsetInN(int n)
        {
            return (long)Math.Pow(2, n);
        }

        /* Variaciones sin repetición de n elementos tomados de r en r se define como 
         * las distintas agrupaciones formadas con r elementos distintos de los n
         * posibles, considerendo una variación distinta a otra si difieren en algún
         * elemento como si están situados en distinto orden. La fórmula para calcular
         * V(n,r) = n!/(n-r)!
         * Ejemplo V(3,2) de a,b,c
         * {a,b},{a,c},{b,c},
         * {b,a},{c,a},{c,b}
         */
        public static long VariationsWithoutRepetitions(long n, long r)
        {
            if (r == 0)
                return 1;
            else if (r == 1)
                return n;
            else if (r == n)
                return Factorial(n);
            else return EfficientDivideOfFactorials(n, new long[] { n - r });
        }

        /* Variaciones con repetición de n elementos tomados de r en r se define como
         * las distintas agrupaciones formadas con r elementos que pueden repetirse
         * elegidos entre los n posibles, considerando una variación distinta a otra
         * si difiere en algún elemento, como si esta situado en distinto orden. La
         * fórmula para calcular VR(n,r) = pow(n,r)
         * Ejemplo VR(3,2) de a,b,c
         * {a,b},{a,c},{b,c},
         * {b,a},{c,a},{c,b},
         * {a,a},{b,b},{c,c}
         */
        public static long VariationsWithRepetitions(long n, long r)
        {
            return (long)Math.Pow(n, r);
        }

        /* Permutación sin repetición de n elementos se define como las distintas
         * agrupaciones de n elementos, considerandose una permutación distinta a 
         * otra si existe al menos un elemento en distinta posición. La fórmula para
         * calcular Pn = n!
         * Ejemplo: Pn(3) de a,b,c
         * {a,b,c},{a,c,b},
         * {b,a,c},{b,c,a},
         * {c,a,b},{c,b,a}
         * */
        public static long PermutationsWithoutRepetition(long n)
        {
            return Factorial(n);
        }

        /* Permutación con repetición de m elementos donde el primero se repite a veces,
         * el segundo b veces, el tercero c veces, ... (n = a+b+c+...) se definen como
         * los distintos grupos de n elementos, siendo uno distinto al otro 
         * por el orden de los elementos. La fórmula para calcular PR(n,a,b,c,...) = 
         * n!/(a!*b!*c!*...)
         * Ejemplo PR(4,2,1,1) de a,a,b,c
         * {a,a,b,c},{a,b,a,c},{a,b,c,a},
         * {a,a,c,b},{a,c,a,b},{a,c,b,a},
         * {b,a,a,c}, {b,a,c,a},{b,c,a,a},
         * {c,a,a,b},{c,a,b,a},{c,b,a,a}
         * */
        public static long PermutationsWithRepetition(long[] repetitions)
        {
            List<long> elements = new List<long>();
            long n = 0;
            foreach (long e in repetitions)
            {
                if (e <= 0)
                    throw new Exception("The repetition factor must be > 0");
                else
                {
                    if (e != 1)
                        elements.Add(e);
                    n += e;
                }
            }
            if (elements.Count == 0)
                return Factorial(n);
            else return EfficientDivideOfFactorials(n, elements.ToArray());
        }

        /* Combinación sin repetición de n elementos tomados de r en r son las distintas
         * agrupaciones de r elementos que se pueden hacer de los n disponibles, de 
         * manera que dos grupos se difieren en algún elemento y no en el orden de
         * colocación. La formula para calcular C(n,r) = n!/(r!*(n-r)!)
         * Ejemplo C(3,2) de a,b,c
         * {a,b},{a,c},{b,c}
         * */
        public static long CombinationsWithoutRepetition(long n, long r)
        {
            if (r == 0 || r == n)
                return 1;
            else if (r == 1)
                return n;
            else return EfficientDivideOfFactorials(n, new long[] { r, n - r });
        }

        /* Combinación con repetición de n elementos tomados de r en r son los distintos
         * grupos de r elementos iguales o disitintos que se pueden hacer con los n
         * elementos de manera que 2 grupos se diferencian en algún elemento y no en el
         * orden de colocación. La fórmula para calcular CR(n,r) = (n+r-1)!/(r!*(n-1)!)
         * Ejemplo CR(3,2) de a,b,c
         * {a,b},{a,c},{b,c},
         * {a,a},{b,b},{c,c}
         * */
        public static long CombinationsWithRepetition(int n, int r)
        {
            if (r == 0)
                return 1;
            else if (r == 1)
                return n;
            else return EfficientDivideOfFactorials(n + r - 1, new long[] { r, n - 1 });
        }

        /* Formula (1/(n+1))*C(2n,n) = (1/(n+1))*((2*n)!/(n!*n!))
         * */
        public static long CatalanNumber(long n)
        {
            return EfficientDivideOfFactorials(2 * n, new long[] { n, n }) / (n + 1);
        }
    }
}
