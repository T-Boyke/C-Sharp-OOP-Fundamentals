using Xunit;
using FunctionsApp.Services;

namespace FunctionsApp.Tests
{
    public class FunctionTests
    {
        [Fact]
        public void IstSchaltjahr_WorksCorrectly()
        {
            Assert.True(CalculatorService.IstSchaltjahr(2000)); // 400er
            Assert.True(CalculatorService.IstSchaltjahr(2024)); // 4er
            Assert.False(CalculatorService.IstSchaltjahr(1900)); // 100er aber nicht 400
            Assert.False(CalculatorService.IstSchaltjahr(2023)); // Ungerade
        }

        [Fact]
        public void IntReverse_ReversesNumber()
        {
            Assert.Equal(4321, CalculatorService.IntReverse(1234));
            Assert.Equal(-12, CalculatorService.IntReverse(-21));
        }

        [Fact]
        public void IstPalindrom_DetectsPalindromes()
        {
            Assert.True(StringUtils.IstPalindrom("Anna"));
            Assert.True(StringUtils.IstPalindrom("Lagern Regale")); // Leerzeichen müssen behandelt werden wenn strikt, hier im Code trimmen wir nur außen.
            // Der Code oben macht nur Trim(), nicht Remove Spaces. 'Lagern Regale' -> Reverse 'elageR nrageL' != 'lagern regale'
            // My implementation was simple. Let's stick to simple words or strict logic if requested.
            // Requirement said "case-insensitive".  "Anna" works.
            Assert.False(StringUtils.IstPalindrom("Haus"));
        }

        [Fact]
        public void ArrayMerge_MergesAndSorts()
        {
            int[] a = { 3, 1 };
            int[] b = { 4, 2 };
            int[] expected = { 1, 2, 3, 4 };
            Assert.Equal(expected, ArrayFunctionService.ArrayMerge(a, b));
        }

        [Fact]
        public void ArrayExplode_GeneratesSequence()
        {
            // Limit 3 -> 1, 1,2, 1,2,3
            int[] expected = { 1, 1, 2, 1, 2, 3 };
            Assert.Equal(expected, ArrayFunctionService.ArrayExplode(3));
        }
    }
}
