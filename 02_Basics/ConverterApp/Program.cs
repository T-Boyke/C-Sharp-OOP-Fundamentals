using ConverterApp;

/// <summary>
/// Hauptprogramm für den ConverterApp.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Multi-Converter 2026 ===");
        
        while (true)
        {
            Console.WriteLine("\nWählen Sie eine Option:");
            Console.WriteLine("1. Celsius in Fahrenheit");
            Console.WriteLine("2. Euro in Dollar");
            Console.WriteLine("3. Minuten in Stunden:Minuten");
            Console.WriteLine("4. Beenden");
            Console.Write("Auswahl: ");

            string? choice = Console.ReadLine();

            if (choice == "4") break;

            try
            {
                switch (choice)
                {
                    case "1":
                        HandleTemperature();
                        break;
                    case "2":
                        HandleCurrency();
                        break;
                    case "3":
                        HandleTime();
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }

    private static void HandleTemperature()
    {
        Console.Write("Temperatur in Celsius: ");
        if (double.TryParse(Console.ReadLine(), out double c))
        {
            double f = ConverterService.CelsiusToFahrenheit(c);
            Console.WriteLine($"{c}°C sind {f:F2}°F");
        }
        else
        {
            Console.WriteLine("Ungültige Zahl.");
        }
    }

    private static void HandleCurrency()
    {
        Console.Write("Betrag in Euro: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal e))
        {
            decimal d = ConverterService.EuroToDollar(e);
            Console.WriteLine($"{e:C} wurden in {d:C} umgerechnet."); // :C nutzt Systemwährungssymbol, hier exemplarisch
        }
        else
        {
            Console.WriteLine("Ungültiger Betrag.");
        }
    }

    private static void HandleTime()
    {
        Console.Write("Minuten gesamt: ");
        if (int.TryParse(Console.ReadLine(), out int m))
        {
            var result = ConverterService.MinutesToHoursAndMinutes(m);
            Console.WriteLine($"{m} Minuten sind {result.hours} Stunden und {result.minutes} Minuten.");
        }
        else
        {
            Console.WriteLine("Ungültige Ganzzahl.");
        }
    }
}
