using _08_Procedures.src.Services;
using System;
using System.Text;

namespace _08_Procedures.src
{
    public class ConsoleUI
    {
        private readonly ProcedureService _service;
        private bool _running = true;

        public ConsoleUI()
        {
            _service = new ProcedureService(new ConsoleWrapper());
        }

        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (_running)
            {
                Console.Clear();
                Console.WriteLine("=== 08_Procedures: Unterprogramme ===");
                Console.WriteLine("1 - Guten Morgen");
                Console.WriteLine("2 - Ausgabe Text");
                Console.WriteLine("3 - Input Output");
                Console.WriteLine("4 - Addition");
                Console.WriteLine("5 - Mehrfache Ausgabe");
                Console.WriteLine("6 - Verkettung");
                Console.WriteLine("7 - Taschenrechner");
                Console.WriteLine("8 - Array Ausgabe");
                Console.WriteLine("9 - Teiler");
                Console.WriteLine("0 - Ende");
                Console.Write("\nAuswahl: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine("\n--- Ausgabe ---");
                
                switch (choice)
                {
                    case "1": _service.AusgabeGutenMorgen(); break;
                    case "2": _service.AusgabeText("Hallo Welt (Parameter)"); break;
                    case "3": _service.InputOutput(); break;
                    case "4": 
                        _service.Addition(5, 7); 
                        break; // Fixed example, or ask user?
                    case "5": _service.MehrfacheAusgabe("Echo...", 3); break;
                    case "6": _service.Prozedur1(); break;
                    case "7": RunCalculator(); break;
                    case "8": 
                        int[,] arr = { { 1, 2 }, { 3, 4 } };
                        _service.PrintArray(arr); 
                        break;
                    case "9": _service.PrintDivisors(12); break;
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

        private void RunCalculator()
        {
            Console.Write("Zahl 1: ");
            int n1 = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Zahl 2: ");
            int n2 = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Operator: ");
            string op = Console.ReadLine() ?? "+";
            
            _service.Calculate(n1, n2, op);
        }
    }
}
