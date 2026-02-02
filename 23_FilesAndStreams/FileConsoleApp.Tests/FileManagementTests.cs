using Xunit;
using System.IO;
using FileConsoleApp.Services;

namespace FileConsoleApp.Tests
{
    /// <summary>
    /// Testklasse zur Validierung der Datei-Management-Logik.
    /// </summary>
    public class FileManagementTests
    {
        private readonly FileManagementService _service;

        public FileManagementTests()
        {
            _service = new FileManagementService();
        }

        /// <summary>
        /// Validiert, dass zwei identisch erstellte Dateien als identisch erkannt werden.
        /// </summary>
        [Fact]
        public void AreFilesIdentical_SameContent_ReturnsTrue()
        {
            // Arrange
            string p1 = "t1.tmp";
            string p2 = "t2.tmp";
            File.WriteAllText(p1, "Test");
            File.WriteAllText(p2, "Test");

            try
            {
                // Act
                bool result = _service.AreFilesIdentical(p1, p2);

                // Assert
                Assert.True(result);
            }
            finally
            {
                // Cleanup
                if (File.Exists(p1)) File.Delete(p1);
                if (File.Exists(p2)) File.Delete(p2);
            }
        }

        /// <summary>
        /// Stellt sicher, dass unterschiedliche Dateigrößen sofort erkannt werden.
        /// </summary>
        [Fact]
        public void AreFilesIdentical_DifferentSize_ReturnsFalse()
        {
            // Arrange
            string p1 = "s1.tmp";
            string p2 = "s2.tmp";
            File.WriteAllText(p1, "Kurz");
            File.WriteAllText(p2, "Ein sehr langer Text");

            try
            {
                // Act
                bool result = _service.AreFilesIdentical(p1, p2);

                // Assert
                Assert.False(result);
            }
            finally
            {
                if (File.Exists(p1)) File.Delete(p1);
                if (File.Exists(p2)) File.Delete(p2);
            }
        }
    }
}
