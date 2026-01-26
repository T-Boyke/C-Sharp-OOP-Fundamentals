using Xunit;
using MethodPlayground;

namespace MethodPlayground.Tests
{
    public class MathHelperTests
    {
        [Fact]
        public void CalculatePower_WorksCorrectly()
        {
            Assert.Equal(8, MathHelper.CalculatePower(2, 3));
            Assert.Equal(1, MathHelper.CalculatePower(5, 0));
        }

        [Fact]
        public void GetStatistics_ReturnsMinAndMax()
        {
            int[] data = { 5, 2, 9, 1, 6 };
            MathHelper.GetStatistics(data, out int min, out int max);

            Assert.Equal(1, min);
            Assert.Equal(9, max);
        }

        [Fact]
        public void Swap_ExchangesValues()
        {
            int x = 10;
            int y = 20;

            MathHelper.Swap(ref x, ref y);

            Assert.Equal(20, x);
            Assert.Equal(10, y);
        }
    }
}
