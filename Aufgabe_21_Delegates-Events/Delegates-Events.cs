/*
 * ==============================================================================================
 * AUFGABENSTELLUNG: Wasserstand 1
 * * 1. Modellieren Sie einen 'Fluss' mit Namen und Wasserstand (100 - 10.000).
 * 2. Der Fluss soll Methoden zur zufälligen Änderung des Wasserstands haben.
 * 3. Implementieren Sie zwei Events:
 * - Warnung bei Niedrigwasser (< 250)
 * - Warnung bei Hochwasser (> 8.000)
 * 4. Modellieren Sie 'Schiff' als Beobachter.
 * 5. Das Schiff muss auf die Events reagieren (Fahrt stoppen).
 * 6. Testlauf mit Rhein (Rheingold, Lorelei) und Donau (Xaver, Franz).
 * ==============================================================================================
 */

using System;

namespace WasserstandEvents;

// ==========================================================================================
// AUFGABE: Definition der Event-Daten (EventArgs)
// ERWARTETES ERGEBNIS: Eine Klasse, die den aktuellen Wasserstand transportiert.
// ==========================================================================================

// CHARAKTER-STORY:
// Osvaldo der Weiße: "Um Daten sauber zu übermitteln, benötigen wir eine strukturierte Klasse."
// Benjamin der Graue: "Ein einfacher Bote würde reichen, aber Osvaldo besteht auf Protokolle."
// Kubi der Osmanische Teddybär: "Ist mir egal, solange auf dem Zettel steht, wo die Sucuk ist."

/// <summary>
/// Beinhaltet die Daten für Wasserstands-Events.
/// </summary>
public class WaterLevelEventArgs : EventArgs
{
    /// <summary>
    /// Der aktuelle Wasserstand zum Zeitpunkt des Events.
    /// </summary>
    public int CurrentLevel { get; }

    /// <summary>
    /// Konstruktor für die Event-Daten.
    /// </summary>
    /// <param name="level">Der gemessene Wasserstand.</param>
    public WaterLevelEventArgs(int level)
    {
        CurrentLevel = level;
    }
}

// ==========================================================================================
// AUFGABE: Klasse Fluss (Publisher) implementieren
// ERWARTETES ERGEBNIS: Eine Klasse, die den Wasserstand ändert und bei Grenzwerten Events feuert.
// ==========================================================================================

/// <summary>
/// Repräsentiert einen Fluss, der seinen Wasserstand überwacht und Warnungen sendet.
/// </summary>
public class River
{
    // CHARAKTER-STORY:
    // Andrey der entspannte Russe: "Ein Fluss ist wie das Leben. Mal ruhig, mal wild. Man muss fließen."
    // Tobi das laute Runde: "UND MANCHMAL IST ER LAUT! WIE HOCHWASSER!"
    
    private int _waterLevel;
    private readonly Random _random = new Random();

    /// <summary>
    /// Der Name des Flusses.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Event, das ausgelöst wird, wenn der Pegel kritisch hoch ist (> 8000).
    /// </summary>
    public event EventHandler<WaterLevelEventArgs>? CriticalHigh;

    /// <summary>
    /// Event, das ausgelöst wird, wenn der Pegel kritisch niedrig ist (< 250).
    /// </summary>
    public event EventHandler<WaterLevelEventArgs>? CriticalLow;

    /// <summary>
    /// Erstellt eine neue Instanz eines Flusses.
    /// </summary>
    /// <param name="name">Name des Flusses (z.B. Rhein).</param>
    /// <param name="initialLevel">Start-Wasserstand.</param>
    public River(string name, int initialLevel)
    {
        Name = name;
        _waterLevel = initialLevel;
    }

    /// <summary>
    /// Ändert den Wasserstand zufällig und prüft auf Grenzwerte.
    /// </summary>
    /// <remarks>
    /// Generiert einen neuen Wert zwischen 100 und 10.000.
    /// Löst Events aus, wenn Grenzwerte überschritten/unterschritten werden.
    /// </remarks>
    public void ChangeWaterLevel()
    {
        // Tom der Seelige (Dozent): "Hier simulieren wir die Launen der Natur mittels Random."
        // Adil der Planlose Chiller: "Zufall? So wie meine Klausurergebnisse."
        
        _waterLevel = _random.Next(100, 10001);
        
        Console.WriteLine($"[FLUSS] Der Pegel des {Name} ändert sich auf: {_waterLevel}");

        // Prüfung auf Hochwasser
        if (_waterLevel > 8000)
        {
            // Tobi das laute Runde: "ACHTUNG! ALLES LÄUFT ÜBER! RETTET DAS ESSEN!"
            OnCriticalHigh(new WaterLevelEventArgs(_waterLevel));
        }
        // Prüfung auf Niedrigwasser
        else if (_waterLevel < 250)
        {
            // Kubi der Osmanische Teddybär: "Das ist ja weniger Wasser als Fett in meiner Sucuk! ALARM!"
            OnCriticalLow(new WaterLevelEventArgs(_waterLevel));
        }
    }

