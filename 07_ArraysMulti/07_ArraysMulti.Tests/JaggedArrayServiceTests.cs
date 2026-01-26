using _07_ArraysMulti.src;
using Xunit;

namespace _07_ArraysMulti.Tests
{
    public class JaggedArrayServiceTests
    {
        private readonly JaggedArrayService _sut = new();

        [Fact]
        public void CreateTriangleRepetition_ReturnsCorrectPattern()
        {
            /* Expected for 3 rows:
             * 1
             * 2 2
             * 3 3 3
             */
            var result = _sut.CreateTriangleRepetition(3);

            Assert.Equal(3, result.Length);
            Assert.Single(result[0]); // Row 0 has 1 el
            Assert.Equal(1, result[0][0]); 
            
            Assert.Equal(3, result[2].Length);
            Assert.Equal(3, result[2][0]); 
            Assert.Equal(3, result[2][2]);
        }

        [Fact]
        public void CreateTriangleCounting_ReturnsCorrectPattern()
        {
             /* Expected for 3 rows:
             * 1
             * 1 2
             * 1 2 3
             */
            var result = _sut.CreateTriangleCounting(3);

            Assert.Equal(3, result.Length);
            Assert.Equal(3, result[2].Length);
            Assert.Equal(1, result[2][0]);
            Assert.Equal(2, result[2][1]);
            Assert.Equal(3, result[2][2]);
        }
    }
}
