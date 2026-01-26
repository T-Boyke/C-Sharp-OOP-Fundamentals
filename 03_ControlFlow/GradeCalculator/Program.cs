using GradeCalculator;

/// <summary>
/// IHK Notenrechner Konsole.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== IHK Notenrechner ===");
        string input;

        // Do-While Schleife: Mindestens einmal ausführen
        do
        {
            Console.Write("\nBitte Punkte eingeben (0-100) oder 'exit': ");
            input = Console.ReadLine() ?? "";

            if (input.ToLower() == "exit") break;

            if (int.TryParse(input, out int points))
            {
                try
                {
                    string grade = GradeService.GetGrade(points);
                    
                    // Farbe je nach Note
                    SetColorForGrade(grade);
                    Console.WriteLine($"-> Note: {grade}");
                    Console.ResetColor();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Fehler: {ex.ParamName} - {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Bitte eine gültige Ganzzahl eingeben.");
            }

        } while (input.ToLower() != "exit");

        Console.WriteLine("Programm beendet.");
    }

    /// <summary>
    /// Setzt die Konsolenfarbe basierend auf der Note.
    /// </summary>
    private static void SetColorForGrade(string grade)
    {
        Console.ForegroundColor = grade switch
        {
            "Sehr gut" => ConsoleColor.Green,
            "Gut" => ConsoleColor.DarkGreen,
            "Befriedigend" => ConsoleColor.Yellow,
            "Ausreichend" => ConsoleColor.DarkYellow,
            "Mangelhaft" => ConsoleColor.Red,
            _ => ConsoleColor.DarkRed
        };
    }
}
