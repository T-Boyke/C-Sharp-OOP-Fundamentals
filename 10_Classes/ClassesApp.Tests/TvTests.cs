using Xunit;
using ClassesApp;

namespace ClassesApp.Tests
{
    public class TvTests
    {
        [Fact]
        public void TurnOn_SetsIsOnTrue()
        {
            var tv = new Tv();
            tv.TurnOn();
            Assert.True(tv.IsOn);
        }

        [Fact]
        public void Volume_CannotChange_WhenOff()
        {
            var tv = new Tv();
            // Default IsOn is false
            tv.RaiseVolume();
            Assert.Equal(0, tv.Volume);
        }

        [Fact]
        public void Volume_RespecstMaxLimit()
        {
            var tv = new Tv();
            tv.TurnOn();

            // Set internal volume to 100 manually not possible via public API efficiently here without loop
            // So we loop.
            for (int i = 0; i < 110; i++)
            {
                tv.RaiseVolume();
            }

            Assert.Equal(100, tv.Volume);
        }

        [Fact]
        public void Volume_RespectsMinLimit()
        {
            var tv = new Tv();
            tv.TurnOn();
            tv.RaiseVolume(); // 1
            tv.LowerVolume(); // 0
            tv.LowerVolume(); // Should stay 0

            Assert.Equal(0, tv.Volume);
        }
    }
}
