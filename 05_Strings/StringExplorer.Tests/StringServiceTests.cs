using Xunit;
using StringExplorer;

namespace StringExplorer.Tests
{
    public class StringServiceTests
    {
        [Fact]
        public void Reverse_ReversesStringCorrectly()
        {
            Assert.Equal("olleh", StringService.Reverse("hello"));
            Assert.Equal("", StringService.Reverse(""));
        }

        [Fact]
        public void GeneratePattern_BuildsCorrectString()
        {
            Assert.Equal("1", StringService.GeneratePattern(1));
            Assert.Equal("1-2-3", StringService.GeneratePattern(3));
        }

        [Fact]
        public void GeneratePattern_ThrowsOnInvalidInput()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringService.GeneratePattern(0));
        }

        [Fact]
        public void ParseEmail_ReturnsUserAndDomain()
        {
            var (user, domain) = StringService.ParseEmail("max.mustermann@example.com");
            Assert.Equal("max.mustermann", user);
            Assert.Equal("example.com", domain);
        }

        [Theory]
        [InlineData("invalid")]
        [InlineData("no@domain@here")]
        [InlineData("@onlydomain")]
        public void ParseEmail_ThrowsOnInvalidFormat(string email)
        {
            Assert.Throws<ArgumentException>(() => StringService.ParseEmail(email));
        }
    }
}
