using ClassesApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== TV Simulator 2026 ===");
        Tv myTv = new Tv();

        while (true)
        {
            Console.WriteLine($"\n{myTv.GetInfo()}");
            Console.WriteLine("1: An | 2: Aus | 3: Lauter | 4: Leiser | 5: Exit");
            Console.Write("Aktion: ");
            
            string key = Console.ReadLine() ?? "";

            switch (key)
            {
                case "1": myTv.TurnOn(); break;
                case "2": myTv.TurnOff(); break;
                case "3": myTv.RaiseVolume(); break;
                case "4": myTv.LowerVolume(); break;
                case "5": return;
                default: Console.WriteLine("Ungültig."); break;
            }
        }
    }
}
