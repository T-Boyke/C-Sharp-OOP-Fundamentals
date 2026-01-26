using AlgorithmApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 18 Algorithms ===");

        // ISBN
        string isbn = "3-86680-192-0";
        bool valid = IsbnService.ValidateIsbn10(isbn);
        Console.WriteLine($"ISBN {isbn} is valid: {valid}");

        // Text
        string text = "Ich habe fertig! Was erlauben Strunz?";
        Console.WriteLine($"\nText: {text}");
        Console.WriteLine($"Wörter: {TextAnalysisService.CountWords(text)}");
        Console.WriteLine($"Längstes Wort: {TextAnalysisService.FindLongestWord(text)}");
    }
}
