using System;
using System.Threading.Tasks;
using SerializationConsoleApp.Models;
using SerializationConsoleApp.Services;

namespace SerializationConsoleApp
{
    /// <summary>
    /// Stellt den Einstiegspunkt der Anwendung bereit und verwaltet die Benutzerinteraktion.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Die Hauptmethode der Konsolenanwendung.
        /// </summary>
        /// <remarks>
        /// Die Signatur wurde zu <c>async Task</c> geändert, um asynchrone Operationen (I/O) mittels <c>await</c> zu ermöglichen.
        /// Dies entspricht modernen Standards, um den Thread nicht zu blockieren.
        /// </remarks>
        /// <param name="args">Kommandozeilenargumente (werden hier nicht verwendet).</param>
        /// <returns>Ein Task, der den laufenden Prozess repräsentiert.</returns>
        static async Task Main(string[] args)
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

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Erzeugen und Befüllen des Objekts
                        Person p = new Person();
                        
                        Console.Write("Vorname: "); 
                        p.Vorname = Console.ReadLine() ?? string.Empty;
                        
                        Console.Write("Nachname: "); 
                        p.Nachname = Console.ReadLine() ?? string.Empty;

                        // Sicheres Parsen des Alters, um FormatExceptions zu vermeiden.
                        Console.Write("Alter: ");
                        string? ageInput = Console.ReadLine();
                        if (int.TryParse(ageInput, out int age))
                        {
                            p.Alter = age;
                        }
                        else
                        {
                            Console.WriteLine("Ungültiges Alter. Standardwert 0 wird verwendet.");
                            p.Alter = 0;
                        }

                        // Fehlerbehandlung für den asynchronen Speichervorgang.
                        try
                        {
                            // 'await' wartet auf den Abschluss der I/O-Operation, ohne den Thread zu blockieren.
                            await service.SavePersonAsync(p);
                            Console.WriteLine("Gespeichert.");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Fehler bei der Eingabe: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Unbekannter Fehler beim Speichern: {ex.Message}");
                        }
                        break;

                    case "2":
                        Console.Write("Nachname der zu ladenden Person: ");
                        string name = Console.ReadLine() ?? string.Empty;

                        try
                        {
                            // Asynchrones Laden der Daten.
                            Person? geladen = await service.LoadPersonAsync(name);

                            if (geladen != null)
                            {
                                Console.WriteLine($"Geladen: {geladen.Vorname} {geladen.Nachname}, {geladen.Alter} Jahre");
                            }
                            else
                            {
                                Console.WriteLine("Datei nicht gefunden.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fehler beim Laden: {ex.Message}");
                        }
                        break;

                    case "3":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }
            }
        }
    }
}
