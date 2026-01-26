using GreetingApp;

/// <summary>
/// Hauptprogramm der GreetingApp.
/// Demonstriert Console I/O und Fehlerbehandlung.
/// </summary>
internal class Program
{
    /// <summary>
    /// Einstiegspunkt der Anwendung.
    /// </summary>
    /// <param name="args">Kommandozeilenparameter (werden hier ignoriert).</param>
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Greeting App 2026 ===");

        try
        {
            // Schritt 1: Name erfassen
            Console.Write("Bitte geben Sie Ihren Namen ein: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Fehler: Name darf nicht leer sein.");
                return;
            }

            // Schritt 2: Alter erfassen
            Console.Write("Bitte geben Sie Ihr Alter (in Jahren) ein: ");
            string? ageInput = Console.ReadLine();

            if (int.TryParse(ageInput, out int age))
            {
                // Schritt 3: Logik aufrufen
                string greeting = GreetingService.GetGreeting(name, age);
                
                // Schritt 4: Ausgabe
                Console.WriteLine();
                Console.WriteLine(greeting);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fehler: Das ist keine gültige Zahl!");
                Console.ResetColor();
            }
        }
        catch (Exception ex)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Kritischer Fehler: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine();
        Console.WriteLine("Drücken Sie eine Taste zum Beenden...");
        Console.ReadKey();
    }
}
