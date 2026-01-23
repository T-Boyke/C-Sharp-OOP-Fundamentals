/*
 * ==============================================================================================
 * AUFGABENSTELLUNG: Wasserstand 3 (Data Logging & Export)
 * 1. Erweitere das Modell, um Zeitstempel (DateTime) statt nur Stunden-Integers zu nutzen.
 * 2. Speichere die Historie der Wasserstände.
 * 3. Generiere einen strukturierten Output (CSV-Format: Zeit;Pegel), der für Graphen nutzbar ist.
 * 4. (Optional) Zeige eine primitive ASCII-Grafik in der Konsole an.
 * ==============================================================================================
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace WasserstandEvents;

// ==========================================================================================
// AUFGABE: Datenstruktur für Messwerte definieren
// ERWARTETES ERGEBNIS: Ein unveränderlicher Datensatz (Record) für Zeit und Wert.
// ==========================================================================================

/// <summary>
/// Repräsentiert einen einzelnen Messpunkt im Graphen.
/// </summary>
/// <param name="Timestamp">Der Zeitpunkt der Messung.</param>
/// <param name="Level">Der gemessene Wasserstand in cm.</param>
public record WaterDataPoint(DateTime Timestamp, int Level);

// ==========================================================================================
// AUFGABE: River-Klasse mit Historie
// ERWARTETES ERGEBNIS: Der Fluss speichert nun seine eigenen Vergangenheitswerte.
// ==========================================================================================

/// <summary>
/// Ein Fluss, der seine Wasserstände über die Zeit aufzeichnet.
/// </summary>
public class River
{
    // CHARAKTER-STORY:
    // Osvaldo der Weiße: "Daten sind das neue Gold. Wir müssen alles archivieren!"
    // Adil der Planlose Chiller: "Brauchen wir echt alles? Mein Speicher ist voll mit Memes."
    // Benjamin der Graue: "Die Geschichte darf nicht vergessen werden, Adil."

    private readonly List<WaterDataPoint> _history = new();
    private readonly Random _random = new();
    private readonly int _meanLevel;
    private readonly int _amplitude;
    private readonly double _frequency;

    /// <summary>
    /// Der Name des Flusses.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Liste aller aufgezeichneten Messpunkte.
    /// </summary>
    public IReadOnlyList<WaterDataPoint> History => _history.AsReadOnly();

    /// <summary>
    /// Initialisiert den Fluss.
    /// </summary>
    /// <param name="name">Name des Gewässers.</param>
    /// <param name="meanLevel">Mittelwert.</param>
    /// <param name="amplitude">Schwankungsbreite.</param>
    public River(string name, int meanLevel, int amplitude)
    {
        Name = name;
        _meanLevel = meanLevel;
        _amplitude = amplitude;
        _frequency = 0.2; // Etwas schnellere Frequenz für schönere Kurven
    }

    /// <summary>
    /// Berechnet den Pegel für einen spezifischen Zeitpunkt und speichert ihn.
    /// </summary>
    /// <param name="time">Der aktuelle Zeitpunkt.</param>
    /// <remarks>
    /// Nutzt eine Sinus-Funktion basierend auf Ticks/Stunden für Determinismus.
    /// </remarks>
    public void RecordMeasurement(DateTime time)
    {
        // Wir nutzen den Stunden-Unterschied zum Start des Jahres für die Sinus-Berechnung
        double hoursArg = (time - new DateTime(time.Year, 1, 1)).TotalHours;

        // Berechnung: Basis + Sinus + Rauschen
        double sine = Math.Sin(hoursArg * _frequency);
        int noise = _random.Next(-50, 51);
        int currentLevel = _meanLevel + (int)(sine * _amplitude) + noise;

        if (currentLevel < 0) currentLevel = 0;

        // CHARAKTER-STORY:
        // Anas der Schlafende schreibt im Halbschlaf die Zahlen auf.
        // Hoffentlich sind sie lesbar.
        _history.Add(new WaterDataPoint(time, currentLevel));
    }
}

// ==========================================================================================
// AUFGABE: Export-Logik (CSV & ASCII)
// ERWARTETES ERGEBNIS: Formatierte Strings für Excel oder Konsole.
// ==========================================================================================

/// <summary>
/// Hilfsklasse zum Exportieren von Flussdaten.
/// </summary>
public static class GraphExporter
{
    // CHARAKTER-STORY:
    // Tom der Seelige: "Eine saubere Formatierung ist das A und O einer jeden Abgabe."
    // Kubi der Osmanische Teddybär: "Kann man das essen? Sieht aus wie eine Speisekarte."
    // Sergej der frierende Schachspieler: "E4 nach H5... oh, das sind Wasserstände, keine Züge."

    /// <summary>
    /// Erzeugt einen CSV-String (Comma Separated Values) für den Import in Excel.
    /// </summary>
    /// <param name="river">Der Fluss, dessen Daten exportiert werden sollen.</param>
    /// <returns>Ein mehrzeiliger String im Format "Datum;Pegel".</returns>
    /// <example>
    /// <code>
    /// string csv = GraphExporter.GetCsvOutput(meinFluss);
    /// File.WriteAllText("daten.csv", csv);
    /// </code>
    /// </example>
    public static string GetCsvOutput(River river)
    {
        StringBuilder sb = new StringBuilder();
        
        // Header für CSV
        sb.AppendLine("Zeitstempel;Wasserstand_cm");

        foreach (var point in river.History)
        {
            // Formatierung: Deutsches Datumsformat, Semikolon als Trenner
            sb.AppendLine($"{point.Timestamp:dd.MM.yyyy HH:mm};{point.Level}");
        }

        return sb.ToString();
    }

    /// <summary>
    /// Erzeugt eine einfache visuelle Repräsentation für die Konsole.
    /// </summary>
    /// <param name="river">Der zu visualisierende Fluss.</param>
    public static void PrintConsoleGraph(River river)
    {
        Console.WriteLine($"\n--- ASCII Graph für: {river.Name} ---");
        Console.WriteLine("Datum/Zeit       | Pegel (visualisiert)");
        Console.WriteLine("-----------------|-----------------------------------------");

        foreach (var point in river.History)
        {
            // Skalierung: Wir teilen durch 200, damit der Balken auf den Bildschirm passt.
            // Tobi das laute Runde: "MACH DEN BALKEN LÄNGER!! MEHR!!"
            int barLength = point.Level / 200; 
            string bar = new string('#', barLength); // Erstellt einen String aus '#'
            
            // Warnfarben Logik
            if (point.Level > 8000) Console.ForegroundColor = ConsoleColor.Red;
            else if (point.Level < 2000) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{point.Timestamp:dd.MM HH:mm} | {point.Level,5} {bar}");
        }
        Console.ResetColor();
    }
}

// ==========================================================================================
// AUFGABE: Main Program execution
// ==========================================================================================

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Datenerfassung gestartet ---");

        // 1. Setup
        // Andrey der entspannte Russe stellt die Messgeräte auf. "Keine Hektik."
        River rhein = new River("Rhein", 5000, 3500);
        DateTime startTime = new DateTime(2026, 01, 23, 8, 0, 0); // Start: 23. Jan 2026, 08:00

        // 2. Simulation (Wir simulieren 24 Stunden in 1-Stunden-Schritten)
        for (int i = 0; i < 24; i++)
        {
            DateTime currentTime = startTime.AddHours(i);
            rhein.RecordMeasurement(currentTime);
        }

        // 3. Output CSV (Der rohe Daten-Output)
        Console.WriteLine("\n[CSV EXPORT START - Kopiere das in Excel]");
        string csvData = GraphExporter.GetCsvOutput(rhein);
        Console.WriteLine(csvData);
        Console.WriteLine("[CSV EXPORT ENDE]");

        // 4. Output Visuell (Für Kubi, damit er bunte Farben sieht)
        // Kubi: "Ooooh, das Rote sieht gefährlich aus. Wie scharfe Soße."
        GraphExporter.PrintConsoleGraph(rhein);

        Console.WriteLine("\n--- Analyse beendet. Kahn der Lange hat sich nicht den Kopf gestoßen. ---");
    }
}
