using System;
using System.Collections.Generic;
using System.Linq;
using AufgabeWarenkorb; // Namespace der bereitgestellten Klassen

namespace LinqConsoleApp.Services
{
    /// <summary>
    /// Service zur Lösung der LINQ-Aufgaben "Warenkorb" vom 30. Januar 2026.
    /// Deckt Filterung, Projektion, Joins und Aggregationen ab.
    /// </summary>
    public class ShoppingCartService
    {
        private readonly Kunde[] _kunden;
        private readonly Produkt[] _produkte;

        /// <summary>
        /// Initialisiert den Service mit den Standard-Datenlisten für Kunden und Produkte.
        /// </summary>
        public ShoppingCartService()
        {
            _kunden = Kunde.GetKundenListe(); //
            _produkte = Produkt.GetProduktListe(); //
        }

        /// <summary>
        /// Führt alle Teilaufgaben (a-k) aus und gibt die Ergebnisse aus.
        /// </summary>
        public void RunAllTasks()
        {
            // a) Namen der Produkte & Name/Wohnort der Kunden
            var prodNamen = _produkte.Select(p => p.Name); //
            var kundenInfo = _kunden.Select(k => new { k.Name, k.Ort }); //

            // b) Bestellungen von Kunden aus Deutschland
            var bestellungenDE = _kunden
                .Where(k => k.Land == Länder.Germany) //
                .SelectMany(k => k.Bestellungen); //

            // c) Name für jeden zweiten Kunden
            var jederZweiteKunde = _kunden
                .Where((k, index) => index % 2 == 0) //
                .Select(k => k.Name);

            // d) Name und Preis (<= 20€), absteigend sortiert
            var billigProds = _produkte
                .Where(p => p.Preis <= 20) //
                .OrderByDescending(p => p.Preis) //
                .Select(p => new { p.Name, p.Preis });

            // e) Name und Land, sortiert nach Land (asc) und Name (asc)
            var kundenSort = _kunden
                .OrderBy(k => k.Land) //
                .ThenBy(k => k.Name) //
                .Select(k => new { k.Name, k.Land });

            // f) Gruppierung der Kunden nach Land
            var kundenNachLand = from k in _kunden
                                 group k by k.Land; //

            // g) Produkte nach erstem Buchstaben gruppieren (nur Namen)
            var prodsNachBuchstabe = _produkte
                .GroupBy(p => p.Name[0], p => p.Name); //

            // h) Join Bestellungen und Produkte (sortiert nach Preis)
            var bestellDetails = from k in _kunden
                                 from b in k.Bestellungen //
                                 join p in _produkte on b.ProduktNr equals p.ProduktNr //
                                 orderby p.Preis //
                                 select new { b.Monat, b.ProduktNr, p.Name, p.Preis, b.Versendet };

            // i) Kunden mit Name, Wohnort und Anzahl Bestellungen
            var kundenBestellAnzahl = _kunden.Select(k => new { 
                k.Name, 
                k.Ort, 
                Anzahl = k.Bestellungen.Length //
            });

            // j) Summe aller Produktpreise
            decimal gesamtSumme = _produkte.Sum(p => p.Preis); //

            // k) Kunden mit Gesamtbetrag ihrer Bestellungen
            var kundenUmsatz = _kunden.Select(k => new {
                k.Name,
                Umsatz = k.Bestellungen.Sum(b => 
                    _produkte.First(p => p.ProduktNr == b.ProduktNr).Preis * b.Anzahl) //
            });
        }
    }
}
