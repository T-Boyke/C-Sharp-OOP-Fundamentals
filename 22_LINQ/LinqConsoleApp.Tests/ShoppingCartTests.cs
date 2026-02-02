using Xunit;
using AufgabeWarenkorb;
using System.Linq;

namespace LinqConsoleApp.Tests
{
    /// <summary>
    /// Testet die Geschäftslogik der Warenkorb-Abfragen.
    /// </summary>
    public class ShoppingCartTests
    {
        /// <summary>
        /// Validiert die korrekte Umsatzberechnung eines Kunden (Aufgabe k).
        /// </summary>
        [Fact]
        public void CalculateCustomerTurnover_Walter_ShouldBe40()
        {
            // Arrange
            var kunden = Kunde.GetKundenListe();
            var produkte = Produkt.GetProduktListe();

            // Act: Walter hat 4x Quark (ProdNr 2, Preis 10€)
            var walter = kunden.First(k => k.Name == "Walter");
            var umsatz = walter.Bestellungen.Sum(b => 
                produkte.First(p => p.ProduktNr == b.ProduktNr).Preis * b.Anzahl);

            // Assert
            Assert.Equal(40m, umsatz);
        }

        /// <summary>
        /// Prüft die korrekte Anzahl an Bestellungen aus Deutschland (Aufgabe b).
        /// </summary>
        [Fact]
        public void CountGermanOrders_ShouldBeCorrect()
        {
            // Arrange
            var kunden = Kunde.GetKundenListe();

            // Act
            var anzahl = kunden
                .Where(k => k.Land == Länder.Germany)
                .SelectMany(k => k.Bestellungen)
                .Count();

            // Assert: Walter (1) + Thomas (2) = 3
            Assert.Equal(3, anzahl);
        }
    }
}
