using System;

namespace MethodPlayground
{
    /// <summary>
    /// Eine Hilfsklasse für mathematische Operationen Demonstration von Methoden-Parametern.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// Berechnet die Potenz einer Basiszahl.
        /// </summary>
        /// <param name="baseNum">Die Basis.</param>
        /// <param name="exp">Der Exponent (muss >= 0 sein).</param>
        /// <returns>Das Ergebnis von baseNum ^ exp.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Exponent negativ ist.</exception>
        public static long CalculatePower(int baseNum, int exp)
        {
            if (exp < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(exp), "Exponent darf nicht negativ sein.");
            }

            if (exp == 0) return 1;
            if (baseNum == 0) return 0;

            long result = 1;
            for (int i = 0; i < exp; i++)
            {
                result *= baseNum;
            }
            return result;
        }

        /// <summary>
        /// Ermittelt Minimum und Maximum aus einem Array.
        /// </summary>
        /// <param name="numbers">Das Array mit Zahlen.</param>
        /// <param name="min">Gibt das gefundene Minimum zurück.</param>
        /// <param name="max">Gibt das gefundene Maximum zurück.</param>
        /// <exception cref="ArgumentException">Wenn das Array leer oder null ist.</exception>
        /// <remarks>
        /// Verwendet den <c>out</c> Modifizierer, um mehrere Werte zurückzugeben.
        /// </remarks>
        public static void GetStatistics(int[] numbers, out int min, out int max)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Array darf nicht leer sein.", nameof(numbers));
            }

            min = numbers[0];
            max = numbers[0];

            foreach (int num in numbers)
            {
                if (num < min) min = num;
                if (num > max) max = num;
            }
        }

        /// <summary>
        /// Tauscht die Werte zweier Variablen.
        /// </summary>
        /// <param name="a">Referenz auf die erste Variable.</param>
        /// <param name="b">Referenz auf die zweite Variable.</param>
        /// <remarks>
        /// Verwendet den <c>ref</c> Modifizierer, um die Originalvariablen zu ändern.
        /// </remarks>
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
