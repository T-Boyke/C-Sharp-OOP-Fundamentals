using Xunit;
using ConverterApp;

namespace ConverterApp.Tests
{
    /// <summary>
    /// Testklasse für den <see cref="ConverterService"/>.
    /// </summary>
    public class ConverterServiceTests
    {
        [Fact]
        public void CelsiusToFahrenheit_CalculatesCorrectly()
        {
            // Arrange
            double celsius = 0;
            double expected = 32;

            // Act
            double result = ConverterService.CelsiusToFahrenheit(celsius);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CelsiusToFahrenheit_HandlesDecimals()
        {
            // 25 * 1.8 + 32 = 45 + 32 = 77
            Assert.Equal(77, ConverterService.CelsiusToFahrenheit(25));
        }

        [Fact]
        public void EuroToDollar_UsesCorrectExchangeRate()
        {
            // Arrange
            decimal euro = 100m;
            decimal expected = 110.00m;

            // Act
            decimal result = ConverterService.EuroToDollar(euro);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EuroToDollar_ThrowsOnNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => ConverterService.EuroToDollar(-1));
        }

        [Fact]
        public void MinutesToHoursAndMinutes_CalculatesCorrectly()
        {
            // Arrange
            int total = 150;
            int expectedHours = 2;
            int expectedMinutes = 30;

            // Act
            var (h, m) = ConverterService.MinutesToHoursAndMinutes(total);

            // Assert
            Assert.Equal(expectedHours, h);
            Assert.Equal(expectedMinutes, m);
        }
    }
}
