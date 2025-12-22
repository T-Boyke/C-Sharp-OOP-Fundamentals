using System;

namespace Aufgabe_04_Static_Member
{
    /// <summary>
    /// Repräsentiert ein einzelnes Warenhaus.
    /// Demonstriert den Unterschied zwischen Instanz-Daten (pro Filiale) 
    /// und statischen Daten (Konzern-Gesamtwerte).
    /// </summary>
    public class Warenhaus
    {
        // ==========================================
        // KONSTANTEN
        // ==========================================
        // Konstanten vermeiden "Magic Numbers" im Code.
        // 'decimal' wird für Währungen verwendet, um Rundungsfehler zu vermeiden.
        private const decimal EINKAUFSPREIS = 10m;
        private const decimal VERKAUFSPREIS = 20m;

        // ==========================================
        // STATISCHE FELDER (Globaler State)
        // ==========================================
        // Diese Variablen existieren nur EINMAL im Speicher, egal wie viele Objekte wir erstellen.
        // Sie repräsentieren den Gesamtzustand des Konzerns.
        private static int _globalerWarenbestand = 0;
        private static decimal _globalerKassenbestand = 0m;
        private static int _anzahlWarenhaueser = 0;

        // ==========================================
        // PROPERTIES (Instanz-Daten)
        // ==========================================
        // Diese Werte hat JEDES Objekt separat (Name, eigener Bestand, eigene Kasse).
        // 'private set' sorgt für Kapselung: Werte können von außen nur gelesen werden.
        public string Name { get; }
        public int Warenbestand { get; private set; }
        public decimal Kassenbestand { get; private set; }

        // ==========================================
        // KONSTRUKTOR
        // ==========================================
        public Warenhaus(string name, int startWaren, decimal startKasse)
        {
            // 1. Instanz-Daten setzen (für DIESES neue Warenhaus)
            Name = name;
            Warenbestand = startWaren;
            Kassenbestand = startKasse;

            // 2. Statische Daten aktualisieren (Globalen Konzern-Zähler anpassen)
            // Da dies im Konstruktor passiert, zählen wir automatisch jedes neu erstellte Haus mit.
            _anzahlWarenhaueser++;
            _globalerWarenbestand += startWaren;
            _globalerKassenbestand += startKasse;
        }

        // ==========================================
        // INSTANZ-METHODEN (Logik pro Filiale)
        // ==========================================

        /// <summary>
        /// Führt einen Einkauf für diese spezifische Filiale durch.
        /// Aktualisiert sowohl die lokale Filiale als auch die globale Statistik.
        /// </summary>
        /// <param name="menge">Anzahl der zu kaufenden Waren (Standard: 1)</param>
        public void Einkauf(int menge = 1)
        {
            if (menge <= 0) return; // Guard Clause: Negative Mengen ignorieren

            decimal kosten = menge * EINKAUFSPREIS;

            // Prüfen, ob DIESE Filiale genug Geld hat
            if (Kassenbestand >= kosten)
            {
                // A) Lokalen Zustand ändern (Instanz)
                Kassenbestand -= kosten;
                Warenbestand += menge;

                // B) Globalen Zustand ändern (Static)
                // Wichtig: Wir greifen hier auf die geteilten Klassenvariablen zu.
                _globalerKassenbestand -= kosten;
                _globalerWarenbestand += menge;
            }
            // Optional: Else-Block für Fehlerbehandlung/Logging
        }

        /// <summary>
        /// Führt einen Verkauf für diese spezifische Filiale durch.
        /// </summary>
        /// <param name="menge">Anzahl der zu verkaufenden Waren (Standard: 1)</param>
        public void Verkauf(int menge = 1)
        {
            if (menge <= 0) return;

            // Prüfen, ob DIESE Filiale genug Ware hat
            if (Warenbestand >= menge)
            {
                decimal gewinn = menge * VERKAUFSPREIS;

                // A) Lokalen Zustand ändern
                Kassenbestand += gewinn;
                Warenbestand -= menge;

                // B) Globalen Zustand ändern
                _globalerKassenbestand += gewinn;
                _globalerWarenbestand -= menge;
            }
        }

        /// <summary>
        /// Gibt die Informationen dieser spezifischen Filiale auf der Konsole aus.
        /// </summary>
        public void InfoAusgeben()
        {
            Console.WriteLine($"[Filiale: {Name}] Kasse: {Kassenbestand:C} | Bestand: {Warenbestand} Stk.");
        }

        // ==========================================
        // STATISCHE METHODEN
        // ==========================================

        /// <summary>
        /// Gibt die aggregierten Daten aller Warenhäuser aus.
        /// Diese Methode kann aufgerufen werden, ohne eine konkrete Instanz zu haben.
        /// Aufruf: Warenhaus.GlobaleStatistikAusgeben();
        /// </summary>
        public static void GlobaleStatistikAusgeben()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("KONZERN STATISTIK (Aggregiert)");
            Console.WriteLine($"Anzahl Filialen: {_anzahlWarenhaueser}");
            Console.WriteLine($"Gesamtkasse:     {_globalerKassenbestand:C}");
            Console.WriteLine($"Gesamtwaren:     {_globalerWarenbestand} Stk.");
            Console.WriteLine(new string('-', 50));
        }
    }

    /// <summary>
    /// Steuerungsklasse für Aufgabe 04 (Static Member).
    /// </summary>
    public class App
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Aufgabe 04: Static Member (Warenhaus) ===");
            Random rnd = new Random();

            // Erstellen der Objekte (Instanzen).
            // Der Konstruktor kümmert sich im Hintergrund um das Hochzählen der globalen Statistik.
            Warenhaus[] filialen = new Warenhaus[]
            {
                new Warenhaus("Zentrum", 50, 1000m),
                new Warenhaus("Nord",    20, 500m),
                new Warenhaus("Süd",    100, 2000m),
                new Warenhaus("West",    10, 200m),
                new Warenhaus("Ost",      5, 100m)
            };

            Console.WriteLine("Startzustand:");
            // Aufruf der statischen Methode über den KLASSENNAMEN, nicht über eine Variable.
            Warenhaus.GlobaleStatistikAusgeben();

            Console.WriteLine("\nStarte Simulation (100 zufällige Transaktionen)...\n");

            // Simulations-Schleife
            for (int i = 0; i < 100; i++)
            {
                // 1. Zufälliges Objekt aus dem Array wählen
                Warenhaus aktuellesHaus = filialen[rnd.Next(filialen.Length)];

                // 2. Zufällige Parameter bestimmen
                int aktion = rnd.Next(0, 2); // 0 oder 1
                int menge = rnd.Next(1, 6);  // 1 bis 5

                // 3. Methode auf der gewählten Instanz ausführen
                if (aktion == 0)
                    aktuellesHaus.Einkauf(menge);
                else
                    aktuellesHaus.Verkauf(menge);
            }

            Console.WriteLine("Endzustand der einzelnen Filialen:");
            foreach (var filiale in filialen)
            {
                filiale.InfoAusgeben();
            }

            // Abschließende globale Auswertung
            Warenhaus.GlobaleStatistikAusgeben();

            Console.WriteLine("\nDrücke eine Taste...");
            Console.ReadKey();
        }
    }
}
