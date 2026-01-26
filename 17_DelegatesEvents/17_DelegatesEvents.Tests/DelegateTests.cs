using _17_DelegatesEvents.src;
using System;
using Xunit;

namespace _17_DelegatesEvents.Tests
{
    public class DelegateTests
    {
        [Fact]
        public void Clock_Tick_TriggersEvent()
        {
            var clock = new Clock();
            bool eventTriggered = false;

            clock.OnTick += (time) => { eventTriggered = true; };

            clock.Tick();

            Assert.True(eventTriggered, "Event should be triggered on Tick()");
        }

        [Fact]
        public void Display_Subscribe_UpdatesLastMessage()
        {
            var clock = new Clock();
            var display = new Display();

            display.Subscribe(clock);
            
            // Before tick
            Assert.Equal("", display.LastMessage);

            // Act
            clock.Tick();

            // Assert
            Assert.Contains("Time is:", display.LastMessage); // Checks format "Time is: HH:mm:ss" approximately
        }
    }
}
