using _18_Algorithms.src;
using Xunit;

namespace _18_Algorithms.Tests
{
    public class AlgorithmTests
    {
        private readonly IsbnService _isbnService = new();
        private readonly TextAnalysisService _textService = new();

        [Theory]
        [InlineData("3-16-148410-X", true)]
        [InlineData("316148410X", true)]
        [InlineData("0-306-40615-2", true)]
        [InlineData("0-306-40615-5", false)] // Wrong check digit
        public void ValidateIsbn10_WorksCorrectly(string isbn, bool expected)
        {
            Assert.Equal(expected, _isbnService.ValidateIsbn10(isbn));
        }

        [Fact]
        public void TextAnalysis_CountWords_Works()
        {
            string text = "Ich habe fertig!";
            Assert.Equal(3, _textService.CountWords(text));
        }

        [Fact]
        public void TextAnalysis_LongestWord_Works()
        {
            string text = "Strunz ist zwei Jahre hier";
            // "Jahre" 5, "Strunz" 6
            Assert.Equal("Strunz", _textService.FindLongestWord(text));
        }
    }
}
