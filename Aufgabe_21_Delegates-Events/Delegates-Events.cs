/* * ======================================================================================
 * AUFGABENSTELLUNG:
 * 1. Modellierung der Klasse 'Fluss' mit Name und Wasserstand (100 - 10.000).
 * 2. Implementierung einer Methode zur zufälligen Änderung des Wasserstands.
 * 3. Definition von zwei Events: Warnung bei < 250 (Niedrig) und > 8.000 (Hoch).
 * 4. Modellierung der Klasse 'Schiff' (Beobachter) mit Reaktion (Stopp) auf Gefahren.
 * 5. Testprogramm: Rhein (Rheingold, Lorelei) und Donau (Xaver, Franz).
 * ======================================================================================
 */

using System;
using System.Collections.Generic;

namespace WasserstandUeberwachung
{
    // ==================================================================================
    // ABSCHNITT 1: Die Definition des Delegaten und der Fluss-Klasse
    // Aufgabe: Erstelle die Klasse Fluss, die Events anbietet, wenn Grenzwerte verletzt werden.
    // Erwartetes Ergebnis: Eine Klasse, die sich selbst überwacht und bei Bedarf 'schreit'.
    // ==================================================================================

    // TOM DER SEELIGE (Dozent): "Hört mal kurz zu. Wir verwenden hier das Observer-Pattern.
    // Der Fluss ist das 'Subject', die Schiffe sind die 'Observer'. Events sind in C# nichts anderes
    // als kapselte Delegaten. Das ist klausurrelevant!"

    // ANAS DER SCHLAFENDE: "Mmmh... Observer... beobachtet mich jemand beim Schlafen? *gähn*"

    // BENJAMIN DER GRAUE: "Ein Fluss ist niemals derselbe, wenn man zweimal hineinsteigt.
    // Doch wenn er über die Ufer tritt, müssen wir bereit sein. Das Event ist unser Omen."

    /// <summary>
    /// Repräsentiert einen Fluss, dessen Pegelstand schwanken kann.
    /// </summary>
    public class Fluss
    {
        public string Name { get; }
        public int Wasserstand { get; private set; }
        private readonly Random _zufall = new Random();

        // Best Practice: Nutzung von EventHandler<T> ist der .NET Standard.
        // Hier definieren wir eigene Events für spezifische Szenarien.
        public event EventHandler<string> KritischerPegelZuHoch;
        public event EventHandler<string> KritischerPegelZuNiedrig;

        public Fluss(string name)
        {
            Name = name;
            // Initialer Wasserstand im sicheren Bereich
            Wasserstand = 5000; 
        }

        public void AendereWasserstand()
        {
            // Simuliert eine Änderung. Range 100 bis 10.000
            Wasserstand = _zufall.Next(100, 10001);

            // TOBI DER LAUTE: "ACHTUNG! DER WERT HAT SICH GEÄNDERT! ICH SEHE EINE " + Wasserstand + "!"
            
            PruefeGefahr();
        }

        private void PruefeGefahr()
        {
            // KUBI DER OSMANISCHE TEDDYBÄR: "Junge, 8000? Da säuft ja mein Bärenfell ab.
            // Und unter 250? Da sitz ich auf dem Trockenen wie in einer Shisha-Bar ohne Tabak."

            if (Wasserstand > 8000)
            {
                // Feuert das Event, wenn Abonnenten vorhanden sind (?.Invoke)
                KritischerPegelZuHoch?.Invoke(this, $"ACHTUNG: Hochwasser im {Name}! Pegel: {Wasserstand}");
            }
            else if (Wasserstand < 250)
            {
                KritischerPegelZuNiedrig?.Invoke(this, $"ACHTUNG: Niedrigwasser im {Name}! Pegel: {Wasserstand}");
            }
        }
    }

    // ==================================================================================
    // ABSCHNITT 2: Die Beobachter (Schiffe)
    // Aufgabe: Schiffe sollen auf die Rufe des Flusses reagieren und stoppen.
    // Erwartetes Ergebnis: Konsolenausgabe, sobald ein Event eintritt.
    // ==================================================================================

    // KAHN DER LANGE: "Ich sehe die Schiffe dort unten. Kleine Nussschalen. 
    // Aber wenn sie gut programmiert sind, hören sie auf den Fluss."

    // TOBI DER LAUTE: "STOPPEN! SOFORT STOPPEN! KEINE DISKUSSION!"

    public class Schiff
    {
        public string Name { get; }

        public Schiff(string name)
        {
            Name = name;
        }

        // Event-Handler Methode: Muss der Signatur des Events entsprechen (object sender, string message)
        public void BeiGefahrStoppen(object sender, string nachricht)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[SCHIFF {Name}]: Empfange Warnung -> '{nachricht}'. Ich stoppe sofort!");
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ==================================================================================
            // ABSCHNITT 3: Setup und Simulation
            // Aufgabe: Instanziierung der Objekte und Verknüpfung der Events (Abonnieren).
            // Erwartetes Ergebnis: Simulation von Pegeländerungen und Reaktion der passenden Schiffe.
            // ==================================================================================

            // TOM: "Jetzt verdrahten wir die Logik. Das '+=' ist entscheidend. Ohne das Abo hört keiner zu."

            // KUBI: "Kann ich den 'Rhein' auch mit Raki füllen? Nein? Langweilig."

            // 1. Flüsse erstellen
            Fluss rhein = new Fluss("Rhein");
            Fluss donau = new Fluss("Donau");

            // 2. Schiffe erstellen
            Schiff rheingold = new Schiff("Rheingold");
            Schiff lorelei = new Schiff("Lorelei");
            Schiff xaver = new Schiff("Xaver");
            Schiff franz = new Schiff("Franz");

            // 3. Events abonnieren (Wiring)
            // Rhein-Beobachter
            rhein.KritischerPegelZuHoch += rheingold.BeiGefahrStoppen;
            rhein.KritischerPegelZuNiedrig += rheingold.BeiGefahrStoppen;
            
            rhein.KritischerPegelZuHoch += lorelei.BeiGefahrStoppen;
            rhein.KritischerPegelZuNiedrig += lorelei.BeiGefahrStoppen;

            // Donau-Beobachter
            donau.KritischerPegelZuHoch += xaver.BeiGefahrStoppen;
            donau.KritischerPegelZuNiedrig += xaver.BeiGefahrStoppen;

            // ANAS: "Zzz... ist Xaver schon da? ... Egal."

            // ==================================================================================
            // ABSCHNITT 4: Der Testlauf
            // Aufgabe: Den Wasserstand mehrfach ändern, um Events zu provozieren.
            // Erwartetes Ergebnis: Zufällige Warnmeldungen auf der Konsole.
            // ==================================================================================

            // BENJAMIN: "Lass die Würfel rollen. Auch das Chaos hat eine Ordnung."
            
            Console.WriteLine("--- Simulation startet ---");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"\n--- Tag {i + 1} ---");
                
                // Wir ändern die Pegel
                rhein.AendereWasserstand();
                donau.AendereWasserstand();

                // Kurze Pause für Dramatik
                System.Threading.Thread.Sleep(200);
            }

            // KUBI: "Fertig? Gut. Wo ist jetzt dieser verdammte Honigtopf?"
            // TOBI: "PROGRAMM ENDE! ERFOLGREICH! KEINER IST ERTRUNKEN!"
            
            Console.WriteLine("\n--- Simulation beendet ---");
            Console.ReadLine();
        }
    }
}
