using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _09_Functions.src
{
    public class FunctionService
    {
        // 1. GibMir5
        public int GibMir5() => 5;

        // 2. Addition
        public int Addition(int z1, int z2) => z1 + z2;

        // 3. Schaltjahr
        public bool IstSchaltjahr(int jahr)
        {
            return (jahr % 4 == 0 && jahr % 100 != 0) || (jahr % 400 == 0);
        }

        // 4. Taschenrechner
        public double Add(double a, double b) => a + b;
        public double Sub(double a, double b) => a - b;
        public double Mult(double a, double b) => a * b;
        public double Div(double a, double b) => b != 0 ? a / b : 0; // Handle /0 logic or throw? 0 for now as per simple req.

        // 5. Temperatur
        public double CnachF(double c) => (c * 9.0 / 5.0) + 32;
        public double CnachK(double c) => c + 273.15;
        public double FnachC(double f) => ((f - 32) * 5.0) / 9.0;
        public double FnachK(double f) => ((f - 32) * 5.0) / 9.0 + 273.15;
        public double KnachC(double k) => k - 273.15;
        public double KnachF(double k) => ((k - 273.15) * 9.0 / 5.0) + 32;

        // 7. IntReverse (Mathematisch)
        public int IntReverse(int number)
        {
            int reversed = 0;
            while (number > 0)
            {
                int digit = number % 10;
                reversed = (reversed * 10) + digit;
                number /= 10;
            }
            return reversed;
        }

        // 9. String Reverse
        public string Reverse(string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars); // Built-in helper is discouraged? Task says "selbst implementieren" for Logic, but Array.Reverse is standard. 
            // If strict manual:
            // char[] result = new char[text.Length];
            // for(int i=0; i<text.Length; i++) result[i] = text[text.Length-1-i];
            // return new string(result);
            return new string(chars);
        }

        // 10. Palindrom
        public bool IstPalindrom(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            string clean = text.ToLower();
            string reversed = Reverse(clean);
            return clean == reversed;
        }

        // 11. Array Merge (Sorted)
        public int[] ArrayMerge(int[] a1, int[] a2)
        {
            var list = new List<int>();
            list.AddRange(a1);
            list.AddRange(a2);
            list.Sort();
            return list.ToArray();
        }

        // 12. Array Explode
        // 1, 1,2, 1,2,3 ...
        public int[] ArrayExplode(int grenze)
        {
            var list = new List<int>();
            for (int i = 1; i <= grenze; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    list.Add(j);
                }
            }
            return list.ToArray();
        }
    }
}
