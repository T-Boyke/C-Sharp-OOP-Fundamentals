using System;

namespace ArraysApp
{
    /// <summary>
    /// Service für Binäroperationen (Aufgabe 6).
    /// </summary>
    public static class BinaryService
    {
        /// <summary>
        /// Konvertiert eine Dezimalzahl (0-255) in ein binäres Array (8 Bit).
        /// </summary>
        /// <param name="number">Die Dezimalzahl.</param>
        /// <returns>Ein Array der Länge 8 (0 oder 1), Index 0 ist MSB (Most Significant Bit) oder LSB je nach Interpretation. Hier: Index 7 ist LSB (2^0).</returns>
        /// <remarks>
        /// Wir füllen das Array so, dass Index 7 das niederwertigste Bit (1er) ist.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Bei Zahlen > 255 oder < 0.</exception>
        public static int[] ToBinary8Bit(int number)
        {
            if (number < 0 || number > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Zahl muss zwischen 0 und 255 liegen (8 Bit).");
            }

            int[] binary = new int[8];
            
            // Konvertierung durch wiederholte Division / Modulo
            // Wir füllen von hinten (Index 7) nach vorne (Index 0)
            for (int i = 7; i >= 0; i--)
            {
                binary[i] = number % 2;
                number /= 2;
            }

            return binary;
        }
    }
}
