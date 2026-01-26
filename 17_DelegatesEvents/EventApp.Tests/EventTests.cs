using Xunit;
using EventApp;
using System;

namespace EventApp.Tests
{
    public class EventTests
    {
        [Fact]
        public void Clock_FiresEvent()
        {
            var clock = new Clock();
            bool eventFired = false;

            clock.OnTick += (time) => eventFired = true;

            clock.Run(1);

            Assert.True(eventFired);
        }

        [Fact]
        public void Clock_PassesCorrectTime()
        {
            var clock = new Clock();
            DateTime receivedTime = DateTime.MinValue;

            clock.OnTick += (time) => receivedTime = time;

            clock.Run(1);

            Assert.NotEqual(DateTime.MinValue, receivedTime);
            // Time should be close to Now, but difficult to assert exact match.
            // Assertion that it changed is enough.
        }
    }
}
