using LinqConsoleApp.Services;
using Xunit;

namespace LinqConsoleApp.Tests
{
    /// <summary>
    /// Testklasse für die Aggregations-Methoden (Sum, Min, Max, Average, Count).
    /// </summary>
    public class AggregationTests
    {
        private readonly AggregationService _service;
        private readonly int[] _data;

        public AggregationTests()
        {
            _service = new AggregationService();
            _data = _service.GetNumbers();
            // Daten: { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 22, 12, 16, 18, 11, 19, 13 }
        }

        [Fact]
        public void GetSum_ShouldCalculateTotalSum()
        {
            // Manuelle Rechnung: 156
            var result = _service.GetSum(_data);
            Assert.Equal(156, result);
        }

        [Fact]
        public void GetMin_ShouldReturnSmallestNumber()
        {
            var result = _service.GetMin(_data);
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetMax_ShouldReturnLargestNumber()
        {
            var result = _service.GetMax(_data);
            Assert.Equal(22, result);
        }

        [Fact]
        public void GetMinEven_ShouldReturnSmallestEvenNumber()
        {
            // Gerade Zahlen inkludieren 0, 2, 4...
            var result = _service.GetMinEven(_data);
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetMaxOdd_ShouldReturnLargestOddNumber()
        {
            // Ungerade: ..., 11, 13, 19
            var result = _service.GetMaxOdd(_data);
            Assert.Equal(19, result);
        }

        [Fact]
        public void GetCountEven_ShouldReturnCorrectAmount()
        {
            // Gerade: 4, 8, 6, 2, 0, 22, 12, 16, 18 (9 Stück)
            var result = _service.GetCountEven(_data);
            Assert.Equal(9, result);
        }
    }
}
