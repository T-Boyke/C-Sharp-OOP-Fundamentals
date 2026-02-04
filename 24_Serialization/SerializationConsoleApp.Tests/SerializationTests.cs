using System.IO;
using System.Threading.Tasks;
using Xunit;
using SerializationConsoleApp.Models;
using SerializationConsoleApp.Services;

namespace SerializationConsoleApp.Tests
{
    /// <summary>
    /// Testklasse zur Validierung der asynchronen Serialisierungslogik.
    /// Prüft Persistenz, Datenintegrität und Fehlerbehandlung gemäß den Anforderungen.
    /// </summary>
    public class SerializationTests
    {
        private readonly SerializationService _service;
        
        /// <summary>
        /// Konstante für den Namen des Datenverzeichnisses zur Vermeidung von "Magic Strings".
        /// </summary>
        private const string DATA_DIR = "Data";

        /// <summary>
        /// Initialisiert die Testumgebung und den benötigten Service.
        /// </summary>
        public SerializationTests()
        {
            _service = new SerializationService();
        }

        /// <summary>
        /// Verifiziert, dass die Methode <see cref="SerializationService.SavePersonAsync"/> 
        /// eine JSON-Datei im korrekten Verzeichnis erstellt.
        /// </summary>
        /// <returns>Ein Task, der den asynchronen Testvorgang repräsentiert.</returns>
        [Fact]
        public async Task SavePersonAsync_ShouldCreateFile_In_DataDirectory()
        {
            // Arrange: Vorbereitung der Testdaten und Pfade
            var person = new Person { Vorname = "Max", Nachname = "TestMustermann", Alter = 30 };
            string expectedFileName = Path.Combine(DATA_DIR, "TestMustermann.json");

            try
            {
                // Act: Ausführen der zu testenden Methode
                await _service.SavePersonAsync(person);

                // Assert: Prüfung, ob die Datei physisch existiert
                Assert.True(File.Exists(expectedFileName), $"Die Datei wurde nicht im Pfad '{expectedFileName}' erstellt.");
            }
            finally
            {
                // Teardown: Bereinigung der Test-Artefakte
                if (File.Exists(expectedFileName))
                {
                    File.Delete(expectedFileName);
                }
            }
        }

        /// <summary>
        /// Verifiziert den Round-Trip (Speichern und Laden), um sicherzustellen, dass keine Datenverluste auftreten.
        /// </summary>
        /// <returns>Ein Task, der den asynchronen Testvorgang repräsentiert.</returns>
        [Fact]
        public async Task LoadPersonAsync_ShouldReturnCorrectData_AfterRoundTrip()
        {
            // Arrange: Erstellung eines Referenzobjekts
            var originalPerson = new Person { Vorname = "Erika", Nachname = "TestMusterfrau", Alter = 42 };
            string fileName = Path.Combine(DATA_DIR, "TestMusterfrau.json");
            
            // Vorbedingung schaffen: Datei muss existieren
            await _service.SavePersonAsync(originalPerson);

            try
            {
                // Act: Laden der Daten
                Person? loadedPerson = await _service.LoadPersonAsync("TestMusterfrau");

                // Assert: Prüfung auf Gleichheit der Eigenschaften
                Assert.NotNull(loadedPerson);
                Assert.Equal(originalPerson.Vorname, loadedPerson.Vorname);
                Assert.Equal(originalPerson.Nachname, loadedPerson.Nachname);
                Assert.Equal(originalPerson.Alter, loadedPerson.Alter);
            }
            finally
            {
                // Teardown: Bereinigung
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }

        /// <summary>
        /// Verifiziert, dass beim Laden einer nicht existierenden Person <c>null</c> zurückgegeben wird
        /// und keine Exception geworfen wird.
        /// </summary>
        /// <returns>Ein Task, der den asynchronen Testvorgang repräsentiert.</returns>
        [Fact]
        public async Task LoadPersonAsync_FileNotFound_ShouldReturnNull()
        {
            // Arrange: Definition eines Namens, der sicher nicht existiert
            string nonExistentName = "NiemandVorhanden";
            string filePath = Path.Combine(DATA_DIR, $"{nonExistentName}.json");

            // Sicherheitscheck: Falls Datei durch vorherige Runs existiert, löschen
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Act: Versuch, nicht existierende Daten zu laden
            Person? result = await _service.LoadPersonAsync(nonExistentName);

            // Assert: Erwartetes Ergebnis ist null
            Assert.Null(result);
        }
    }
}
