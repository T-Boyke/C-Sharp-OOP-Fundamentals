using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFilteringApp.Services
{
    /// <summary>
    /// Bietet Methoden zur Filterung von Daten mittels LINQ (Extension-Method- und Query-Syntax).
    /// </summary>
    public class LinqService
    {
        private readonly int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 };
        private readonly string[] numbers2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen" };

        /// <summary>
        /// Aufgabe 1a: Filtert Zahlen kleiner als 7.
        /// </summary>
        public (IEnumerable<int> ext, IEnumerable<int> query) GetNumbersSmallerThanSeven()
        {
            var ext = numbers.Where(n => n < 7);
            var query = from n in numbers where n < 7 select n;
            return (ext, query);
        }

        /// <summary>
        /// Aufgabe 1d: Filtert gerade Zahlen ab dem 6. Element.
        /// </summary>
        public (IEnumerable<int> ext, IEnumerable<int> query) GetEvenNumbersFromIndexFive()
        {
            // Extension-Method-Syntax nutzt Skip(5) für den Index-Versatz
            var ext = numbers.Skip(5).Where(n => n % 2 == 0);
            var query = from n in numbers.Skip(5) where n % 2 == 0 select n;
            return (ext, query);
        }

        /// <summary>
        /// Aufgabe 2d: Filtert Zahlen, die auf 'teen' enden und wandelt sie in Großbuchstaben um.
        /// </summary>
        public (IEnumerable<string> ext, IEnumerable<string> query) GetTeensUpper()
        {
            var ext = numbers2.Where(s => s.EndsWith("teen")).Select(s => s.ToUpper());
            var query = from s in numbers2
                        where s.EndsWith("teen")
                        select s.ToUpper();
            return (ext, query);
        }

        /// <summary>
        /// Aufgabe 2f: Filtert Zahlen, die nicht mit 't' beginnen.
        /// </summary>
        public (IEnumerable<string> ext, IEnumerable<string> query) GetNotStartingWithT()
        {
            var ext = numbers2.Where(s => !s.StartsWith("t"));
            var query = from s in numbers2 where !s.StartsWith("t") select s;
            return (ext, query);
        }
    }
}
