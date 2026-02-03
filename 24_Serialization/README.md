# 24_Serialization - Datenpersistenz mit JSON

Dieses Projekt behandelt die Serialisierung und Deserialisierung von Objekten in C#. Es demonstriert, wie Laufzeit-Objekte in ein speicherbares Format (JSON) umgewandelt und wiederhergestellt werden, basierend auf der Aufgabe vom 3. Februar 2026.

## Projektstruktur

* **SerializationConsoleApp**: Die Hauptanwendung.
    * `Models/Person.cs`: Datenklasse mit Eigenschaften für Vorname, Nachname und Alter.
    * `Services/SerializationService.cs`: Kapselt die Logik für `System.Text.Json`.
    * `Program.cs`: Konsolenbasiertes Menüsystem für Benutzerinteraktion.
* **SerializationConsoleApp.Tests**: xUnit-Tests zur Validierung der Persistenz.

## Behandelte Konzepte

### 1. JSON Serialisierung
Verwendung des modernen `System.Text.Json` Namespaces (seit .NET Core 3.0 Standard) anstelle von `Newtonsoft.Json`.
* **Serialize**: Umwandlung eines Objekts in einen JSON-String.
* **Deserialize**: Rekonstruktion eines Objekts aus einem JSON-String.
* **Optionen**: Verwendung von `WriteIndented = true` für gut lesbare Textdateien.

### 2. Datei-I/O
* Speicherung der Daten in Textdateien mit dem Namensschema `<Nachname>.txt`.
* Überprüfung auf Dateiexistenz vor dem Laden (`File.Exists`).

## Aufgabenübersicht

### Teil 1: Das Datenmodell
Erstellung einer Klasse `Person` mit den Eigenschaften:
* `Vorname` (string)
* `Nachname` (string)
* `Alter` (int)

### Teil 2: Das Menüsystem
Implementierung einer Konsolenanwendung mit folgenden Optionen:
1.  **Speichern**: Abfrage der Personendaten und Serialisierung in eine Datei.
2.  **Laden**: Abfrage des Nachnamens, Suche der Datei und Anzeige der Daten.

## Ausführung

Starten der Anwendung:
```bash
dotnet run --project SerializationConsoleApp
```

Ausführen der Tests:

```Bash
dotnet test
```

Beispiel-Output
```JSON
{
  "Vorname": "Max",
  "Nachname": "Mustermann",
  "Alter": 30
}
```
