using Xunit;
using AlgorithmApp;

namespace AlgorithmApp.Tests
{
    public class AlgorithmTests
    {
        [Fact]
        public void Isbn_Validate_DetectsValidIsbn()
        {
            // Beispiel: 3-86680-192-0
            // Rechnung: 3*1 + 8*2 + 6*3 + 6*4 + 8*5 + 0*6 + 1*7 + 9*8 + 2*9
            // = 3 + 16 + 18 + 24 + 40 + 0 + 7 + 72 + 18 = 198
            // 198 % 11 = 0. Matches last digit 0.
            Assert.True(IsbnService.ValidateIsbn10("3-86680-192-0"));
        }

        [Fact]
        public void Isbn_Validate_DetectsInvalidIsbn()
        {
            Assert.False(IsbnService.ValidateIsbn10("3-86680-192-1")); // Falsche Checksum
        }

        [Fact]
        public void Text_CountWords_IgnoresMultiSpace()
        {
            Assert.Equal(3, TextAnalysisService.CountWords("Eins  Zwei   Drei"));
        }

        [Fact]
        public void Text_LongestWord_FindsMax()
        {
            Assert.Equal("Trapattoni", TextAnalysisService.FindLongestWord("Giovanni Trapattoni ist da"));
        }
    }
}
