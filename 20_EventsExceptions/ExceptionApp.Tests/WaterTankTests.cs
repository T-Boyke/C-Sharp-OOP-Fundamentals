using Xunit;
using ExceptionApp;
using System;

namespace ExceptionApp.Tests
{
    public class WaterTankTests
    {
        [Fact]
        public void AddWater_IncreasesLevel_IfWithinCapacity()
        {
            var tank = new WaterTank(100);
            tank.AddWater(50);
            Assert.Equal(50, tank.CurrentLevel);
        }

        [Fact]
        public void AddWater_ThrowsOverflowException_IfTooMuch()
        {
            var tank = new WaterTank(100);
            tank.AddWater(90);
            
            Assert.Throws<OverflowException>(() => tank.AddWater(20));
        }

        [Fact]
        public void AddWater_FiresLevelChangedEvent()
        {
            var tank = new WaterTank(100);
            bool eventFired = false;
            int recordedOldLevel = -1;

            tank.LevelChanged += (s, e) => 
            {
                eventFired = true;
                recordedOldLevel = e.OldLevel;
            };

            tank.AddWater(10);

            Assert.True(eventFired);
            Assert.Equal(0, recordedOldLevel);
        }
    }
}
