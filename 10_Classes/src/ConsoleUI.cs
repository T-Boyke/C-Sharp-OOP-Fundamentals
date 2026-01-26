using _10_Classes.src;
using System;

namespace _10_Classes.src
{
    public class ConsoleUI
    {
        private readonly Tv _tv = new();

        public void Run()
        {
            bool running = true;
            while(running)
            {
                Console.Clear();
                Console.WriteLine("=== 10_Classes: TV ===");
                Console.WriteLine("1 - Einschalten");
                Console.WriteLine("2 - Ausschalten");
                Console.WriteLine("3 - Lauter");
                Console.WriteLine("4 - Leiser");
                Console.WriteLine("5 - Info");
                Console.WriteLine("0 - Ende");
                Console.Write("\nAuswahl: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch(choice)
                {
                    case "1": _tv.TurnOn(); break;
                    case "2": _tv.TurnOff(); break;
                    case "3": _tv.RaiseVolume(); break;
                    case "4": _tv.LowerVolume(); break;
                    case "5": Console.WriteLine(_tv.GetInfo()); break;
                    case "0": running = false; break;
                }

                if (running)
                {
                    Console.WriteLine("\nBeliebige Taste...");
                    Console.ReadKey();
                }
            }
        }
    }
}
