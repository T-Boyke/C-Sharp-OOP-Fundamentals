using _09_Functions.src;
using System;
using System.Text;

namespace _09_Functions.src
{
    public class ConsoleUI
    {
        private readonly FunctionService _funcService = new();
        private readonly InputService _inputService = new();
        private bool _running = true;
        
        // Bank State (Task 6)
        private decimal _kontostand = 1000m;

        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (_running)
            {
                Console.Clear();
                Console.WriteLine("=== 09_Functions: Funktionen ===");
                Console.WriteLine("1 - GibMir5");
                Console.WriteLine("2 - Addition");
                Console.WriteLine("3 - Schaltjahr");
                Console.WriteLine("4 - Taschenrechner");
                Console.WriteLine("5 - Temperatur");
                Console.WriteLine("6 - Bankkonto");
                Console.WriteLine("7 - IntReverse");
                Console.WriteLine("9 - String Reverse");
                Console.WriteLine("10 - Palindrom");
                Console.WriteLine("11 - Array Merge");
                Console.WriteLine("12 - Array Explode");
                Console.WriteLine("0 - Ende");
                Console.Write("\nAuswahl: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine("\n--- Ausgabe ---");

                switch (choice)
                {
                    case "1": 
                        int val = _funcService.GibMir5(); 
                        Console.WriteLine($"Funktion gab {val} zurück."); 
                        break;
                    case "2": RunAddition(); break;
                    case "3": RunSchaltjahr(); break;
                    case "4": RunCalculator(); break;
                    case "5": RunTemperature(); break;
                    case "6": RunBank(); break;
                    case "7": RunIntReverse(); break;
                    case "9": RunStringReverse(); break;
                    case "10": RunPalindrom(); break;
                    case "11": RunArrayMerge(); break;
                    case "12": RunArrayExplode(); break;
                    case "0": _running = false; break;
                    default: Console.WriteLine("Ungültig."); break;
                }

                if (_running)
                {
                    Console.WriteLine("\nBeliebige Taste...");
                    Console.ReadKey();
                }
            }
        }

        private void RunAddition()
        {
            int z1 = _inputService.EingabeInt("Zahl 1:");
            int z2 = _inputService.EingabeInt("Zahl 2:");
            int sum = _funcService.Addition(z1, z2);
            Console.WriteLine($"Ergebnis: {sum}");
        }

        private void RunSchaltjahr()
        {
            int jahr = _inputService.EingabeInt("Jahr:");
            bool istSchalt = _funcService.IstSchaltjahr(jahr);
            Console.WriteLine(istSchalt ? "Ist ein Schaltjahr." : "Kein Schaltjahr.");
        }

        private void RunCalculator()
        {
            double d1 = _inputService.EingabeDouble("Zahl 1:");
            double d2 = _inputService.EingabeDouble("Zahl 2:");
            Console.Write("Operator (+, -, *, /): ");
            string op = Console.ReadLine() ?? "";

            double res = 0;
            switch(op)
            {
                case "+": res = _funcService.Add(d1, d2); break;
                case "-": res = _funcService.Sub(d1, d2); break;
                case "*": res = _funcService.Mult(d1, d2); break;
                case "/": res = _funcService.Div(d1, d2); break;
                default: Console.WriteLine("Unbekannt."); return;
            }
            Console.WriteLine($"Ergebnis: {res}");
        }

        private void RunTemperature()
        {
            Console.WriteLine("1: C->F, 2: C->K, 3: F->C, 4: K->C"); // Simplified menu
            int mode = _inputService.EingabeInt("Modus", 1, 4);
            double val = _inputService.EingabeDouble("Temperatur:");
            double res = 0;

            switch(mode)
            {
                case 1: res = _funcService.CnachF(val); break;
                case 2: res = _funcService.CnachK(val); break;
                case 3: res = _funcService.FnachC(val); break;
                case 4: res = _funcService.KnachC(val); break;
            }
            Console.WriteLine($"Ergebnis: {res:F2}");
        }

        private void RunBank()
        {
            bool bankLoop = true;
            while(bankLoop)
            {
                Console.WriteLine($"\nKontostand: {_kontostand:C}");
                Console.WriteLine("(e)inzahlen, (a)bheben, (z)urück");
                string action = Console.ReadLine() ?? "";
                
                switch(action.ToLower())
                {
                    case "e":
                        decimal ein = (decimal)_inputService.EingabeDouble("Betrag:");
                        if (ein > 0) _kontostand += ein; 
                        break;
                    case "a":
                        decimal aus = (decimal)_inputService.EingabeDouble("Betrag:");
                        if (aus > 0 && aus <= _kontostand) _kontostand -= aus;
                        else Console.WriteLine("Ungültiger Betrag.");
                        break;
                    case "z": bankLoop = false; break;
                }
            }
        }

        private void RunIntReverse()
        {
            int val = _inputService.EingabeInt("Zahl:");
            Console.WriteLine($"Reversed: {_funcService.IntReverse(val)}");
        }

        private void RunStringReverse()
        {
            Console.Write("Text: ");
            string t = Console.ReadLine() ?? "";
            Console.WriteLine($"Reversed: {_funcService.Reverse(t)}");
        }

        private void RunPalindrom()
        {
            Console.Write("Text: ");
            string t = Console.ReadLine() ?? "";
             if (_funcService.IstPalindrom(t)) Console.WriteLine("Ist Palindrom.");
             else Console.WriteLine("Kein Palindrom.");
        }

        private void RunArrayMerge()
        {
             int[] a1 = { 1, 5, 3 };
             int[] a2 = { 2, 4 };
             var merged = _funcService.ArrayMerge(a1, a2);
             Console.WriteLine("Merged: " + string.Join(", ", merged));
        }

        private void RunArrayExplode()
        {
            int limit = _inputService.EingabeInt("Grenze:");
            var res = _funcService.ArrayExplode(limit);
            Console.WriteLine("Exploded: " + string.Join(", ", res));
        }
    }
}
