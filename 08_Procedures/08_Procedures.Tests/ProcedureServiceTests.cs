using _08_Procedures.src.Services;
using Xunit;

namespace _08_Procedures.Tests
{
    public class ProcedureServiceTests
    {
        private readonly MockConsole _console = new();
        private readonly ProcedureService _sut;

        public ProcedureServiceTests()
        {
            _sut = new ProcedureService(_console);
        }

        [Fact]
        public void AusgabeGutenMorgen_WritesCurrentMessage()
        {
            _sut.AusgabeGutenMorgen();
            Assert.Contains("Guten Morgen!\n", _console.Outputs);
        }

        [Fact]
        public void InputOutput_ReadsAndWritesCorrectly()
        {
            _console.Inputs.Enqueue("TestUser");
            _sut.InputOutput();
            
            Assert.Contains("Sie haben 'TestUser' eingegeben.\n", _console.Outputs);
        }

        [Theory]
        [InlineData(5, 7, 12)]
        [InlineData(-1, 1, 0)]
        public void Addition_WritesCorrectSum(int n1, int n2, int expected)
        {
            _sut.Addition(n1, n2);
            Assert.Contains($"Das Ergebnis der Addition ist {expected}.\n", _console.Outputs);
        }

        [Fact]
        public void PrintDivisors_WritesCorrectDivisors()
        {
            _sut.PrintDivisors(12);
            Assert.Contains("Teiler von 12 sind: 1, 2, 3, 4, 6, 12\n", _console.Outputs);
        }
    }
}
