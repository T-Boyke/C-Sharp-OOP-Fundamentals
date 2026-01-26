using _07_ArraysMulti.src;
using System.Collections.Generic;
using Xunit;

namespace _07_ArraysMulti.Tests
{
    public class MatrixServiceTests
    {
        private readonly MatrixService _sut = new();

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 100)]
        public void CreateMultiplicationTable_ReturnsCorrectDimensions(int size, int expectedLastElement)
        {
            var result = _sut.CreateMultiplicationTable(size);

            Assert.Equal(size, result.GetLength(0));
            Assert.Equal(size, result.GetLength(1));
            Assert.Equal(expectedLastElement, result[size - 1, size - 1]);
        }

        [Fact]
        public void CreateRandomMatrix_ReturnsCorrectSizeAndRange()
        {
            var result = _sut.CreateRandomMatrix(5, 5, 1, 10);

            Assert.Equal(5, result.GetLength(0));
            Assert.Equal(5, result.GetLength(1));
            
            // Check range
            foreach (int val in result)
            {
                Assert.InRange(val, 1, 10);
            }
        }

        [Fact]
        public void FindPositions_ReturnsCorrectIndices()
        {
            int[,] matrix = { { 1, 2 }, { 2, 1 } };
            
            var result = _sut.FindPositions(matrix, 2);

            Assert.Equal(2, result.Count);
            Assert.Contains("[0, 1]", result);
            Assert.Contains("[1, 0]", result);
        }

        [Fact]
        public void GetDivisibleBy_ReturnsCorrectNumbers()
        {
            int[,] matrix = { { 7, 14 }, { 3, 21 } };
            
            var result = _sut.GetDivisibleBy(matrix, 7);
            
            Assert.Equal(3, result.Count);
            Assert.All(result, num => Assert.True(num % 7 == 0));
        }
    }
}
