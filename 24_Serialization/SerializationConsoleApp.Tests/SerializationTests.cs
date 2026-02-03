using System.IO;
using Xunit;
using SerializationConsoleApp.Models;
using SerializationConsoleApp.Services;

namespace SerializationConsoleApp.Tests
{
    /// <summary>
    /// Testklasse zur Validierung der Serialisierungslogik gemäß Aufgabenstellung.
    /// Prüft das korrekte Speichern (Persistenz) und Laden (Deserialisierung) von Person-Objekten.
    /// </summary>
    public class SerializationTests
    {
        private readonly SerializationService _service;

        /// <summary>
        /// Initialisiert die Testumgebung.
        /// </summary>
        public SerializationTests()
        {
            _service = new SerializationService();
        }

        /// <summary>
        /// Testet, ob die Methode SavePerson eine Datei mit dem korrekten Namen erstellt.
        /// </summary>
        [Fact]
        public void SavePerson_ShouldCreateFile()
        {
            // Arrange
            var person = new Person { Vorname = "Max", Nachname = "Mustermann", Alter = 30 };
            string expectedFileName = "Mustermann.txt";

            try
            {
                // Act
                _service.SavePerson(person);

                // Assert
                Assert.True(File.Exists(expectedFileName), "Die Datei wurde nicht erstellt.");
            }
            finally
            {
                // Cleanup: Erstellte Datei nach dem Test löschen
                if (File.Exists(expectedFileName))
                {
                    File.Delete(expectedFileName);
                }
            }
        }

        /// <summary>
        /// Testet den Round-Trip (Speichern -> Laden), um sicherzustellen, dass die Daten unverändert bleiben.
        /// </summary>
        [Fact]
        public void LoadPerson_ShouldReturnCorrectData()
        {
            // Arrange
            var originalPerson = new Person { Vorname = "Erika", Nachname = "Musterfrau", Alter = 42 };
            string fileName = "Musterfrau.txt";
            _service.SavePerson(originalPerson);

            try
            {
                // Act
                Person? loadedPerson = _service.LoadPerson("Musterfrau");

                // Assert
                Assert.NotNull(loadedPerson);
                Assert.Equal(originalPerson.Vorname, loadedPerson.Vorname);
                Assert.Equal(originalPerson.Nachname, loadedPerson.Nachname);
                Assert.Equal(originalPerson.Alter, loadedPerson.Alter);
            }
            finally
            {
                // Cleanup
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }

        /// <summary>
        /// Testet das Verhalten beim Versuch, eine nicht existierende Person zu laden.
        /// </summary>
        [Fact]
        public void LoadPerson_FileNotFound_ShouldReturnNull()
        {
            // Arrange
            string nonExistentName = "Niemand";

            // Sicherstellen, dass die Datei wirklich nicht existiert
            if (File.Exists($"{nonExistentName}.txt"))
            {
                File.Delete($"{nonExistentName}.txt");
            }

            // Act
            Person? result = _service.LoadPerson(nonExistentName);

            // Assert
            Assert.Null(result);
        }
    }
}
