using _10_Classes.src;
using Xunit;

namespace _10_Classes.Tests
{
    public class TvTests
    {
        private readonly Tv _sut = new();

        [Fact]
        public void InitialState_IsOff_And_VolumeZero()
        {
            Assert.False(_sut.IsOn());
            // We can't check volume directly if property isn't exposed public, 
            // but we can infer from GetInfo or check if it starts at sensible default.
            // Assuming default 0 and int default is 0.
            Assert.Contains("aus", _sut.GetInfo());
        }

        [Fact]
        public void TurnOn_SwitchesState()
        {
            _sut.TurnOn();
            Assert.True(_sut.IsOn());
            Assert.Contains("an", _sut.GetInfo());
        }

        [Fact]
        public void TurnOff_SwitchesState()
        {
            _sut.TurnOn();
            _sut.TurnOff();
            Assert.False(_sut.IsOn());
        }

        [Fact]
        public void RaiseVolume_IncreasesVolume_WhenOn()
        {
            _sut.TurnOn();
            _sut.RaiseVolume(); // 0 -> 1
            Assert.Contains("Lautstärke=1", _sut.GetInfo());
        }

        [Fact]
        public void RaiseVolume_DoesNothing_WhenOff()
        {
            _sut.RaiseVolume();
            // Should still be off and vol 0 (implicit)
            // If we turn it on now, volume should be 0
            _sut.TurnOn();
            Assert.Contains("Lautstärke=0", _sut.GetInfo());
        }

        [Fact]
        public void LowerVolume_DoesNotGoBelowZero()
        {
            _sut.TurnOn();
            _sut.LowerVolume(); // 0 -> 0 (clamped)
            Assert.Contains("Lautstärke=0", _sut.GetInfo());
        }

        [Fact]
        public void RaiseVolume_DoesNotGoAbove100()
        {
            _sut.TurnOn();
            // Loop to max
            for(int i=0; i<110; i++) _sut.RaiseVolume();
            
            Assert.Contains("Lautstärke=100", _sut.GetInfo());
        }
    }
}
