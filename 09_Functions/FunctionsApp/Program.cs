using FunctionsApp.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 09 Functions Showcase ===");

        // Demo Int Reverse
        int num = 12345;
        Console.WriteLine($"Reverse({num}) = {CalculatorService.IntReverse(num)}");

        // Demo Leap Year
        int year = 2000;
        Console.WriteLine($"IstSchaltjahr({year}) = {CalculatorService.IstSchaltjahr(year)}");

        // Demo Array Explode
        Console.WriteLine("Explode(4): " + string.Join(", ", ArrayFunctionService.ArrayExplode(4)));

        // Demo Input (Interactive)
        Console.WriteLine("\n-- Input Service Test --");
        // var age = InputService.EingabeInt("Wie alt sind Sie?", 0, 120);
        // Console.WriteLine($"Alter akzeptiert: {age}");
        Console.WriteLine("(Skipped interactive input for automation)");
    }
}
