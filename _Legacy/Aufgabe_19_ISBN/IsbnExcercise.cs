using System;
using System.Linq;

namespace IsbnExcercise
{
    // Benutzerdefinierte Exception für falsches Format
    public class ArgumentFormatException : ArgumentException
    {
        public ArgumentFormatException() { }
        public ArgumentFormatException(string message) : base(message) { }
        public ArgumentFormatException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class IsbnFormatter
    {
        public static void Main()
        {
            try
            {
                // Testfall: Gültige ISBN
                Console.WriteLine(FormatIsbn("9783866801929"));

                // Testfall: Fehler simulieren (Kommentierung entfernen zum Testen)
                // Console.WriteLine(FormatIsbn(null));       // Wirft ArgumentNullException
                // Console.WriteLine(FormatIsbn("97838X6801929")); // Wirft ArgumentFormatException
                // Console.WriteLine(FormatIsbn("12345"));    // Wirft ArgumentOutOfRangeException
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.GetType().Name} - {ex.Message}");
            }
        }

        /// <summary>
        /// Validiert und formatiert eine 13-stellige Ziffernfolge als ISBN.
        /// </summary>
        public static string FormatIsbn(string isbnInput)
        {
            // 1. Prüfung: Ist das Argument null?
            if (isbnInput is null)
            {
                throw new ArgumentNullException(nameof(isbnInput), "Die Eingabe darf nicht null sein.");
            }

            // 2. Prüfung: Sind es nur Ziffern?
            // Effiziente Prüfung auf ASCII-Ziffern ('0'-'9')
            if (!isbnInput.All(char.IsAsciiDigit))
            {
                throw new ArgumentFormatException("Die Eingabe darf nur Ziffern enthalten.");
            }

            // 3. Prüfung: Ist die Länge exakt 13?
            // (Diese Prüfung erfolgt erst, wenn sichergestellt ist, dass es Ziffern sind)
            if (isbnInput.Length != 13)
            {
                throw new ArgumentOutOfRangeException(nameof(isbnInput), isbnInput.Length, "Die Ziffernfolge muss exakt 13 Zeichen lang sein.");
            }

            // Formatierung: 978-3-86680-192-9
            // Nutzung von Indizes und Slicing für Speicher-Effizienz
            return $"ISBN {isbnInput[..3]}-{isbnInput[3]}-{isbnInput[4..9]}-{isbnInput[9..12]}-{isbnInput[12]}";
        }
    }
}
