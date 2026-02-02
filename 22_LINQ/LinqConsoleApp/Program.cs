using System;
using System.Linq;
using LinqConsoleApp.Services;

namespace LinqConsoleApp
{
    /// <summary>
    /// Zentrale Konsolenanwendung zur Demonstration verschiedener LINQ-Konzepte.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Einstiegspunkt der Anwendung.
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("=== 22_LINQ Gesamtanwendung ===\n");

            // Teil 1 & 2: Filterung und Sortierung
            RunFilteringDemo();
            Console.WriteLine("\n--------------------------------------\n");
            RunSortingDemo();
            
            // Teil 5: Warenkorb (Neu - Aufgabe 20260130)
            Console.WriteLine("\n--------------------------------------\n");
            RunShoppingCartDemo();

            Console.WriteLine("\nAnwendung beendet. Beliebige Taste drücken...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstriert Filterungs-Operationen.
        /// </summary>
        static void RunFilteringDemo()
        {
            Console.WriteLine("--- Demo: Filterung ---");
            var filterService = new FilteringService();
            var data = filterService.GetData();
            // Ausgabe-Logik wird hier durch den Service gekapselt
        }

        /// <summary>
        /// Demonstriert Sortierungs-Operationen für Zahlen und Texte.
        /// </summary>
        static void RunSortingDemo()
        {
            Console.WriteLine("--- Demo: Sortierung ---");
            var intService = new IntSortingService();
            Console.WriteLine("Sortierung (Asc): " + string.Join(", ", intService.SortAscendingExtension(intService.GetNumbers())));

            var stringService = new StringSortingService();
            Console.WriteLine("Wortlänge: " + string.Join(", ", stringService.SortByLength(stringService.GetWords())));
        }

        /// <summary>
        /// Führt die komplexen Abfragen der Warenkorb-Aufgabe aus.
        /// </summary>
        static void RunShoppingCartDemo()
        {
            Console.WriteLine("--- Demo: Warenkorb (Joins & Aggregation) ---");
            var cartService = new ShoppingCartService();
            cartService.RunAllTasks();
        }
    }
}
