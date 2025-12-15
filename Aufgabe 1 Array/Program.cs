using System;
using System.Collections.Generic;

namespace ArrayUebungen
{
    /// <summary>
    /// Hauptklasse der Anwendung. Beinhaltet ein Auswahlmenü für den Benutzer.
    /// </summary>
    internal class Program
    {
        public Program()
        {
        }

        /// <summary>
        /// Einstiegspunkt der Anwendung (Entry Point).
        /// Stellt das Benutzermenü bereit und steuert den Programmfluss.
        /// </summary>
        /// <param name="args">Kommandozeilenargumente (hier nicht verwendet).</param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // --- Benutzermenü Ausgabe ---
            Console.WriteLine("Welche Aufgabe soll ausgeführt werden?");
            Console.WriteLine("1 - Statistik (Aufgabe 1)");
            Console.WriteLine("2 - Lottozahlen (Aufgabe 2)");
            Console.WriteLine("3 - Binärzahlen 1 (Aufgabe 3)");
            Console.WriteLine("4 - Mittelwert ohne Min und Max (Aufgabe 4)");
            Console.WriteLine("5 - Aufgabe 1 mit Lists");
            Console.WriteLine("6 - Aufgabe 2 ");
            Console.WriteLine("7 - Aufgabe 3 ");
            Console.WriteLine("8 - Aufgabe 4 ");
            Console.Write("Auswahl: ");

            // Einlesen der Benutzereingabe
            string auswahl = Console.ReadLine();

            Console.WriteLine("\n---------------------------------\n");

            // --- Steuerung der Programmlogik ---
            // Verzweigung basierend auf der User-Eingabe
            if (auswahl == "1")
            {
                RunStatistik();
            }
            else if (auswahl == "2")
            {
                RunLotto();
            }
            else if (auswahl == "3")
            {
                RunBinary();
            }
            else if (auswahl == "4")
            {
                RunMittel();
            }
            else if (auswahl == "5")
            {
                // Platzhalter für Aufgabe 5 mit Lists
                RunStatistikLists();
            }
            else if (auswahl == "6")
            {
                // Platzhalter für Aufgabe 6
                RunLottoLists();
            }
            else if (auswahl == "7")
            {
                // Platzhalter für Aufgabe 7
                RunBinaryBinaryArray();
            }
            else if (auswahl == "8")
            {
                // Platzhalter für Aufgabe 8
                RunMittelLists();
            }
            else if (auswahl == "42")
            {
                // Easter Egg
                Console.WriteLine("Macht's gut und danke für den vielen Fisch. 🐟🐠");
            }
            else
            {
                // Fehlerfall: Ungültige Eingabe abfangen
                Console.WriteLine("Ungültige Auswahl.");
            }

            // Programmende verzögern, damit das Konsolenfenster offen bleibt
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("Drücke eine Taste zum Beenden...");
            Console.ReadKey();
        }

        /// <summary>
        /// RunStatistik() Aufgabe 1: Erstellt ein Array mit Zufallszahlen und ermittelt statistische Werte (Minimum, Maximum, Summe, Durchschnitt).
        /// </summary>
        static void RunStatistik()
        {
            // Initialisierung und Deklaration
            int[] zahlen = new int[10];
            Random rng = new Random();

            // Variablen für die Statistik
            int minIndex = 0;
            int maxIndex = 0;
            int minValue = 100; // Startwert auf max. möglichen Wert setzen (für Vergleich)
            int maxValue = 0;   // Startwert auf min. möglichen Wert setzen
            int summe = 0;

            Console.WriteLine("--- Aufgabe 1: Statistik ---");
            Console.WriteLine("Array mit Zufallszahlen füllen:");

            // Iteration über das Array zur Befüllung und gleichzeitigen Auswertung
            // (Effizienz: O(n) - nur ein Durchlauf nötig)
            for (int i = 0; i < zahlen.Length; i++)
            {
                // Zufallszahl zwischen 1 und 100 generieren
                zahlen[i] = rng.Next(1, 101);
                Console.WriteLine($"Zahl an Index {i}: {zahlen[i]}");

                // Laufende Summe bilden
                summe += zahlen[i];

                // Minimum prüfen
                if (zahlen[i] < minValue)
                {
                    minValue = zahlen[i];
                    minIndex = i;
                }

                // Maximum prüfen
                if (zahlen[i] > maxValue)
                {
                    maxValue = zahlen[i];
                    maxIndex = i;
                }
            }

            // Durchschnitt berechnen, double notwendig für floaty-Division
            double durchschnitt = (double)summe / zahlen.Length;

            // --- Ausgabe der Ergebnisse ---
            Console.WriteLine($"\nMinimale Zahl: {minValue} (an Index {minIndex})");
            Console.WriteLine($"Maximale Zahl: {maxValue} (an Index {maxIndex})");
            Console.WriteLine($"Summe: {summe}");
            // Formatierung F2 begrenzt die Ausgabe auf 2 Nachkommastellen
            Console.WriteLine($"Durchschnitt: {durchschnitt:F2}");
        }

