using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionsApp.Services
{
    public static class ArrayFunctionService
    {
        /// <summary>
        /// Verbindet zwei Arrays zu einem sortierten Array.
        /// </summary>
        public static int[] ArrayMerge(int[] arr1, int[] arr2)
        {
            // LINQ für Clean Code (Alternative: Neue Array größe berechnen, Kopieren, Sortieren)
            var result = arr1.Concat(arr2).ToArray();
            Array.Sort(result);
            return result;
        }

        /// <summary>
        /// Erzeugt explodierende Sequenz: 1, 1,2, 1,2,3 ...
        /// </summary>
        public static int[] ArrayExplode(int limit)
        {
            if (limit < 1) return Array.Empty<int>();

            var list = new List<int>();
            for (int i = 1; i <= limit; i++)
            {
                // Für jede Zahl i hängen wir 1..i an
                for (int j = 1; j <= i; j++)
                {
                    list.Add(j);
                }
            }
            return list.ToArray();
        }
    }
}
