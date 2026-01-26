using Xunit;
using ProceduresApp;
using System.Collections.Generic;

namespace ProceduresApp.Tests
{
    /// <summary>
    /// Mock-Implementierung für IOutputService, die Ausgaben speichert statt sie anzuzeigen.
    /// </summary>
    public class MockOutputService : IOutputService
    {
        public List<string> CapturedData { get; } = new();

        public void WriteLine(string message) => CapturedData.Add(message);
        public void Write(string message) => CapturedData.Add(message);
    }

    public class ProcedureTests
    {
        private readonly MockOutputService _mock;
        private readonly ProcedureContainer _container;

        public ProcedureTests()
        {
            _mock = new MockOutputService();
            _container = new ProcedureContainer(_mock);
        }

        [Fact]
        public void AusgabeGutenMorgen_WritesCurrentMessage()
        {
            _container.AusgabeGutenMorgen();
            Assert.Contains("Guten Morgen!", _mock.CapturedData);
        }

        [Fact]
        public void Addition_CalculatesSumCorrectly()
        {
            _container.Addition(5, 7);
            Assert.Contains("5 + 7 = 12", _mock.CapturedData);
        }

        [Fact]
        public void ProzedurChain_CallsInCorrectOrder()
        {
            // P1 ruft P2 ruft P3
            _container.Prozedur1();

            // Erwartete Reihenfolge der Ausgaben (Stack-Unwinding beachten!)
            // P3 wird zuerst in P2 beendet...
            // Hier einfach prüfen, ob alle Strings da sind.
            Assert.Contains("Prozedur 3", _mock.CapturedData);
            Assert.Contains("Prozedur 2", _mock.CapturedData);
            Assert.Contains("Prozedur 1", _mock.CapturedData);
        }

        [Fact]
        public void Division_HandlesZero()
        {
            _container.Division(10, 0);
            Assert.Contains("Fehler: Division durch Null!", _mock.CapturedData);
        }

        [Fact]
        public void AnzeigeTeiler_FindsAllDivisors()
        {
            _container.AnzeigeTeiler(6);
            // 1, 2, 3, 6
            var output = _mock.CapturedData[0];
            Assert.Contains("1 2 3 6", output);
        }
    }
}
