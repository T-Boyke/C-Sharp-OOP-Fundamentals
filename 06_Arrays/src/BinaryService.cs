using System;
using System.Collections.Generic;

namespace _06_Arrays.src
{
    /// <summary>
    /// Service für die Umrechnung von Zahlensystemen.
    /// </summary>
    public class BinaryService
    {
        /// <summary>
        /// Konvertiert eine Dezimalzahl (0-255) in ein 8-Bit-Binär-Array.
        /// </summary>
        /// <param name="decimalValue">Die Dezimalzahl (0-255).</param>
        /// <returns>Ein Integer-Array der Länge 8, das die Binärdarstellung enthält (Index 0 = MSB oder LSB? Wir wählen meist LSB at end or start? Task says "divisionsverfahren").
        /// Normalerweise: Index 0 = MSB (2^7) oder Index 7 = LSB (2^0).
        /// Wenn wir "1010..." lesen wollen von links nach rechts, sollte Index 0 das MSB sein.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">Wenn der Wert nicht zwischen 0 und 255 liegt.</exception>
        public int[] DecimalToBinary(int decimalValue)
        {
            if (decimalValue < 0 || decimalValue > 255)
            {
                throw new ArgumentOutOfRangeException(nameof(decimalValue), "Wert muss zwischen 0 und 255 liegen.");
            }

            int[] binary = new int[8];
            int tempValue = decimalValue;

            // Füllen von hinten (LSB bei Index 7), damit Ausgabe array[0]...array[7] korrekt aussieht (MSB links)
            // Oder Divisionsverfahren: 
            // 168 / 2 = 84 Rest 0 (LSB)
            // ...
            // Wir speichern rückwärts ein.
            
            for (int i = 7; i >= 0; i--)
            {
                binary[i] = tempValue % 2;
                tempValue /= 2;
            }

            return binary;
        }
    }
}
