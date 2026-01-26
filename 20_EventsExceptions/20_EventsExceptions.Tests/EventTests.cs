using _20_EventsExceptions.src;
using System;
using Xunit;

namespace _20_EventsExceptions.Tests
{
    public class EventTests
    {
        [Fact]
        public void AddWater_IncreasesLevel()
        {
            var tank = new WaterTank(100);
            tank.AddWater(50);
            Assert.Equal(50, tank.CurrentLevel);
        }

        [Fact]
        public void AddWater_ThrowsOverflowException_WhenFull()
        {
            var tank = new WaterTank(100);
            
            // Should throw custom exception
            Assert.Throws<TankOverflowException>(() => tank.AddWater(101));
        }

        [Fact]
        public void AddWater_TriggersEvent()
        {
            var tank = new WaterTank(100);
            bool eventTriggered = false;
            int oldLvl = -1;
            int newLvl = -1;

            tank.LevelChanged += (sender, args) => 
            { 
                eventTriggered = true;
                oldLvl = args.OldLevel;
                newLvl = args.NewLevel;
            };

            tank.AddWater(10);

            Assert.True(eventTriggered);
            Assert.Equal(0, oldLvl);
            Assert.Equal(10, newLvl);
        }
    }
}
