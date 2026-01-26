using System;

namespace ConverterApp
{
    /// <summary>
    /// Stellt Konvertierungsfunktionen für physikalische und monetäre Einheiten bereit.
    /// </summary>
    public static class ConverterService
    {
        /// <summary>
        /// Konvertiert eine Temperatur von Celsius in Fahrenheit.
        /// </summary>
        /// <param name="celsius">Die Temperatur in Grad Celsius.</param>
        /// <returns>Die Temperatur in Grad Fahrenheit.</returns>
        /// <remarks>
        /// Die Formel lautet: (Celsius * 9/5) + 32.
        /// Wir nutzen 9.0/5.0 um eine Gleitkommadivision zu erzwingen.
        /// </remarks>
        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9.0 / 5.0) + 32;
        }

        /// <summary>
        /// Konvertiert einen Euro-Betrag in US-Dollar.
        /// </summary>
        /// <param name="euro">Der Betrag in Euro.</param>
        /// <returns>Der Betrag in USD.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Wird geworfen, wenn der Betrag negativ ist.</exception>
        /// <remarks>
        /// Verwendet einen festen Umrechnungskurs von 1.10.
        /// Finanzberechnungen *müssen* <see cref="decimal"/> verwenden, um Rundungsfehler zu vermeiden.
        /// </remarks>
        public static decimal EuroToDollar(decimal euro)
        {
            if (euro < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(euro), "Geldbeträge dürfen nicht negativ sein.");
            }

            const decimal exchangeRate = 1.10m;
            return Math.Round(euro * exchangeRate, 2);
        }

        /// <summary>
        /// Rechnet eine Gesamtanzahl von Minuten in Stunden und verbleibende Minuten um.
        /// </summary>
        /// <param name="totalMinutes">Die Gesamtanzahl der Minuten.</param>
        /// <returns>Ein Tupel bestehend aus (Stunden, Minuten).</returns>
        /// <example>
        /// <code>
        /// var result = ConverterService.MinutesToHoursAndMinutes(150);
        /// Console.WriteLine($"{result.hours}h {result.minutes}m"); // 2h 30m
        /// </code>
        /// </example>
        public static (int hours, int minutes) MinutesToHoursAndMinutes(int totalMinutes)
        {
            if (totalMinutes < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(totalMinutes), "Zeit kann nicht negativ sein.");
            }

            int hours = totalMinutes / 60;   // Ganzzahldivision
            int minutes = totalMinutes % 60; // Modulo für den Rest

            return (hours, minutes);
        }
    }
}
