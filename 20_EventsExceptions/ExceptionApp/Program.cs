using ExceptionApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 20 Exceptions & Events (WaterTank) ===");

        WaterTank tank = new WaterTank(100);

        // Subscribe to Event
        tank.LevelChanged += (sender, e) => 
        {
            Console.WriteLine($"[EVENT] Wasserstand geändert: {e.OldLevel} -> {e.NewLevel}");
        };

        try
        {
            Console.WriteLine("Fülle 50 Liter...");
            tank.AddWater(50);

            Console.WriteLine("Fülle 30 Liter...");
            tank.AddWater(30);

            Console.WriteLine("Fülle 30 Liter (Überlauf!)...");
            tank.AddWater(30);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"[FEHLER] {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[UNERWARTET] {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Vorgang beendet (Finally Block).");
        }
    }
}
