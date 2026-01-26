using System;
using System.Linq;

namespace _18_Algorithms.src
{
    public class TextAnalysisService
    {
        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            // Split by whitespace and common punctuation roughly
            var words = text.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public string FindLongestWord(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";

            var words = text.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            
            return words.OrderByDescending(w => w.Length).FirstOrDefault() ?? "";
        }
    }
}
