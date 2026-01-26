using System;

namespace ArraysApp
{
    /// <summary>
    /// Service für Lottoc-Logik (Aufgabe 5).
    /// </summary>
    public static class LottoService
    {
        private static readonly Random _random = new();

        /// <summary>
        /// Zieht 6 zufällige, einzigartige Zahlen für "6 aus 49".
        /// </summary>
        /// <returns>
        /// Ein boolesches Array der Größe 50. 
        /// Der Index entspricht der gezogenen Zahl (true = gezogen).
        /// Index 0 wird ignoriert.
        /// </returns>
        public static bool[] DrawSixOutOfFortyNine()
        {
            bool[] drawn = new bool[50]; // 0-49
            int count = 0;

            while (count < 6)
            {
                int num = _random.Next(1, 50); // 1 bis 49
                if (!drawn[num])
                {
                    drawn[num] = true;
                    count++;
                }
            }
            return drawn;
        }
    }
}
