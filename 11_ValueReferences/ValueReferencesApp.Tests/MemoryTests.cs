using Xunit;
using ValueReferencesApp;

namespace ValueReferencesApp.Tests
{
    public class MemoryTests
    {
        [Fact]
        public void Int_PassedByValue_DoesNotChange()
        {
            int original = 10;
            MemoryExperiment.ModifyValue(original);
            Assert.Equal(10, original);
        }

        [Fact]
        public void Int_PassedByRef_DoesChange()
        {
            int original = 10;
            MemoryExperiment.ModifyValueRef(ref original);
            Assert.Equal(999, original);
        }

        [Fact]
        public void Array_ContentChanges_BecauseItIsReferenceType()
        {
            int[] arr = { 1, 2, 3 };
            MemoryExperiment.ModifyReferenceContent(arr);
            Assert.Equal(999, arr[0]);
        }

        [Fact]
        public void Class_ReassignWithoutRef_DoesNotAffectOriginal()
        {
            var p = new Person { Name = "Original" };
            MemoryExperiment.ReassignReference(p);
            Assert.Equal("Original", p.Name);
        }

        [Fact]
        public void Class_ReassignWithRef_DoesAffectOriginal()
        {
            var p = new Person { Name = "Original" };
            MemoryExperiment.ReassignReferenceRef(ref p);
            Assert.Equal("New Person", p.Name);
        }
    }
}
