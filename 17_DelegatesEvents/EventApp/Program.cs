using EventApp;

internal class Program
{
    // Delegate Definition
    public delegate void MyDelegate(string msg);

    private static void Main(string[] args)
    {
        Console.WriteLine("=== 17 Delegates & Events ===");

        // 1. Simple Delegate
        Console.WriteLine("\n--- Delegate ---");
        MyDelegate del = Console.WriteLine;
        del("Hallo Welt via Delegate!");

        // 2. Event (Clock)
        Console.WriteLine("\n--- Event (Clock) ---");
        Clock clock = new Clock();
        Display display = new Display();

        // Subscribe
        clock.OnTick += display.ShowTime;
        
        // Lambda Subscription
        clock.OnTick += (t) => Console.WriteLine($"Lambda: Tick! {t.Second}");

        // Run
        clock.Run(3);
    }
}
