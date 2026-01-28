using System;
using LinqConsoleApp.Services; // Namespace Import wichtig

namespace LinqConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 22_LINQ Gesamtanwendung ===\n");

            // --- Teil 1: Filterung (Aus bestehendem Code) ---
            RunFilteringDemo();

            Console.WriteLine("\n--------------------------------------\n");

            // --- Teil 2: Sortierung (Neu) ---
            RunSortingDemo();

            Console.ReadKey();
        }

        static void RunFilteringDemo()
        {
            Console.WriteLine("--- Demo: Filterung ---");
            var filterService = new FilteringService(); // Hieß früher LinqService
            
            // Beispielaufruf aus Aufgabe 22
            var data = filterService.GetData();
            // ... Logik für Filter-Output hier einfügen
        }

        static void RunSortingDemo()
        {
            Console.WriteLine("--- Demo: Sortierung ---");
            
            var intService = new IntSortingService();
            Console.WriteLine("Sortierung (Asc): " + string.Join(", ", intService.SortAscendingExtension(intService.GetNumbers())));

            var stringService = new StringSortingService();
            Console.WriteLine("Wortlänge: " + string.Join(", ", stringService.SortByLength(stringService.GetWords())));
        }
    }
}
