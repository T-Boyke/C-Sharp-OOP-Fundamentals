using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp.Services
{
    /// <summary>
    /// Service für komplexe Sortieroperationen auf Strings.
    /// </summary>
    public class StringSortingService
    {
        private readonly string[] _words = { 
            "zero", "one", "two", "three", "four", "five",
            "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
            "thirteen", "fourteen" 
        };

        public string[] GetWords() => _words;

        /// <summary>
        /// Sortiert nach Länge (Extension Method).
        /// </summary>
        public IEnumerable<string> SortByLength(string[] input)
        {
            return input.OrderBy(w => w.Length);
        }
        
        // ... (Füge hier die restlichen Methoden aus der vorherigen Antwort ein: ThenBy, Reverse etc.)
    }
}
