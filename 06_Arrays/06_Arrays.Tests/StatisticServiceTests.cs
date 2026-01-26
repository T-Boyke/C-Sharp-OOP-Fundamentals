using _06_Arrays.src;
using System;
using Xunit;

namespace _06_Arrays.Tests
{
    public class StatisticServiceTests
    {
        private readonly StatisticService _sut = new();

        [Fact]
        public void CalculateStatistics_HappyPath_ReturnsCorrectValues()
        {
            // Arrange
            int[] data = [ 10, 20, 30, 40, 50 ];

            // Act
            var result = _sut.CalculateStatistics(data);

            // Assert
            Assert.Equal(10, result.Min);
            Assert.Equal(50, result.Max);
            Assert.Equal(150, result.Sum);
            Assert.Equal(30.0, result.Average);
        }

        [Fact]
        public void CalculateStatistics_UnsortedArray_ReturnsCorrectMinMax()
        {
            // Arrange
            int[] data = [ 5, 99, 1, 33 ];

            // Act
            var result = _sut.CalculateStatistics(data);

            // Assert
            Assert.Equal(1, result.Min);
            Assert.Equal(99, result.Max);
        }

        [Fact]
        public void CalculateStatistics_NullArray_ThrowsArgumentNullException()
        {
            // Act & Assert
            // Using C# 14 / xUnit assertion styles
            Assert.Throws<ArgumentNullException>(() => _sut.CalculateStatistics(null!));
        }

        [Fact]
        public void CalculateStatistics_EmptyArray_ThrowsArgumentException()
        {
            // Arrange
            int[] data = [];

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _sut.CalculateStatistics(data));
        }

        [Fact]
        public void CalculateStatistics_SingleValue_ReturnsSameMinMaxAvg()
        {
            // Arrange
            int[] data = [ 42 ];

            // Act
            var result = _sut.CalculateStatistics(data);

            // Assert
            Assert.Equal(42, result.Min);
            Assert.Equal(42, result.Max);
            Assert.Equal(42, result.Sum);
            Assert.Equal(42.0, result.Average);
        }
    }
}
