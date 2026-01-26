using Xunit;
using ArraysApp;
using System.Linq;

namespace ArraysApp.Tests
{
    public class AllServicesTests
    {
        // --- ArrayService Tests ---

        [Fact]
        public void CreateRandomArray_HasCorrectLengthAndRange()
        {
            int length = 100;
            int min = 1;
            int max = 10; // 1-9
            
            int[] result = ArrayService.CreateRandomArray(length, min, max);

            Assert.Equal(length, result.Length);
            Assert.All(result, x => Assert.InRange(x, min, max - 1));
        }

        [Fact]
        public void GetSquares_CalculatesCorrectly()
        {
            int[] squares = ArrayService.GetSquares(5);
            Assert.Equal(new[] { 1, 4, 9, 16, 25 }, squares);
        }

        [Fact]
        public void ReverseCopy_ReversesArray()
        {
            int[] input = { 1, 2, 3 };
            int[] reversed = ArrayService.ReverseCopy(input);
            Assert.Equal(new[] { 3, 2, 1 }, reversed);
            Assert.NotSame(input, reversed); // Muss neue Kopie sein
        }

        // --- StatisticService Tests ---

        [Fact]
        public void CalculateStatistics_ReturnsCorrectValues()
        {
            int[] data = { 10, 20, 30 };
            var stats = StatisticService.Calculate(data);

            Assert.Equal(10, stats.Min);
            Assert.Equal(30, stats.Max);
            Assert.Equal(60, stats.Sum);
            Assert.Equal(20.0, stats.Average);
        }

        // --- BinaryService Tests ---

        [Theory]
        [InlineData(0, new[] { 0,0,0,0,0,0,0,0 })]
        [InlineData(1, new[] { 0,0,0,0,0,0,0,1 })]
        [InlineData(255, new[] { 1,1,1,1,1,1,1,1 })]
        [InlineData(42, new[] { 0,0,1,0,1,0,1,0 })] // 32 + 8 + 2
        public void ToBinary8Bit_ConvertsCorrectly(int input, int[] expected)
        {
            int[] result = BinaryService.ToBinary8Bit(input);
            Assert.Equal(expected, result);
        }

        // --- LottoService Tests ---
        
        [Fact]
        public void DrawLotto_DrawsSixUniqueNumbers()
        {
            bool[] drawn = LottoService.DrawSixOutOfFortyNine();

            // Check Size
            Assert.Equal(50, drawn.Length);

            // Check Count (must be 6 true values)
            int trueCount = drawn.Count(x => x);
            Assert.Equal(6, trueCount);

            // Check Range (Index 0 should generally be false as we use 1-49, logic check)
            // Implementation logic: valid indices 1-49. 0 kept empty.
            // But random is 1..50 (excl), so 1-49. 0 is never touched.
            Assert.False(drawn[0]); 
        }
    }
}
