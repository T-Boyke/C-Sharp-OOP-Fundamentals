using Xunit;
using GreetingApp;

namespace GreetingApp.Tests
{
    /// <summary>
    /// Testklasse für den <see cref="GreetingService"/>.
    /// </summary>
    public class GreetingServiceTests
    {
        /// <summary>
        /// Testet, ob <see cref="GreetingService.CalculateDays"/> korrekte Werte liefert.
        /// </summary>
        [Fact]
        public void CalculateDays_ReturnsCorrectResult()
        {
            // Arrange
            int age = 10;
            int expected = 3650;

            // Act
            int result = GreetingService.CalculateDays(age);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Testet, ob bei negativen Eingaben eine Exception geworfen wird.
        /// </summary>
        [Fact]
        public void CalculateDays_ThrowsException_OnNegativeAge()
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => GreetingService.CalculateDays(-5));
        }

        /// <summary>
        /// Testet die Zusammenstellung des Grußtextes.
        /// </summary>
        [Theory]
        [InlineData("Max", 20, "Hallo Max! Du bist ca. 7300 Tage alt.")]
        [InlineData("Lisa", 1, "Hallo Lisa! Du bist ca. 365 Tage alt.")]
        public void GetGreeting_ReturnsFormattedString(string name, int age, string expected)
        {
            // Act
            string result = GreetingService.GetGreeting(name, age);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
