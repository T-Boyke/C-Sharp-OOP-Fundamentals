using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp.Services
{
    /// <summary>
    /// Stellt Funktionen zur Aggregation (Berechnung von Kennzahlen) bereit.
    /// Beinhaltet Summen-, Durchschnitts-, Minimum- und Maximum-Berechnungen.
    /// </summary>
    public class AggregationService
    {
        // Datenbasis aus Aufgabe Aggregation
        private readonly int[] _numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

        /// <summary>
        /// Gibt die Datenbasis zurück.
        /// </summary>
        /// <returns>Array mit Ganzzahlen.</returns>
        public int[] GetNumbers() => _numbers;

        // --- a. Summe aller Werte ---

        /// <summary>
        /// Berechnet die Summe aller Elemente im Array.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Die Summe als Integer.</returns>
        public int GetSum(int[] input)
        {
            // Sum() addiert alle Elemente auf.
            return input.Sum();
        }

        // --- b. Die kleinste Zahl ---

        /// <summary>
        /// Ermittelt den kleinsten Wert im Array.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Der kleinste Wert.</returns>
        public int GetMin(int[] input)
        {
            // Min() sucht das Element mit dem geringsten Wert.
            return input.Min();
        }

        // --- c. Die größte Zahl ---

        /// <summary>
        /// Ermittelt den größten Wert im Array.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Der größte Wert.</returns>
        public int GetMax(int[] input)
        {
            // Max() sucht das Element mit dem höchsten Wert.
            return input.Max();
        }

        // --- d. Der Durchschnittswert ---

        /// <summary>
        /// Berechnet den arithmetischen Mittelwert.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Der Durchschnitt als Double.</returns>
        public double GetAverage(int[] input)
        {
            // Average() berechnet den Durchschnitt. Rückgabetyp ist bei int-Input immer double.
            return input.Average();
        }

        // --- e. Die kleinste gerade Zahl ---

        /// <summary>
        /// Filtert gerade Zahlen und gibt davon die kleinste zurück.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Die kleinste gerade Zahl.</returns>
        public int GetMinEven(int[] input)
        {
            // 1. Where: Filtert auf gerade Zahlen.
            // 2. Min: Sucht im gefilterten Ergebnis das Minimum.
            return input.Where(n => n % 2 == 0).Min();
        }

        // --- f. Die größte ungerade Zahl ---

        /// <summary>
        /// Filtert ungerade Zahlen und gibt davon die größte zurück.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Die größte ungerade Zahl.</returns>
        public int GetMaxOdd(int[] input)
        {
            // 1. Where: Filtert auf ungerade Zahlen (Rest bei Division durch 2 ist nicht 0).
            // 2. Max: Sucht das Maximum.
            return input.Where(n => n % 2 != 0).Max();
        }

        // --- g. Die Summe aller geraden Zahlen ---

        /// <summary>
        /// Addiert nur die geraden Zahlen auf.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Summe der geraden Zahlen.</returns>
        public int GetSumEven(int[] input)
        {
            return input.Where(n => n % 2 == 0).Sum();
        }

        // --- h. Durchschnitt aller ungeraden Zahlen ---

        /// <summary>
        /// Berechnet den Durchschnitt nur für die ungeraden Zahlen.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Durchschnitt der ungeraden Zahlen.</returns>
        public double GetAverageOdd(int[] input)
        {
            return input.Where(n => n % 2 != 0).Average();
        }

        // --- i. Anzahl aller geraden Zahlen ---

        /// <summary>
        /// Zählt, wie viele gerade Zahlen im Array enthalten sind.
        /// </summary>
        /// <param name="input">Eingabe-Array.</param>
        /// <returns>Anzahl der Treffer.</returns>
        public int GetCountEven(int[] input)
        {
            // Count() kann direkt ein Prädikat (Bedingung) aufnehmen.
            // Das ist effizienter als Where().Count().
            return input.Count(n => n % 2 == 0);
        }
    }
}
