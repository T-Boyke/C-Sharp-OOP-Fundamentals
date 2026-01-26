using ProceduresApp;

internal class Program
{
    private static void Main(string[] args)
    {
        // Dependency Injection Setup
        IOutputService consoleOut = new ConsoleOutputService();
        var procedures = new ProcedureContainer(consoleOut);

        Console.WriteLine("=== 08 Prozeduren ===");

        // Demo Calls
        Console.WriteLine("\nTask 1: Guten Morgen");
        procedures.AusgabeGutenMorgen();

        Console.WriteLine("\nTask 4: Addition (10, 20)");
        procedures.Addition(10, 20);

        Console.WriteLine("\nTask 5: Mehrfache Ausgabe ('Echo', 3)");
        procedures.AusgabeText("Echo", 3);

        Console.WriteLine("\nTask 6: Verkettung");
        procedures.Prozedur1();

        Console.WriteLine("\nTask 7: Division (10, 2)");
        procedures.Division(10, 2);
        procedures.Division(10, 0);

        Console.WriteLine("\nTask 8: Matrix Print");
        int[,] mat = { { 1, 2 }, { 3, 4 } };
        procedures.ArrayAusgabe(mat);

        Console.WriteLine("\nTask 9: Teiler von 12");
        procedures.AnzeigeTeiler(12);
    }
}
