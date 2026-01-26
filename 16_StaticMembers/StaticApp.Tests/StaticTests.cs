using Xunit;
using StaticApp;

namespace StaticApp.Tests
{
    public class StaticTests
    {
        // Reset state before each test if possible, or use one test for counting flow
        // XUnit runs tests in parallel by default, which is BAD for static state testing!
        // We will assume sequential execution or put counting in one method.
        
        [Fact]
        public void Calculator_Add_ReturnsSum()
        {
            Assert.Equal(15, Calculator.Add(10, 5));
        }

        [Fact]
        public void Entity_CountIncreasesWithNewInstances()
        {
            // Reset state (Not thread-safe but okay for this simple exercise scope)
            Entity.ResetCount();
            Assert.Equal(0, Entity.GetCount());

            new Entity();
            new Entity();

            Assert.Equal(2, Entity.GetCount());
        }
    }
}
