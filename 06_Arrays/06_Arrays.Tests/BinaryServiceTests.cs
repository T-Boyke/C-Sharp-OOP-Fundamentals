using _06_Arrays.src;
using Xunit;

namespace _06_Arrays.Tests
{
    public class BinaryServiceTests
    {
        private readonly BinaryService _sut = new();

        [Theory]
        [InlineData(0,   new[] {0,0,0,0,0,0,0,0})]
        [InlineData(1,   new[] {0,0,0,0,0,0,0,1})]
        [InlineData(255, new[] {1,1,1,1,1,1,1,1})]
        [InlineData(170, new[] {1,0,1,0,1,0,1,0})] // 128+32+8+2 = 170
        public void DecimalToBinary_ValidInput_ReturnsCorrectBits(int input, int[] expected)
        {
            // Act
            var result = _sut.DecimalToBinary(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(256)]
        public void DecimalToBinary_InvalidInput_ThrowsException(int input)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.DecimalToBinary(input));
        }
    }
}
