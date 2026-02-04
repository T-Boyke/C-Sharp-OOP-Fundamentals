using System;

namespace SerializationConsoleApp.Models
{
    /// <summary>
    /// Repräsentiert eine natürliche Person als Datenmodell für Serialisierungsvorgänge.
    /// Diese Klasse dient als reiner Datencontainer, auch POCO genannt.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Ruft den Vornamen der Person ab oder legt diesen fest.
        /// </summary>
        /// <remarks>
        /// Die Initialisierung mit string.Empty verhindert mögliche NullReferenceExceptions bei der Verarbeitung.
        /// </remarks>
        /// <value>
        /// Der Vorname als Zeichenkette.
        /// </value>
        public string Vorname { get; set; } = string.Empty;

        /// <summary>
        /// Ruft den Nachnamen der Person ab oder legt diesen fest.
        /// </summary>
        /// <value>
        /// Der Nachname als Zeichenkette.
        /// </value>
        public string Nachname { get; set; } = string.Empty;

        /// <summary>
        /// Ruft das Lebensalter der Person in Jahren ab oder legt dieses fest.
        /// </summary>
        /// <value>
        /// Das Alter als 32-Bit Ganzzahl.
        /// </value>
        public int Alter { get; set; }
    }
}
