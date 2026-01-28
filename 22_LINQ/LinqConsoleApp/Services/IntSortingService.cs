using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp.Services
{
    /// <summary>
    /// Service für Sortieroperationen auf Integer-Arrays.
    /// </summary>
    public class IntSortingService
    {
        private readonly int[] _numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };

        /// <summary>
        /// Liefert die Datenbasis.
        /// </summary>
        public int[] GetNumbers() => _numbers;

        /// <summary>
        /// Sortiert aufsteigend (Extension Method).
        /// </summary>
        /// <param name="input">Eingabearray.</param>
        /// <returns>Sortierte Sequenz.</returns>
        public IEnumerable<int> SortAscendingExtension(int[] input)
        {
            return input.OrderBy(n => n);
        }

        // ... (Füge hier die restlichen Methoden aus der vorherigen Antwort ein: SortDescending, FilterAndSort etc.)
    }
}
