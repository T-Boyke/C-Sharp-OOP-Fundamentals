using _06_Arrays.src;
using System.Linq;
using Xunit;

namespace _06_Arrays.Tests
{
    public class LottoServiceTests
    {
        private readonly LottoService _sut = new();

        [Fact]
        public void DrawLottoNumbers_ReturnsExactly6Numbers()
        {
            // Act
            bool[] result = _sut.DrawLottoNumbers();

            // Assert
            // Count how many 'true' values are in the bool array
            int count = result.Count(b => b); 
            Assert.Equal(6, count);
        }

        [Fact]
        public void DrawLottoNumbers_ReturnsNumbersInRange1To49()
        {
            // Act
            bool[] result = _sut.DrawLottoNumbers();

            // Assert
            // Index 0 must be false (numbers 1-49 are used)
            Assert.False(result[0], "Index 0 should not be set (only 1-49).");
            
            // Should be size 50
            Assert.Equal(50, result.Length);
        }

        [Fact]
        public void DrawLottoNumbers_AreUnique()
        {
            // With bool array logic, uniqueness is guaranteed by design,
            // but we can verify that we get exactly 6 flags.
            // If we drew the same number twice in logic without checking, we might end up with fewer than 6 flags.
            // But our Logic does: while(count < 6) ... if(!drawn[i]) ...
            // So we just re-verify count.
            
            var result = _sut.DrawLottoNumbers();
            Assert.Equal(6, result.Count(x => x));
        }
    }
}
