using StringExplorer;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== String Explorer ===");

        // 1. Reverse
        string original = "Software Engineering";
        string reversed = StringService.Reverse(original);
        Console.WriteLine($"Original: {original} -> Reversed: {reversed}");

        // 2. Pattern
        Console.WriteLine("\nPattern Generierung (n=10):");
        Console.WriteLine(StringService.GeneratePattern(10));

        // 3. Email Parsing
        try
        {
            string mail = "kontakt@firma.de";
            var info = StringService.ParseEmail(mail);
            Console.WriteLine($"\nE-Mail: {mail}");
            Console.WriteLine($"User: {info.user}");
            Console.WriteLine($"Domain: {info.domain}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}
