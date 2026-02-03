namespace SerializationConsoleApp.Models
{
    /// <summary>
    /// Repräsentiert eine Person für die Serialisierung.
    /// </summary>
    public class Person
    {
        public string Vorname { get; set; } = string.Empty;
        public string Nachname { get; set; } = string.Empty;
        public int Alter { get; set; }
    }
}
