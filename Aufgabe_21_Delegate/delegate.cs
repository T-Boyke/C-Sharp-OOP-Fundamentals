using System;
using System.Collections.Generic;

/* ========================================================================
   BITLC LOGBUCH - 22. JANUAR 2026
   THEMA: DELEGATES, LAMBDAS & EXTENSION METHODS
   
   --- DIE AUFGABE (VON TOM DEM SEELIGEN) ---
   Es soll eine Methode Filter() entwickelt werden.
   Input: Eine List<string> und ein Delegate Func<string, bool>.
   Output: Eine neue List<string> mit den gefilterten Elementen.
   
   Teil A: Als normale Methode schreiben und testen.
   Teil B: In eine Extension Method umwandeln (Benjamin Style).
   ======================================================================== */

namespace KubilaysAbenteuer
{
    // --------------------------------------------------------------------
    // KAPITEL 1: DER HANDWERKS-ANSATZ
    // Kubilay, lay³, sitzt vor dem Code. Tom legt ihm die Hand auf die Schulter.
    // "Bevor wir zaubern, Kubilay, müssen wir das Handwerk verstehen.
    // Wir bauen eine Maschine, die Listen reinigt."
    // --------------------------------------------------------------------
    
    public class Program
    {
        public static void Main()
        {
            // Datenbasis: Kubilays Wortschatz
            List<string> worte = new List<string> { 
                "Delegate", "Action", "Tom", "Benjamin", "C#", "Tee", "Mokka" 
            };

            Console.WriteLine("--- KAPITEL 1: TOMS WEG (Klassisch) ---");

            // Kubilay nutzt Toms Methode. 
            // Er reicht den 'Zettel' (Lambda) rein: "Behalte nur Wörter länger als 3 Zeichen"
            List<string> langeWorte = TomsFilter.Filter(worte, s => s.Length > 3);
            
            Console.WriteLine("Lange Wörter: " + string.Join(", ", langeWorte));


            Console.WriteLine("\n--- KAPITEL 2: BENJAMINS WEG (Magie) ---");
            
            // Benjamin der Graue erscheint. "Pah! Statische Methodenaufrufe!"
            // Er tippt mit dem Zauberstab auf die Liste.
            // "Die Methode muss Teil der Liste werden. Sieh her!"
            
            // Dank der Extension Method (siehe unten) rufen wir Filter direkt AN der Liste auf.
            // Kubilay strahlt: "Es liest sich wie ein englischer Satz!"
            
            var bWorte = worte.MyFilter(w => w.StartsWith("B"));
            
            Console.WriteLine("Startet mit B: " + string.Join(", ", bWorte));

            // TERMINATOR MODE: Chaining
            // "Ich brauche keinen Zwischenspeicher. Ich brauche Ergebnisse."
            var komplex = worte
                          .MyFilter(w => w.Contains("e"))  // Erst alle mit 'e'
                          .MyFilter(w => w.Length < 5);    // Davon nur die kurzen
            
            Console.WriteLine("Enthält 'e' & kurz: " + string.Join(", ", komplex));
            
            Console.ReadKey();
        }
    }

    // --------------------------------------------------------------------
    // DIE UMSETZUNG (TEIL A)
    // Hier baut Tom die logische Struktur.
    // --------------------------------------------------------------------
    public class TomsFilter
    {
        public static List<string> Filter(List<string> inputListe, Func<string, bool> checkBedingung)
        {
            // 1. Leere Kiste bereitstellen
            List<string> ergebnis = new List<string>();

            // 2. Jedes Element anschauen
            foreach (string element in inputListe)
            {
                // 3. Den Delegate fragen (den 'Zettel' lesen)
                // Wenn der Lambda-Ausdruck 'true' sagt...
                if (checkBedingung(element)) 
                {
                    // ...dann ab in die Kiste.
                    ergebnis.Add(element);
                }
            }
            return ergebnis;
        }
    }

    // --------------------------------------------------------------------
    // DIE UMSETZUNG (TEIL B)
    // Benjamin der Graue macht die Methode 'statisch' und fügt 'this' hinzu.
    // WICHTIG: Extension Methods müssen in einer 'static class' wohnen!
    // --------------------------------------------------------------------
    public static class BenjaminsExtensions
    {
        // Das 'this' vor dem ersten Parameter ist der Zaubertrick.
        // Es sagt dem Compiler: "Häng diese Methode an jede List<string> dran!"
        public static List<string> MyFilter(this List<string> inputListe, Func<string, bool> checkBedingung)
        {
            List<string> ergebnis = new List<string>();

            foreach (string element in inputListe)
            {
                // Genau die gleiche Logik wie bei Tom, nur eleganter verpackt
                if (checkBedingung(element))
                {
                    ergebnis.Add(element);
                }
            }
            return ergebnis;
        }
    }
}
