using System;
using System.Collections.Generic;

namespace Aufgabe_01_Array
{
    /// <summary>
    /// Hauptklasse der Anwendung für Aufgabe 01 (Arrays).
    /// Beinhaltet ein Untermenü für die verschiedenen Teilaufgaben.
    /// </summary>
    public class App
    {
        /// <summary>
        /// Standardkonstruktor (nicht benötigt, da statische Methoden).
        /// </summary>
        public App()
        {
        }

        /// <summary>
        /// Einstiegspunkt für den Controller (Entry Point).
        /// Startet die Schleife des Untermenüs.
        /// </summary>
        public static void Run()
        {
            bool running = true;
            while (running)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.Clear(); // Screen clear for cleanliness
                
                // --- Benutzermenü Ausgabe ---
                Console.WriteLine("=== Aufgabe 01: Arrays & Listen ===");
                Console.WriteLine("1 - Statistik (Array)");
                Console.WriteLine("2 - Lottozahlen (Array)");
                Console.WriteLine("3 - Binärzahlen (Array)");
                Console.WriteLine("4 - Mittelwert bereinigt (Array)");
                Console.WriteLine("5 - Statistik (List)");
                Console.WriteLine("6 - Lottozahlen (List)");
                Console.WriteLine("7 - Binärzahlen (List)");
                Console.WriteLine("8 - Mittelwert bereinigt (List)");
                Console.WriteLine("0 - ZURÜCK zum Hauptmenü");
                Console.Write("Auswahl: ");

                // Einlesen der Benutzereingabe
                string auswahl = Console.ReadLine() ?? ""; // Null-Coalescing für Sicherheit

                Console.WriteLine("\n---------------------------------\n");

                switch (auswahl)
                {
                    case "1": RunStatistik(); break;
                    case "2": RunLotto(); break;
                    case "3": RunBinary(); break;
                    case "4": RunMittel(); break;
                    case "5": RunStatistikLists(); break;
                    case "6": RunLottoLists(); break;
                    case "7": RunBinaryBinaryArray(); break;
                    case "8": RunMittelLists(); break;
                    case "0": running = false; break;
                    case "42": Console.WriteLine("Macht's gut und danke für den vielen Fisch. 🐟🐠"); break;
                    default: Console.WriteLine("Ungültige Auswahl."); break;
                }

                if (running)
                {
                    Console.WriteLine("\n---------------------------------");
                    Console.WriteLine("Beliebige Taste drücken...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// RunStatistik() Aufgabe 1: Erstellt ein Array mit Zufallszahlen und ermittelt statistische Werte.
        /// </summary>
        static void RunStatistik()
        {
            // Initialisierung und Deklaration
            int[] zahlen = new int[10];
            Random rng = new Random();

            // Variablen für die Statistik
            int minIndex = 0;
            int maxIndex = 0;
            int minValue = 100; // Startwert auf max. möglichen Wert setzen
            int maxValue = 0;   // Startwert auf min. möglichen Wert setzen
            int summe = 0;

            Console.WriteLine("--- Aufgabe 1: Statistik ---");
            Console.WriteLine("Array mit Zufallszahlen füllen:");

            for (int i = 0; i < zahlen.Length; i++)
            {
                // Zufallszahl zwischen 1 und 100 generieren
                zahlen[i] = rng.Next(1, 101);
                Console.WriteLine($"Zahl an Index {i}: {zahlen[i]}");

                summe += zahlen[i];

                if (zahlen[i] < minValue)
                {
                    minValue = zahlen[i];
                    minIndex = i;
                }

                if (zahlen[i] > maxValue)
                {
                    maxValue = zahlen[i];
                    maxIndex = i;
                }
            }

            double durchschnitt = (double)summe / zahlen.Length;

            Console.WriteLine($"\nMinimale Zahl: {minValue} (an Index {minIndex})");
            Console.WriteLine($"Maximale Zahl: {maxValue} (an Index {maxIndex})");
            Console.WriteLine($"Summe: {summe}");
            Console.WriteLine($"Durchschnitt: {durchschnitt:F2}");
        }

        /// <summary>
        /// Aufgabe 2: Simuliert die Ziehung von Lottozahlen (6 aus 49).
        /// </summary>
        static void RunLotto()
        {
            Console.WriteLine("--- Aufgabe 2: Lottozahlen ---");

            bool[] gezogeneZahlen = new bool[50];
            Random rnd = new Random();
            int anzahlGezogen = 0;

            while (anzahlGezogen < 6)
            {
                int zahl = rnd.Next(1, 50);

                if (gezogeneZahlen[zahl] == false)
                {
                    gezogeneZahlen[zahl] = true;
                    anzahlGezogen++;
                }
            }

            Console.WriteLine("Gezogene Zahlen (sortiert):");
            for (int i = 1; i < 50; i++)
            {
                if (gezogeneZahlen[i] == true)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine(); 
        }

        /// <summary>
        /// Aufgabe 3: Konvertiert eine Dezimalzahl (0-255) in eine 8-Bit Binärzahl.
        /// </summary>
        static void RunBinary()
        {
            Console.WriteLine("--- Aufgabe 3: Binärumrechnung ---");

            int[] binaerArray = new int[8];
            Console.Write("Eingabe Dezimalzahl (0-255): ");

            if (int.TryParse(Console.ReadLine(), out int dezimal) && dezimal >= 0 && dezimal <= 255)
            {
                for (int i = 7; i >= 0; i--)
                {
                    binaerArray[i] = dezimal % 2; 
                    dezimal = dezimal / 2;        
                }

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
        /// Aufgabe 4: Berechnet den bereinigten Mittelwert einer Zahlenreihe.
        /// </summary>
        static void RunMittel()
        {
            Console.WriteLine("--- Aufgabe 4: Mittelwert ohne Min/Max ---");
            Console.Write("Anzahl Zahlen: ");

            if (!int.TryParse(Console.ReadLine(), out int groesse) || groesse < 3)
            {
                Console.WriteLine("Fehler: Bitte eine gültige Ganzzahl (mindestens 3) eingeben.");
                return; 
            }

            int[] zahlen = new int[groesse];
            Random rnd = new Random();

            int summe = 0;
            int min = 100;
            int max = 0;

            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = rnd.Next(1, 100);
                Console.Write(zahlen[i] + (i < zahlen.Length - 1 ? ", " : ""));

                summe += zahlen[i];

                if (zahlen[i] < min) min = zahlen[i];
                if (zahlen[i] > max) max = zahlen[i];
            }

            int bereinigteSumme = summe - min - max;
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

            List<int> zahlenListe = new List<int>();
            Random rng = new Random();

            int summe = 0;
            int min = 101;
            int max = 0;

            Console.WriteLine("Liste wird gefüllt:");

            for (int i = 0; i < 10; i++)
            {
                int zufall = rng.Next(1, 101);

                zahlenListe.Add(zufall);
                Console.WriteLine($"Hinzugefügt: {zufall}");

                summe += zufall;
                if (zufall < min) min = zufall;
                if (zufall > max) max = zufall;
            }

            double durchschnitt = (double)summe / zahlenListe.Count;

            Console.WriteLine($"\nMinimale Zahl: {min}");
            Console.WriteLine($"Maximale Zahl: {max}");
            Console.WriteLine($"Summe: {summe}");
            Console.WriteLine($"Durchschnitt: {durchschnitt:F2}");
        }
        /// <summary>
        /// Aufgabe 6: Äquivalent zu Aufgabe 2 (Lotto), aber mit Lists.
        /// </summary>
        static void RunLottoLists()
        {
            Console.WriteLine("--- Aufgabe 6: Lotto mit List ---");

            List<int> lottoZahlen = new List<int>();
            Random rnd = new Random();

            while (lottoZahlen.Count < 6)
            {
                int ziehung = rnd.Next(1, 50);

                if (!lottoZahlen.Contains(ziehung))
                {
                    lottoZahlen.Add(ziehung);
                }
            }

            lottoZahlen.Sort();

            Console.WriteLine("Gezogene Zahlen (sortiert):");
            foreach (int zahl in lottoZahlen)
            {
                Console.Write(zahl + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Aufgabe 7: Äquivalent zu Aufgabe 3 (Binär), aber mit Lists.
        /// </summary>
        static void RunBinaryBinaryArray()
        {
            Console.WriteLine("--- Aufgabe 7: Binärumrechnung mit List ---");

            Console.Write("Eingabe Dezimalzahl (0-255): ");
            if (int.TryParse(Console.ReadLine(), out int dezimal) && dezimal >= 0 && dezimal <= 255)
            {
                List<int> binaerListe = new List<int>();

                for (int i = 0; i < 8; i++)
                {
                    int bit = dezimal % 2;
                    dezimal = dezimal / 2;
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

                Console.Write(wert + (i < anzahl - 1 ? ", " : ""));

                summe += wert;
                if (wert < min) min = wert;
                if (wert > max) max = wert;
            }

            int bereinigteSumme = summe - min - max;
            double schnitt = (double)bereinigteSumme / (zahlenListe.Count - 2);

            Console.WriteLine($"\n\nMittelwert (ohne {min} u. {max}): {schnitt:F2}");
            Console.ReadKey();
        }
    }
}