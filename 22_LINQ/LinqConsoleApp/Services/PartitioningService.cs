using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp.Services
{
    /// <summary>
    /// Stellt Funktionen zur Partitionierung (Aufteilung) von Arrays bereit.
    /// Nutzt Extension-Method-Syntax wie in der Aufgabenstellung gefordert.
    /// </summary>
    public class PartitioningService
    {
        [cite_start]// Datenbasis aus Aufgabe Partitionierung [cite: 27]
        private readonly int[] _numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

        /// <summary>
        /// Gibt die Datenbasis zurück.
        /// </summary>
        public int[] GetNumbers() => _numbers;

        // --- Aufgabe a: Die ersten fünf Elemente ---

        /// <summary>
        /// Ermittelt die ersten fünf Elemente der Sequenz.
        /// </summary>
        /// <param name="input">Das Eingabe-Array.</param>
        /// <returns>Die ersten 5 Zahlen.</returns>
        public IEnumerable<int> GetFirstFive(int[] input)
        {
            // Take(n) nimmt die ersten n Elemente vom Anfang der Sequenz.
            return input.Take(5); 
        }

        // --- Aufgabe b: Die letzten fünf Elemente ---

        /// <summary>
        /// Ermittelt die letzten fünf Elemente der Sequenz.
        /// </summary>
        /// <param name="input">Das Eingabe-Array.</param>
        /// <returns>Die letzten 5 Zahlen.</returns>
        public IEnumerable<int> GetLastFive(int[] input)
        {
            // TakeLast(n) ist effizienter als Skip(Count - n) und in modernem .NET verfügbar.
            return input.TakeLast(5);
        }

        // --- Aufgabe c: Alles außer erste und letzte drei ---

        /// <summary>
        /// Schneidet vorne und hinten jeweils 3 Elemente ab.
        /// </summary>
        /// <param name="input">Das Eingabe-Array.</param>
        /// <returns>Die mittlere Sektion der Sequenz.</returns>
        public IEnumerable<int> GetMiddleSection(int[] input)
        {
            // Kombination aus Skip (vorne überspringen) und SkipLast (hinten verwerfen).
            return input.Skip(3).SkipLast(3);
        }

        // --- Aufgabe d: Elemente vor der 22 ---

        /// <summary>
        /// Liefert alle Elemente, solange die Bedingung (Wert ist nicht 22) wahr ist.
        /// </summary>
        /// <param name="input">Das Eingabe-Array.</param>
        /// <returns>Alle Zahlen, die vor dem ersten Auftreten der 22 stehen.</returns>
        public IEnumerable<int> GetBefore22(int[] input)
        {
            // TakeWhile stoppt sofort, sobald die Bedingung false wird (hier bei 22).
            return input.TakeWhile(n => n != 22);
        }

        // --- Aufgabe e: Elemente nach der 12 ---

        /// <summary>
        /// Liefert alle Elemente, die nach dem ersten Auftreten der 12 stehen.
        /// </summary>
        /// <param name="input">Das Eingabe-Array.</param>
        /// <returns>Die Rest-Sequenz nach der 12.</returns>
        public IEnumerable<int> GetAfter12(int[] input)
        {
            // 1. SkipWhile: Überspringt alles, solange es NICHT 12 ist (stoppt bei der 12).
            // 2. Skip(1): Überspringt die 12 selbst, da wir nur das "danach" wollen.
            return input.SkipWhile(n => n != 12).Skip(1);
        }

        // --- Aufgabe f: Seitenweise Ausgabe (Paging) ---

        /// <summary>
        /// Teilt das Array in Blöcke (Chunks) einer bestimmten Größe auf.
        /// </summary>
        /// <param name="input">Das Eingabe-Array.</param>
        /// <param name="pageSize">Anzahl der Elemente pro Seite (Standard: 5).</param>
        /// <returns>Eine Liste von Integer-Arrays (die Seiten).</returns>
        public IEnumerable<int[]> GetPages(int[] input, int pageSize = 5)
        {
            // Chunk zerteilt eine Collection in Arrays der angegebenen Größe.
            // Der letzte Chunk kann kleiner sein, wenn nicht mehr genug Elemente da sind.
            return input.Chunk(pageSize);
        }
    }
}
