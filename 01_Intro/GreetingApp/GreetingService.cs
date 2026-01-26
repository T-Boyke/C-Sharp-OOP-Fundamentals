using System;

namespace GreetingApp
{
    /// <summary>
    /// Stellt Funktionen für die Benutzerbegrüßung und Altersberechnung bereit.
    /// </summary>
    /// <remarks>
    /// Diese Klasse ist statisch und dient als reiner Service-Container ohne internen Zustand.
    /// Sie demonstriert die Trennung von Logik und UI (Separation of Concerns).
    /// </remarks>
    public static class GreetingService
    {
        /// <summary>
        /// Berechnet das Alter in Tagen basierend auf der Angabe in Jahren.
        /// </summary>
        /// <param name="ageInYears">Das Alter des Benutzers in vollen Jahren.</param>
        /// <returns>Das berechnete Alter in Tagen.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Wird geworfen, wenn das Alter kleiner als 0 oder unrealistisch hoch (größer 150) ist.
        /// </exception>
        /// <example>
        /// Beispiel zur Verwendung:
        /// <code>
        /// int days = GreetingService.CalculateDays(25);
        /// Console.WriteLine(days); // Ausgabe: 9125
        /// </code>
        /// </example>
        /// <remarks>
        /// Die Berechnung verwendet den Näherungswert von 365 Tagen pro Jahr.
        /// Schaltjahre werden in dieser Basis-Implementierung nicht berücksichtigt.
        /// </remarks>
        public static int CalculateDays(int ageInYears)
        {
            if (ageInYears < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ageInYears), "Das Alter darf nicht negativ sein.");
            }

            if (ageInYears > 150)
            {
                throw new ArgumentOutOfRangeException(nameof(ageInYears), "Das Alter ist unrealistisch hoch.");
            }

            return ageInYears * 365;
        }

        /// <summary>
        /// Generiert eine formatierte Begrüßungsnachricht.
        /// </summary>
        /// <param name="name">Der Name des Benutzers.</param>
        /// <param name="ageInYears">Das Alter in Jahren.</param>
        /// <returns>Ein formatierter String mit persönlicher Ansprache.</returns>
        /// <exception cref="ArgumentException">Wird geworfen, wenn der Name leer oder null ist.</exception>
        /// <seealso cref="CalculateDays(int)"/>
        public static string GetGreeting(string name, int ageInYears)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name darf nicht leer sein.", nameof(name));
            }

            int days = CalculateDays(ageInYears);
            return $"Hallo {name}! Du bist ca. {days} Tage alt.";
        }
    }
}
