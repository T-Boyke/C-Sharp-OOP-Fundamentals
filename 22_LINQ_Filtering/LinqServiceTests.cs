using LinqFilteringApp.Services;
using Xunit;
using System.Linq;

namespace LinqFiltering.Tests
{
    /// <summary>
    /// Testet die LINQ-Filterlogik auf Korrektheit.
    /// </summary>
    public class LinqServiceTests
    {
        private readonly LinqService _service = new LinqService();

        [Fact]
        public void GetNumbersSmallerThanSeven_ShouldReturnCorrectCount()
        {
            // Arrange & Act
            var (ext, query) = _service.GetNumbersSmallerThanSeven();

            // Assert
            Assert.Equal(ext.Count(), query.Count());
            Assert.All(ext, n => Assert.True(n < 7));
        }

        [Fact]
        public void GetTeensUpper_ShouldBeInUpperCase()
        {
            // Act
            var (ext, _) = _service.GetTeensUpper();

            // Assert
            Assert.Contains("THIRTEEN", ext);
            Assert.All(ext, s => Assert.Equal(s, s.ToUpper()));
        }
    }
}
