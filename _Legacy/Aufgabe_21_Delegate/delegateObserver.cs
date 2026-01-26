using System;
using System.Collections.Generic;

/* ========================================================================
   BITLC LOGBUCH - 22. JANUAR 2026 - TEIL C
   THEMA: OBSERVER PATTERN, INTERFACES & DELEGATES
   
   --- DIE LEKTION VON KAHN DEM GROSSEN ---
   "Kubilay", grollt Kahn. "Tom und Benjamin denken in Listen. 
   Aber was, wenn die Daten nicht in einer Liste liegen, sondern LIVE passieren?
   Wir bauen ein System, das auf Ereignisse reagiert."
   
   Zutaten:
   1. Interface (Der Vertrag): Damit wir nicht wissen müssen, WER zuhört.
   2. Observer Pattern (Das Muster): Einer schreit, viele hören zu.
   3. Delegate (Die Logik): Jeder Zuhörer entscheidet selbst, was er mag.
   ======================================================================== */

namespace KubilaysAbenteuer
{
    // --------------------------------------------------------------------
    // SCHRITT 1: DIE VERTRÄGE (INTERFACES)
    // Kahn legt zwei Schriftrollen auf den Tisch.
    // "Niemand spricht direkt miteinander. Wir sprechen nur über Protokolle."
    // --------------------------------------------------------------------

    // Der Beobachter (Zuhörer): Muss fähig sein, ein Wort zu empfangen.
    public interface IBeobachter
    {
        void EmpfangeWort(string wort);
    }

    // Das Subjekt (Sender): Man muss sich bei ihm anmelden können.
    public interface IMarktschreier
    {
        void Anmelden(IBeobachter beobachter);
        void Abmelden(IBeobachter beobachter);
        void Schreie(string wort);
    }

    // --------------------------------------------------------------------
    // SCHRITT 2: DIE IMPLEMENTIERUNG (DIE MASCHINERIE)
    // --------------------------------------------------------------------

    // Der Marktschreier (Subject)
    // Er kennt seine Zuhörer nicht persönlich, er weiß nur, dass sie IBeobachter sind.
    public class MarktplatzSender : IMarktschreier
    {
        // Eine Liste von Interfaces - maximale Flexibilität!
        private List<IBeobachter> _zuhörerListe = new List<IBeobachter>();

        public void Anmelden(IBeobachter beobachter)
        {
            _zuhörerListe.Add(beobachter);
            Console.WriteLine($"[Marktplatz] Ein neuer Zuhörer ist beigetreten.");
        }

        public void Abmelden(IBeobachter beobachter)
        {
            _zuhörerListe.Remove(beobachter);
        }

        // Wenn er schreit, benachrichtigt er alle in der Liste.
        public void Schreie(string wort)
        {
            Console.WriteLine($"\n[Marktplatz] RUFT: '{wort}'");
            foreach (var z in _zuhörerListe)
            {
                z.EmpfangeWort(wort);
            }
        }
    }

    // Der spezialisierte Zuhörer (Observer)
    // Hier verbinden wir das Pattern mit dem DELEGATE.
    public class SelektiverZuhoerer : IBeobachter
    {
        private string _name;
        private Func<string, bool> _filterStrategie; // Das Delegate!

        // Konstruktor: Wir injizieren den Namen UND die Filterlogik
        public SelektiverZuhoerer(string name, Func<string, bool> filter)
        {
            _name = name;
            _filterStrategie = filter;
        }

        public void EmpfangeWort(string wort)
        {
            // Hier entscheidet der Delegate, ob reagiert wird
            if (_filterStrategie(wort))
            {
                Console.WriteLine($"   -> {_name} freut sich: '{wort}' passt zu meinem Filter!");
            }
            else
            {
                // Optional: Ignorieren visualisieren
                // Console.WriteLine($"   -> {_name} ignoriert '{wort}'."); 
            }
        }
    }

    // --------------------------------------------------------------------
    // KAPITEL 3: KAHNS FELDZUG (MAIN)
    // --------------------------------------------------------------------
    public class ProgramC
    {
        public static void Main()
        {
            Console.WriteLine("--- KAPITEL 3: KAHNS ARCHITEKTUR ---");

            // 1. Wir erstellen den Sender (Subject)
            MarktplatzSender marktplatz = new MarktplatzSender();

            // 2. Wir erstellen verschiedene Zuhörer (Observer) mit unterschiedlichen Delegates
            //    Kubilay merkt: "Das ist wie Toms Filter, aber fest im Objekt verbaut!"
            
            // Ein Zuhörer, der nur kurze Wörter mag
            var kurzhoerer = new SelektiverZuhoerer("Der Eilige", w => w.Length <= 3);

            // Ein Zuhörer, der nur Wörter mit 'B' mag (Case Insensitive)
            var bFan = new SelektiverZuhoerer("Bert", w => w.StartsWith("B", StringComparison.OrdinalIgnoreCase));

            // Ein komplexer Zuhörer (Lambda Block)
            var kritiker = new SelektiverZuhoerer("Der Kritiker", w => 
            {
                return w.Contains("e") && w.Length > 4;
            });

            // 3. Anmeldung am Marktplatz
            marktplatz.Anmelden(kurzhoerer);
            marktplatz.Anmelden(bFan);
            marktplatz.Anmelden(kritiker);

            // 4. Action! Der Marktplatz schreit Wörter in den Raum.
            //    Beachte: Wir filtern keine Liste mehr. Wir verarbeiten einen DATENSTROM.
            List<string> worte = new List<string> { "Tom", "Benjamin", "Kahn", "Tee", "Brot", "Delegate" };

            foreach(var w in worte)
            {
                marktplatz.Schreie(w);
            }

            Console.ReadKey();
        }
    }
}
