using StaticApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 16 Static Members ===");

        // 1. Static Math
        Console.WriteLine($"10 + 5 = {Calculator.Add(10, 5)}");

        // 2. Instance Counting
        Console.WriteLine($"\nEntities am Anfang: {Entity.GetCount()}");
        
        var e1 = new Entity();
        var e2 = new Entity();
        var e3 = new Entity();

        Console.WriteLine($"Entities nach Erstellung: {Entity.GetCount()} (Erwartet: 3)");
    }
}
