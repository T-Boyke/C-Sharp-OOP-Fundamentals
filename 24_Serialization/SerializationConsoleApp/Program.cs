using System;
using SerializationConsoleApp.Models;
using SerializationConsoleApp.Services;

namespace SerializationConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SerializationService service = new SerializationService();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Menü ---");
                Console.WriteLine("1: Speichern");
                Console.WriteLine("2: Laden");
                Console.WriteLine("3: Beenden");
                Console.Write("Auswahl: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Person p = new Person();
                        Console.Write("Vorname: "); p.Vorname = Console.ReadLine() ?? "";
                        Console.Write("Nachname: "); p.Nachname = Console.ReadLine() ?? "";
                        Console.Write("Alter: "); p.Alter = int.Parse(Console.ReadLine() ?? "0");
                        service.SavePerson(p);
                        Console.WriteLine("Gespeichert.");
                        break;
                    case "2":
                        Console.Write("Nachname der zu ladenden Person: ");
                        string name = Console.ReadLine() ?? "";
                        Person? geladen = service.LoadPerson(name);
                        if (geladen != null)
                            Console.WriteLine($"Geladen: {geladen.Vorname} {geladen.Nachname}, {geladen.Alter} Jahre");
                        else
                            Console.WriteLine("Datei nicht gefunden.");
                        break;
                    default:
                        exit = true;
                        break;
                }
            }
        }
    }
}
