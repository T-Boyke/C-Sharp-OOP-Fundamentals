using _18_Algorithms.src;
using System;

namespace _18_Algorithms.src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Unit 18: Algorithms ---");
            
            var isbnService = new IsbnService();
            string validIsbn = "3-16-148410-X";
            Console.WriteLine($"ISBN {validIsbn} Valid? {isbnService.ValidateIsbn10(validIsbn)}");

            var textService = new TextAnalysisService();
            string text = "Ich habe fertig!";
            Console.WriteLine($"Word Count: {textService.CountWords(text)}");
        }
    }
}
