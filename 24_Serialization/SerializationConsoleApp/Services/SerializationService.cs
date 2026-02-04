using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using SerializationConsoleApp.Models;

namespace SerializationConsoleApp.Services
{
    /// <summary>
    /// Stellt Dienste für die Persistierung von Personendaten im JSON-Format bereit.
    /// </summary>
    /// <remarks>
    /// Dieser Service implementiert asynchrone Datei-Operationen für bessere Skalierbarkeit.
    /// </remarks>
    public class SerializationService
    {
        /// <summary>
        /// Das Standard-Verzeichnis für die Datenspeicherung.
        /// </summary>
        private const string DATA_DIRECTORY = "Data";

        /// <summary>
        /// Initialisiert eine neue Instanz des SerializationService und stellt sicher, dass das Zielverzeichnis existiert.
        /// </summary>
        public SerializationService()
        {
            // Erstellt das Verzeichnis, falls es noch nicht existiert, um DirectoryNotFoundExceptions zu vermeiden.
            if (!Directory.Exists(DATA_DIRECTORY))
            {
                Directory.CreateDirectory(DATA_DIRECTORY);
            }
        }

        /// <summary>
        /// Serialisiert ein <see cref="Person"/>-Objekt asynchron in eine JSON-Datei.
        /// </summary>
        /// <remarks>
        /// Die Methode nutzt <see cref="FileStream"/> und <see cref="JsonSerializer.SerializeAsync"/>, 
        /// um speichereffizient zu arbeiten, anstatt den gesamten JSON-String im RAM zu halten.
        /// </remarks>
        /// <param name="person">Das zu speichernde Personen-Objekt. Darf nicht null sein.</param>
        /// <returns>Ein Task, der den asynchronen Speichervorgang repräsentiert.</returns>
        /// <exception cref="ArgumentNullException">Wird geworfen, wenn <paramref name="person"/> null ist.</exception>
        /// <exception cref="ArgumentException">Wird geworfen, wenn der Nachname der Person ungültig ist.</exception>
        /// <exception cref="IOException">Wird geworfen, wenn ein Fehler beim Dateizugriff auftritt.</exception>
        public async Task SavePersonAsync(Person person)
        {
            // Validierung der Eingabeparameter (Fail Fast Prinzip).
            if (person == null) 
                throw new ArgumentNullException(nameof(person), "Das Personen-Objekt darf nicht null sein.");

            if (string.IsNullOrWhiteSpace(person.Nachname))
                throw new ArgumentException("Der Nachname darf nicht leer sein, da er als Dateiname dient.", nameof(person));

            // Generierung eines sicheren Dateipfads, um Path Traversal Angriffe zu verhindern.
            string filePath = GetSafeFilePath(person.Nachname);

            // Konfiguration für lesbares JSON (Pretty Print).
            var options = new JsonSerializerOptions 
            { 
                WriteIndented = true 
            };

            // Nutzung von 'using', um den FileStream sicher zu schließen (Dispose Pattern).
            // File.Create überschreibt eine existierende Datei oder erstellt eine neue.
            using (FileStream createStream = File.Create(filePath))
            {
                // Asynchrone Serialisierung direkt in den Stream für bessere Performance bei großen Datenmengen.
                await JsonSerializer.SerializeAsync(createStream, person, options);
            }
        }

        /// <summary>
        /// Deserialisiert eine JSON-Datei asynchron zurück in ein <see cref="Person"/>-Objekt.
        /// </summary>
        /// <param name="nachname">Der Nachname der Person, der als Dateischlüssel dient.</param>
        /// <returns>
        /// Ein Task mit dem deserialisierten <see cref="Person"/>-Objekt oder <c>null</c>, falls die Datei nicht existiert.
        /// </returns>
        /// <exception cref="ArgumentException">Wird geworfen, wenn der Nachname leer oder ungültig ist.</exception>
        /// <exception cref="JsonException">Wird geworfen, wenn die JSON-Datei fehlerhaft ist.</exception>
        public async Task<Person?> LoadPersonAsync(string nachname)
        {
            if (string.IsNullOrWhiteSpace(nachname))
                throw new ArgumentException("Der Nachname darf nicht leer sein.", nameof(nachname));

            string filePath = GetSafeFilePath(nachname);

            // Prüfung auf Existenz der Datei, um Exceptions zu vermeiden.
            if (!File.Exists(filePath)) 
                return null;

            // Öffnen der Datei im Lesemodus.
            using (FileStream openStream = File.OpenRead(filePath))
            {
                // Asynchrone Deserialisierung aus dem Stream.
                return await JsonSerializer.DeserializeAsync<Person>(openStream);
            }
        }

        /// <summary>
        /// Erstellt einen sicheren Dateipfad und bereinigt den Dateinamen von ungültigen Zeichen.
        /// </summary>
        /// <remarks>
        /// Diese Hilfsmethode verhindert, dass ungültige Zeichen im Dateinamen zu Systemfehlern führen 
        /// und schützt vor einfachen Path-Traversal-Versuchen.
        /// </remarks>
        /// <param name="fileNameBase">Der Basis-Dateiname (hier: Nachname).</param>
        /// <returns>Der vollständige, valide Pfad zur Datei.</returns>
        private string GetSafeFilePath(string fileNameBase)
        {
            // Entfernen aller Zeichen, die vom Betriebssystem im Dateinamen nicht erlaubt sind.
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileNameBase = fileNameBase.Replace(c, '_');
            }

            // Zusammenbau des Pfads mit Path.Combine für Plattformunabhängigkeit (Windows/Linux).
            // Datei wird explizit als .json gekennzeichnet.
            return Path.Combine(DATA_DIRECTORY, $"{fileNameBase}.json");
        }
    }
}
