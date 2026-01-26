using _15_Klausur.src;
using _15_Klausur.src.Observer;
using System;

namespace _15_Klausur.src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Klausur Aufgabe 1: Film ---");
            var film = new Film(1, "The Matrix", "SciFi", 1999, 136);
            Console.WriteLine($"Film: {film.GetTitel()}");

            Console.WriteLine("\n--- Klausur Aufgabe 2: Observer ---");
            var model = new PatientModel();
            var view = new TableView(model); // Registers itself

            model.SetData(1, "Max Mustermann");
            // Output should appear from TableView
        }
    }
}
