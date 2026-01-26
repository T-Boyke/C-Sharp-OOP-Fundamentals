using _16_StaticMembers.src;
using Xunit;

namespace _16_StaticMembers.Tests
{
    public class StaticTests
    {
        [Fact]
        public void Calculator_Methods_WorkStateless()
        {
            // Static call without instance
            Assert.Equal(5, Calculator.Add(2, 3));
            Assert.Equal(6, Calculator.Multiply(2, 3));
        }

        [Fact]
        public void Entity_InstanceCount_IsShared()
        {
            // Reset state
            Entity.ResetCount();

            var e1 = new Entity();
            var e2 = new Entity();
            var e3 = new Entity();

            // Count should be shared across instances
            Assert.Equal(3, Entity.GetCount());
            
            // IDs should be unique
            Assert.Equal(1, e1.Id);
            Assert.Equal(2, e2.Id);
            Assert.Equal(3, e3.Id);
        }
    }
}
