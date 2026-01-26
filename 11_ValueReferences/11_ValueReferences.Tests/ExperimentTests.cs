using _11_ValueReferences.src;
using Xunit;

namespace _11_ValueReferences.Tests
{
    public class ExperimentTests
    {
        private readonly ExperimentService _sut = new();

        [Fact]
        public void ModifyValue_DoesNotChangeOriginal()
        {
            int original = 5;
            _sut.ModifyValue(original);
            
            // Wertetyp -> Kopie übergeben -> Original unverändert
            Assert.Equal(5, original);
        }

        [Fact]
        public void ModifyReference_ChangesOriginalContent()
        {
            int[] original = { 5 };
            _sut.ModifyReference(original);
            
            // Referenztyp -> Adresse kopiert -> Zeigt auf selbes Objekt -> Inhalt geändert
            Assert.Equal(999, original[0]);
        }

        [Fact]
        public void ModifyValueRef_ChangesOriginal()
        {
            int original = 5;
            _sut.ModifyValueRef(ref original);
            
            // ref -> Referenz auf Stack-Adresse übergeben -> Original geändert
            Assert.Equal(999, original);
        }

        [Fact]
        public void Swap_ExchangesValues()
        {
            int a = 1;
            int b = 2;
            _sut.Swap(ref a, ref b);

            Assert.Equal(2, a);
            Assert.Equal(1, b);
        }
    }
}
