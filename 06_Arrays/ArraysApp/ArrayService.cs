using System;

namespace ArraysApp
{
    /// <summary>
    /// Service für allgemeine Array-Operationen (Aufgabe 1-3).
    /// </summary>
    public static class ArrayService
    {
        private static readonly Random _random = new();

        /// <summary>
        /// Erstellt und füllt ein Array mit zufälligen Zahlen.
        /// </summary>
        /// <param name="length">Die Länge des Arrays.</param>
        /// <param name="min">Die inkludierte Untergrenze der Zufallszahlen.</param>
        /// <param name="max">Die exklusive Obergrenze der Zufallszahlen.</param>
        /// <returns>Ein gefülltes Integer-Array.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Wenn length negativ ist.</exception>
        public static int[] CreateRandomArray(int length, int min, int max)
        {
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
            
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = _random.Next(min, max);
            }
            return arr;
        }

        /// <summary>
        /// Berechnet die Quadratzahlen von 1 bis n.
        /// </summary>
        /// <param name="n">Die Anzahl der Quadratzahlen.</param>
        /// <returns>Ein Array mit den Quadraten.</returns>
        public static int[] GetSquares(int n)
        {
            int[] squares = new int[n];
            for (int i = 0; i < n; i++)
            {
                int num = i + 1;
                squares[i] = num * num;
            }
            return squares;
        }

        /// <summary>
        /// Kehrt die Reihenfolge eines neuen Arrays basierend auf dem Input um.
        /// </summary>
        /// <param name="input">Das Eingabearray.</param>
        /// <returns>Ein neues Array in umgekehrter Reihenfolge.</returns>
        public static int[] ReverseCopy(int[] input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            
            int[] reversed = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                reversed[i] = input[input.Length - 1 - i];
            }
            return reversed;
        }
    }
}
