using _09_Functions.src;
using Xunit;

namespace _09_Functions.Tests
{
    public class FunctionServiceTests
    {
        private readonly FunctionService _sut = new();

        [Fact]
        public void GibMir5_Returns5()
        {
            Assert.Equal(5, _sut.GibMir5());
        }

        [Theory]
        [InlineData(5, 7, 12)]
        [InlineData(-2, 2, 0)]
        public void Addition_ReturnsSum(int a, int b, int expected)
        {
            Assert.Equal(expected, _sut.Addition(a, b));
        }

        [Theory]
        [InlineData(2000, true)]
        [InlineData(2024, true)]
        [InlineData(2023, false)]
        [InlineData(1900, false)] // Teilbar durch 100, aber nicht 400
        public void IstSchaltjahr_CalculatesCorrectly(int jahr, bool expected)
        {
            Assert.Equal(expected, _sut.IstSchaltjahr(jahr));
        }

        [Fact]
        public void IntReverse_ReversesNumber()
        {
            Assert.Equal(4321, _sut.IntReverse(1234));
            Assert.Equal(5, _sut.IntReverse(50)); // 50 -> 05 -> 5
        }

        [Theory]
        [InlineData("Lager", "regaL")]
        [InlineData("Otto", "ottO")]
        public void Reverse_ReversesString(string input, string expected)
        {
            Assert.Equal(expected, _sut.Reverse(input));
        }

        [Theory]
        [InlineData("Anna", true)]
        [InlineData("Lagerregal", true)]
        [InlineData("Nicht", false)]
        public void IstPalindrom_ChecksCorrectly(string input, bool expected)
        {
            Assert.Equal(expected, _sut.IstPalindrom(input));
        }

        [Fact]
        public void ArrayMerge_MergesAndSorts()
        {
            int[] a1 = { 5, 1 };
            int[] a2 = { 9, 2 };
            int[] expected = { 1, 2, 5, 9 };

            Assert.Equal(expected, _sut.ArrayMerge(a1, a2));
        }

        [Fact]
        public void ArrayExplode_GeneratesPattern()
        {
            // Grenze 3 -> 1, 1,2, 1,2,3
            int[] expected = { 1, 1, 2, 1, 2, 3 };
            Assert.Equal(expected, _sut.ArrayExplode(3));
        }
        
        [Fact]
        public void FnachC_CalculatesCorrectly()
        {
            // 32 F ~ 0 C
            Assert.Equal(0, _sut.FnachC(32));
        }
    }
}
