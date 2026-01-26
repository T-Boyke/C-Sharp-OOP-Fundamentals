using System.Text;

namespace _06_Arrays.src;

/// <summary>
/// Steuert die Konsolenoberfläche und Benutzerinteraktion.
/// </summary>
public class ConsoleUI
{
    private readonly ArrayService _arrayService = new();
    private readonly StatisticService _statisticService = new();
    private readonly LottoService _lottoService = new();
    private readonly BinaryService _binaryService = new();
    private bool _isRunning = true;

    /// <summary>
    /// Startet die Hauptschleife der Anwendung.
    /// </summary>
    public void Run()
    {
         Console.OutputEncoding = Encoding.UTF8;

        while (_isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== 06_Arrays: Pilot Unit ===");
            Console.WriteLine("1 - Aufgabe 1: Array füllen (10 Zufallszahlen)");
            Console.WriteLine("2 - Aufgabe 2: Quadratzahlen (1..10 reversed)");
            Console.WriteLine("3 - Aufgabe 4: Statistik (Min/Max/Avg)");
            Console.WriteLine("4 - Aufgabe 5: Lottozahlen (Boolean Array)");
            Console.WriteLine("5 - Aufgabe 6: Binärzahlen (Dezimal -> Binär)");
            Console.WriteLine("0 - Beenden");
            Console.Write("\nIhre Auswahl: ");

            string input = Console.ReadLine() ?? "";

            Console.WriteLine("\n--- Ausgabe ---");
            switch (input)
            {
                case "1": RunTask1(); break;
                case "2": RunTask2(); break;
                case "3": RunTask4(); break;
                case "4": RunTask5(); break;
                case "5": RunTask6(); break;
                case "0": _isRunning = false; break;
                default: Console.WriteLine("Ungültige Eingabe."); break;
            }

            if (_isRunning)
            {
                Console.WriteLine("\n\nBeliebige Taste drücken...");
                Console.ReadKey();
            }
        }
    }

    private void RunTask1()
    {
        var numbers = _arrayService.CreateRandomArray(10, 1, 100);
        Console.WriteLine("Generierte Zahlen:");
        Console.WriteLine(string.Join(", ", numbers));
    }

    private void RunTask2()
    {
        var squares = _arrayService.GetSquareNumbers(10);
        Console.WriteLine("Quadratzahlen rückwärts:");
        for (int i = squares.Length - 1; i >= 0; i--)
        {
            Console.Write(squares[i] + (i > 0 ? ", " : ""));
        }
    }

    private void RunTask4()
    {
        var numbers = _arrayService.CreateRandomArray(10, 1, 99);
        Console.WriteLine($"Zahlen: {string.Join(", ", numbers)}");

        var stats = _statisticService.CalculateStatistics(numbers);
        Console.WriteLine($"Minimum: {stats.Min}");
        Console.WriteLine($"Maximum: {stats.Max}");
        Console.WriteLine($"Durchschnitt: {stats.Average:F2}");
        Console.WriteLine($"Summe: {stats.Sum}");
    }

    private void RunTask5()
    {
        var drawn = _lottoService.DrawLottoNumbers();
        Console.WriteLine("Gezogene Lottozahlen:");
        
        // Konvertieren des bool-Arrays in visuelle Ausgabe
        for (int i = 1; i < drawn.Length; i++)
        {
            if (drawn[i])
            {
                Console.Write(i + " ");
            }
        }
    }

    private void RunTask6()
    {
        Console.Write("Dezimalzahl (0-255): ");
        if (int.TryParse(Console.ReadLine(), out int decimalValue))
        {
            try 
            {
                var binary = _binaryService.DecimalToBinary(decimalValue);
                Console.Write("Binär: ");
                foreach (var bit in binary) Console.Write(bit);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe.");
        }
    }
}
