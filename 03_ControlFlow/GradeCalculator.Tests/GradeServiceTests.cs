using Xunit;
using GradeCalculator;

namespace GradeCalculator.Tests
{
    /// <summary>
    /// Tests für die IHK-Notenberechnung.
    /// </summary>
    public class GradeServiceTests
    {
        [Theory]
        [InlineData(100, "Sehr gut")]
        [InlineData(92, "Sehr gut")]
        [InlineData(91, "Gut")]
        [InlineData(81, "Gut")]
        [InlineData(80, "Befriedigend")]
        [InlineData(67, "Befriedigend")]
        [InlineData(66, "Ausreichend")]
        [InlineData(50, "Ausreichend")]
        [InlineData(49, "Mangelhaft")]
        [InlineData(30, "Mangelhaft")]
        [InlineData(29, "Ungenügend")]
        [InlineData(0, "Ungenügend")]
        public void GetGrade_ReturnsCorrectGrade(int points, string expected)
        {
            var result = GradeService.GetGrade(points);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void GetGrade_ThrowsOnInvalidPoints(int points)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => GradeService.GetGrade(points));
        }
    }
}
