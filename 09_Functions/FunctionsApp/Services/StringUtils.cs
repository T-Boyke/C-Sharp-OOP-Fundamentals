using System;

namespace FunctionsApp.Services
{
    public static class StringUtils
    {
        /// <summary>
        /// Kehrt einen String manuell um.
        /// </summary>
        public static string Reverse(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        /// <summary>
        /// Prüft, ob ein Text ein Palindrom ist (Case-Insensitive).
        /// </summary>
        public static bool IstPalindrom(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return false;

            string clean = text.ToLower().Trim();
            string reversed = Reverse(clean);
            return clean == reversed;
        }
    }
}