        /// <summary>
        /// Aufgabe 2: Simuliert die Ziehung von Lottozahlen (6 aus 49). Verwendet ein Boolean-Array zur Vermeidung von doppelten ergebnissen.
        /// </summary>
        static void RunLotto()
        {
            Console.WriteLine("--- Aufgabe 2: Lottozahlen ---");

            // Boolean-Array der Größe 50 (Index 0 wird ignoriert, Nutzung Index 1-49).
            // false = Zahl noch nicht gezogen, true = Zahl bereits gezogen.
            bool[] gezogeneZahlen = new bool[50];
            Random rnd = new Random();
            int anzahlGezogen = 0;

            // Solange wiederholen, bis 6 eindeutige Zahlen gefunden
            while (anzahlGezogen < 6)
            {
                int zahl = rnd.Next(1, 50);

                // wurde die Zahl schon gezogen?
                if (gezogeneZahlen[zahl] == false)
                {
                    gezogeneZahlen[zahl] = true; // Markieren gezogen
                    anzahlGezogen++;
                }
            }

            // --- Ausgabe ---
            // Durch Iteration über das Array erfolgt die Ausgabe automatisch sortiert.
            Console.WriteLine("Gezogene Zahlen (sortiert):");
            for (int i = 1; i < 50; i++)
            {
                if (gezogeneZahlen[i] == true)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine(); // Zeilenumbruch für sauberes Layout
        }

        /// <summary>
        /// Aufgabe 3: Konvertiert eine Dezimalzahl (0-255) in eine 8-Bit Binärzahl. Verwendet das Divisionsrestverfahren (Modulo).
        /// </summary>
        static void RunBinary()
        {
            Console.WriteLine("--- Aufgabe 3: Binärumrechnung ---");

            int[] binaerArray = new int[8];
            Console.Write("Eingabe Dezimalzahl (0-255): ");

            // TryParse Verhindert Absturz bei Fehleingaben
            if (int.TryParse(Console.ReadLine(), out int dezimal) && dezimal >= 0 && dezimal <= 255)
            {
                // Algorithmus: Dezimal zu Binär (Modulo 2)
                // Die Schleife läuft rückwärts, damit das Array direkt in der richtigen Lesereihenfolge befüllt wird.
                for (int i = 7; i >= 0; i--)
                {
                    binaerArray[i] = dezimal % 2; // Rest (Bit) speichern
                    dezimal = dezimal / 2;        // Ganzzahlige Division für nächsten Schritt
                }

                // Ausgabe des Arrays
                Console.Write("Ergebnis Binärzahl: ");
                foreach (int bit in binaerArray)
                {
                    Console.Write(bit);
                }
            }
            else
            {
                Console.WriteLine("Fehler: Bitte eine gültige Ganzzahl zwischen 0 und 255 eingeben.");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Aufgabe 4: Berechnet den bereinigten Mittelwert einer Zahlenreihe, indem der kleinste und der größte Wert aus der Berechnung ausgeschlossen werden.
        /// </summary>
        static void RunMittel()
        {
            Console.WriteLine("--- Aufgabe 4: Mittelwert ohne Min/Max ---");
            Console.Write("Anzahl Zahlen: ");

            // Eingabe validieren:
            // 1. int.TryParse versucht, den String in eine Zahl zu wandeln.
            //    - Klappt es? -> Ergebnis landet in 'groesse', Methode gibt true zurück.
            //    - Klappt nicht? -> 'groesse' wird 0, Methode gibt false zurück.
            // 2. Wir prüfen zusätzlich, ob die Zahl < 3 ist.
            if (!int.TryParse(Console.ReadLine(), out int groesse) || groesse < 3)
            {
                Console.WriteLine("Fehler: Bitte eine gültige Ganzzahl (mindestens 3) eingeben.");
                return; // Vorzeitiger Abbruch
            }

            // Ab hier ist die Variable 'groesse' sicher initialisiert und >= 3.

            int[] zahlen = new int[groesse];
            Random rnd = new Random();

            int summe = 0;
            // Initialisierung von Min/Max so, dass sie beim ersten Vergleich garantiert überschrieben werden
            int min = 100;
            int max = 0;

            // Füllen und sammeln der Zahlen
            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = rnd.Next(1, 100);

                // Kommasetzung bei der Ausgabe
                Console.Write(zahlen[i] + (i < zahlen.Length - 1 ? ", " : ""));

                summe += zahlen[i];

                // Min/Max Bestimmung
                if (zahlen[i] < min) min = zahlen[i];
                if (zahlen[i] > max) max = zahlen[i];
            }

            // Bereinigung der Gesamtsumme
            int bereinigteSumme = summe - min - max;

            // Berechnung des Schnitts
            double bereinigterSchnitt = (double)bereinigteSumme / (groesse - 2);

            Console.WriteLine("\n\nMittelwert ohne Min und Max: " + bereinigterSchnitt);
            Console.ReadKey();
        }
        /// <summary>
        /// Aufgabe 5: Äquivalent zu Aufgabe 1, aber mit List
        /// </summary>
        static void RunStatistikLists()
        {
            Console.WriteLine("--- Aufgabe 5: Statistik mit List ---");

            // Instanziierung der Liste (Größe ist dynamisch)
            List<int> zahlenListe = new List<int>();
            Random rng = new Random();

            // Statistik-Variablen
            int summe = 0;
            int min = 101;
            int max = 0;

            Console.WriteLine("Liste wird gefüllt:");

            // Füllen der Liste
            for (int i = 0; i < 10; i++)
            {
                int zufall = rng.Next(1, 101);

                // Hinzufügen zur Liste
                zahlenListe.Add(zufall);
                Console.WriteLine($"Hinzugefügt: {zufall}");

                // Berechnung (identisch zu Array, aber Zugriff über Liste)
                summe += zufall;
                if (zufall < min) min = zufall;
                if (zufall > max) max = zufall;
            }

            // Listen haben eine Property 'Count' statt 'Length'
            double durchschnitt = (double)summe / zahlenListe.Count;

            Console.WriteLine($"\nMinimale Zahl: {min}");
            Console.WriteLine($"Maximale Zahl: {max}");
            Console.WriteLine($"Summe: {summe}");
            Console.WriteLine($"Durchschnitt: {durchschnitt:F2}");
        }
        /// <summary>
        /// Aufgabe 6: Äquivalent zu Aufgabe 2 (Lotto), aber mit Lists. Nutzt .Contains() zur Duplikatprüfung und .Sort() zum Sortieren.
        /// </summary>
        static void RunLottoLists()
        {
            Console.WriteLine("--- Aufgabe 6: Lotto mit List ---");

            List<int> lottoZahlen = new List<int>();
            Random rnd = new Random();

            // Solange wir noch keine 6 Zahlen haben
            while (lottoZahlen.Count < 6)
            {
                int ziehung = rnd.Next(1, 50);

                // WICHTIG: Prüfung mit .Contains() ist viel einfacher als Boolean-Array
                if (!lottoZahlen.Contains(ziehung))
                {
                    lottoZahlen.Add(ziehung);
                }
            }

            // Sortieren der Liste (passiert 'in-place')
            lottoZahlen.Sort();

            Console.WriteLine("Gezogene Zahlen (sortiert):");
            // Ausgabe mittels foreach (einfacher als for-Schleife)
            foreach (int zahl in lottoZahlen)
            {
                Console.Write(zahl + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Aufgabe 7: Äquivalent zu Aufgabe 3 (Binär), aber mit Lists.Nutzt .Insert(0, bit), um die Reihenfolge direkt richtig zu haben.
        /// </summary>
        static void RunBinaryBinaryArray()
        {
            Console.WriteLine("--- Aufgabe 7: Binärumrechnung mit List ---");

            Console.Write("Eingabe Dezimalzahl (0-255): ");
            if (int.TryParse(Console.ReadLine(), out int dezimal) && dezimal >= 0 && dezimal <= 255)
            {
                List<int> binaerListe = new List<int>();

                // Wir simulieren fest 8 Bit, indem wir 8 mal loopen
                for (int i = 0; i < 8; i++)
                {
                    int bit = dezimal % 2;
                    dezimal = dezimal / 2;

                    // .Insert(0, wert) fügt AM ANFANG ein.
                    // Das erspart uns das Rückwärts-Laufen oder Umdrehen der Liste.
                    binaerListe.Insert(0, bit);
                }

                Console.Write("Ergebnis Binärzahl: ");
                foreach (int bit in binaerListe)
                {
                    Console.Write(bit);
                }
            }
            else
            {
                Console.WriteLine("Fehler: Bitte eine gültige Zahl eingeben.");
            }
            Console.WriteLine();
            return;
        }

        /// <summary>
        /// Aufgabe 8: Äquivalent zu Aufgabe 4 (Mittelwert bereinigt), aber mit Lists.
        /// </summary>
        static void RunMittelLists()
        {
            Console.WriteLine("--- Aufgabe 8: Mittelwert bereinigt mit List ---");
            Console.Write("Anzahl Zahlen: ");

            if (!int.TryParse(Console.ReadLine(), out int anzahl) || anzahl < 3)
            {
                Console.WriteLine("Fehler: Mindestens 3 eingeben.");
                return;
            }

            List<int> zahlenListe = new List<int>();
            Random rnd = new Random();
            int summe = 0;
            int min = 100;
            int max = 0;

            for (int i = 0; i < anzahl; i++)
            {
                int wert = rnd.Next(1, 100);
                zahlenListe.Add(wert);

                // Formatierte Ausgabe
                Console.Write(wert + (i < anzahl - 1 ? ", " : ""));

                // Werte akkumulieren
                summe += wert;
                if (wert < min) min = wert;
                if (wert > max) max = wert;
            }

            // Berechnung wie gehabt
            int bereinigteSumme = summe - min - max;
            double schnitt = (double)bereinigteSumme / (zahlenListe.Count - 2);

            Console.WriteLine($"\n\nMittelwert (ohne {min} u. {max}): {schnitt:F2}");
            // hier soll es wieder zur Main-Methode zurückkehren
            Console.ReadKey();
        }
    }
}