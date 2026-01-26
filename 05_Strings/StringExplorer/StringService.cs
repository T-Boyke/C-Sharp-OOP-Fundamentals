using System;
using System.Text;

namespace StringExplorer
{
    /// <summary>
    /// Bietet Methoden zur String-Manipulation und -Analyse.
    /// </summary>
    public static class StringService
    {
        /// <summary>
        /// Kehrt einen String um (Manuelle Implementierung).
        /// </summary>
        /// <param name="input">Der Eingabestring.</param>
        /// <returns>Der umgekehrte String.</returns>
        /// <exception cref="ArgumentNullException">Wenn der Input null ist.</exception>
        /// <remarks>
        /// Nutzt ein Char-Array, um Speicherallokationen für Zwischenstrings zu vermeiden.
        /// </remarks>
        public static string Reverse(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));
            if (input.Length <= 1) return input;

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// Erzeugt effizient ein Muster "1-2-3-...-n".
        /// </summary>
        /// <param name="n">Die Anzahl der Elemente.</param>
        /// <returns>Das generierte Muster als String.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Wenn n kleiner als 1 ist.</exception>
        /// <remarks>
        /// Verwendet <see cref="StringBuilder"/> urn die Performance bei großen n zu optimieren.
        /// </remarks>
        public static string GeneratePattern(int n)
        {
            if (n < 1) throw new ArgumentOutOfRangeException(nameof(n), "n muss mindestens 1 sein.");

            var sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                sb.Append(i);
                if (i < n)
                {
                    sb.Append("-");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Zerlegt eine E-Mail-Adresse in Benutzer und Domain.
        /// </summary>
        /// <param name="email">Die E-Mail-Adresse.</param>
        /// <returns>Ein Tupel (User, Domain).</returns>
        /// <exception cref="ArgumentException">Wenn das Format ungültig ist (kein @ oder leer).</exception>
        public static (string user, string domain) ParseEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("E-Mail darf nicht leer sein.", nameof(email));
            
            // Einfache Validierung
            string[] parts = email.Split('@');
            if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
            {
                throw new ArgumentException("Ungültiges E-Mail-Format.");
            }

            return (parts[0], parts[1]);
        }
    }
}
