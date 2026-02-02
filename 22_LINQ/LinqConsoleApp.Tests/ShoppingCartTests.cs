using Xunit;
using AufgabeWarenkorb;
using System.Linq;

namespace LinqConsoleApp.Tests
{
    /// <summary>
    /// Validiert die LINQ-Logik für die Warenkorb-Aufgabe (20260130).
    /// Fokus auf Korrektheit der Joins und Aggregationen.
    /// </summary>
    public class ShoppingCartTests
    {
        /// <summary>
        /// Überprüft, ob die Umsatzberechnung pro Kunde (Aufgabe k) korrekt durchgeführt wird.
        /// </summary>
        [Fact]
        public void CalculateCustomerTurnover_ShouldReturnCorrectValues()
        {
            // Arrange
            var kunden = Kunde.GetKundenListe();
            var produkte = Produkt.GetProduktListe();

            // Act
            var walterUmsatz = kunden
                .Where(k => k.Name == "Walter")
                .Select(k => k.Bestellungen.Sum(b => 
                    produkte.First(p => p.ProduktNr == b.ProduktNr).Preis * b.Anzahl))
                .FirstOrDefault();

            // Assert
            // Walter: ProdNr 2 (Quark, 10€) * 4 Stück = 40€
            Assert.Equal(40m, walterUmsatz);
        }

        /// <summary>
        /// Überprüft die Filterung von Bestellungen nach Herkunftsland (Aufgabe b).
        /// </summary>
        [Fact]
        public void FilterGermanOrders_ShouldReturnCorrectCount()
        {
            // Arrange
            var kunden = Kunde.GetKundenListe();

            // Act
            var germanOrdersCount = kunden
                .Where(k => k.Land == Länder.Germany)
                .SelectMany(k => k.Bestellungen)
                .Count();

            // Assert
            // Walter (1) + Thomas (2) = 3 Bestellungen
            Assert.Equal(3, germanOrdersCount);
        }
    }
}
