using System.IO;
using System.Text.Json;
using SerializationConsoleApp.Models;

namespace SerializationConsoleApp.Services
{
    public class SerializationService
    {
        /// <summary>
        /// Serialisiert ein Person-Objekt in eine JSON-Datei.
        /// </summary>
        public void SavePerson(Person person)
        {
            string fileName = $"{person.Nachname}.txt";
            string jsonString = JsonSerializer.Serialize(person, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonString);
        }

        /// <summary>
        /// Deserialisiert eine JSON-Datei zurück in ein Person-Objekt.
        /// </summary>
        public Person? LoadPerson(string nachname)
        {
            string fileName = $"{nachname}.txt";
            if (!File.Exists(fileName)) return null;

            string jsonString = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<Person>(jsonString);
        }
    }
}
