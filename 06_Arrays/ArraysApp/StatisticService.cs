using System;

namespace ArraysApp
{
    /// <summary>
    /// Speichert statistische Ergebnisse.
    /// </summary>
    /// <param name="Min">Kleinster Wert.</param>
    /// <param name="Max">Größter Wert.</param>
    /// <param name="Sum">Summe der Werte.</param>
    /// <param name="Average">Durchschnitt.</param>
    public record ArrayStatistics(int Min, int Max, int Sum, double Average);

    /// <summary>
    /// Service zur Berechnung von Array-Statistiken (Aufgabe 4).
    /// </summary>
    public static class StatisticService
    {
        /// <summary>
        /// Berechnet Statistiken für ein Integer-Array.
        /// </summary>
        /// <param name="numbers">Das Eingabearray.</param>
        /// <returns>Ein <see cref="ArrayStatistics"/> Objekt.</returns>
        /// <exception cref="ArgumentException">Wenn das Array leer oder null ist.</exception>
        public static ArrayStatistics Calculate(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                throw new ArgumentException("Array darf nicht leer sein.", nameof(numbers));

            int min = numbers[0];
            int max = numbers[0];
            int sum = 0;

            foreach (int n in numbers)
            {
                if (n < min) min = n;
                if (n > max) max = n;
                sum += n;
            }

            double avg = (double)sum / numbers.Length;

            return new ArrayStatistics(min, max, sum, avg);
        }
    }
}
