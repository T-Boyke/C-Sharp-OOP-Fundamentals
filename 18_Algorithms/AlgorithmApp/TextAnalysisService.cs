using System;
using System.Linq;

namespace AlgorithmApp
{
    public static class TextAnalysisService
    {
        public static int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            // Split by whitespace and remove empty entries (double spaces)
            var words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public static string FindLongestWord(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";
            
            // Sauber Split (auch Satzzeichen entfernen wenn gewünscht, hier simpel)
            var words = text.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            
            string longest = "";
            foreach (var w in words)
            {
                if (w.Length > longest.Length)
                {
                    longest = w;
                }
            }
            return longest;
        }
    }
}