    /// <summary>
    /// Hilfsmethode zum Auslösen des Hochwasser-Events.
    /// </summary>
    /// <param name="e">Die Event-Daten.</param>
    protected virtual void OnCriticalHigh(WaterLevelEventArgs e)
    {
        // Safe Invocation mit ?. Operator
        CriticalHigh?.Invoke(this, e);
    }

    /// <summary>
    /// Hilfsmethode zum Auslösen des Niedrigwasser-Events.
    /// </summary>
    /// <param name="e">Die Event-Daten.</param>
    protected virtual void OnCriticalLow(WaterLevelEventArgs e)
    {
        CriticalLow?.Invoke(this, e);
    }
}

// ==========================================================================================
// AUFGABE: Klasse Schiff (Subscriber) implementieren
// ERWARTETES ERGEBNIS: Schiffe, die auf die Events reagieren und Nachrichten ausgeben.
// ==========================================================================================

/// <summary>
/// Repräsentiert ein Schiff, das einen Fluss beobachtet.
/// </summary>
public class Ship
{
    // CHARAKTER-STORY:
    // Sergej der frierende Schachspieler sitzt an Deck: "Wenn das Schiff stoppt, wird die Heizung ausgehen? Ich friere jetzt schon."
    // Kahn der Lange: "Ich stoß mir den Kopf an der Brücke, wenn das Wasser zu hoch ist."
    
    /// <summary>
    /// Name des Schiffes.
    /// </summary>
    public string Name { get; }

    public Ship(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Reagiert auf zu hohen Wasserstand.
    /// </summary>
    /// <param name="sender">Der Auslöser (Fluss).</param>
    /// <param name="e">Die Daten zum Wasserstand.</param>
    public void OnHighWater(object? sender, WaterLevelEventArgs e)
    {
        // Benjamin der Graue (Gandalf-Stimme): "Du kannst nicht vorbei! Die Fluten sind zu mächtig!"
        var river = sender as River;
        Console.WriteLine($" -> SCHIFF {Name}: Stoppt Motoren auf {river?.Name}! Zu viel Wasser ({e.CurrentLevel}). Gefahr von Brückenkollision (Kahn pass auf!).");
    }

    /// <summary>
    /// Reagiert auf zu niedrigen Wasserstand.
    /// </summary>
    /// <param name="sender">Der Auslöser (Fluss).</param>
    /// <param name="e">Die Daten zum Wasserstand.</param>
    public void OnLowWater(object? sender, WaterLevelEventArgs e)
    {
        // Anas der Schlafende wacht kurz auf: "Hä? Sind wir auf Grund gelaufen? *gähn* Weiterpennen."
        var river = sender as River;
        Console.WriteLine($" -> SCHIFF {Name}: Wirft Anker auf {river?.Name}! Zu wenig Wasser ({e.CurrentLevel}). Wir sitzen fest.");
    }
}

// ==========================================================================================
// AUFGABE: Hauptprogramm (Main)
// ERWARTETES ERGEBNIS: Instanziierung der Objekte, Verknüpfung der Events und Simulation.
// ==========================================================================================

class Program
{
    static void Main()
    {
        // CHARAKTER-STORY:
        // Tom der Seelige: "So, jetzt verdrahten wir das Ganze. Passt gut auf!"
        // Osvaldo der Weiße: "Die Architektur muss stimmen. Dependency Injection wäre besser, aber für heute reicht 'new'."
        
        Console.WriteLine("--- Simulation gestartet: 23. Januar 2026 ---");

        // 1. Flüsse erstellen
        River rhein = new River("Rhein", 5000);
        River donau = new River("Donau", 5000);

        // 2. Schiffe erstellen
        Ship rheingold = new Ship("Rheingold");
        Ship lorelei = new Ship("Lorelei");
        Ship xaver = new Ship("Xaver");
        Ship franz = new Ship("Franz");

        // 3. Abonnieren der Events (Subscription)
        // Rhein-Beobachter
        rhein.CriticalHigh += rheingold.OnHighWater;
        rhein.CriticalLow += rheingold.OnLowWater;
        
        rhein.CriticalHigh += lorelei.OnHighWater;
        rhein.CriticalLow += lorelei.OnLowWater;

        // Donau-Beobachter
        donau.CriticalHigh += xaver.OnHighWater;
        donau.CriticalLow += xaver.OnLowWater;

        donau.CriticalHigh += franz.OnHighWater;
        donau.CriticalLow += franz.OnLowWater;

        // 4. Simulation durchführen
        // Kubi drückt wild Knöpfe: "Mach mal Wellen jetzt!"
        Console.WriteLine("\n--- Simuliere Wasserstandsänderungen ---");

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\n--- Durchlauf {i + 1} ---");
            rhein.ChangeWaterLevel();
            donau.ChangeWaterLevel();
            
            // Kurze Pause für die Dramatik (Andrey atmet tief ein und aus)
            System.Threading.Thread.Sleep(500); 
        }

        Console.WriteLine("\n--- Simulation beendet. Adil geht jetzt chillen. ---");
    }
}
