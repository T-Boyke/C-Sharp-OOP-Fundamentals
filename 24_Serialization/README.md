# 24_Serialization - Datenpersistenz mit JSON

Dieses Projekt behandelt die asynchrone Serialisierung und Deserialisierung von Objekten in C#. [cite_start]Es setzt die Anforderungen der "Aufgabe Serialisierung" vom 3. Februar 2026 um und demonstriert moderne Best Practices für Datei-I/O[cite: 2, 7].

## Aufgabenstellung

Die Umsetzung basiert auf den spezifischen Anforderungen der "Aufgabe Serialisierung":

1.  [cite_start]**Menüsystem**: Implementierung eines Programms mit den Optionen "Laden" und "Speichern"[cite: 4, 5, 6].
2.  [cite_start]**Datenmodell**: Erstellung einer Klasse `Person` mit den Eigenschaften Vorname, Nachname und Alter[cite: 8].
3.  **Speichern (Input & Serialisierung)**:
    * [cite_start]Erfassung der Werte über die Konsoleneingabe[cite: 9].
    * [cite_start]Erzeugung eines Objekts aus den Eingaben[cite: 8].
    * [cite_start]Serialisierung des Objekts in eine Datei mit dem Namensschema `<Name>.txt`[cite: 10].
4.  **Laden (Deserialisierung & Output)**:
    * [cite_start]Abfrage des Namens der Person[cite: 11].
    * [cite_start]Deserialisierung der entsprechenden Datei in ein Objekt[cite: 11].
    * [cite_start]Ausgabe der Werte auf der Konsole[cite: 11].
5.  [cite_start]**Technologie**: Freie Wahl des Serialisierers[cite: 12].

> **Hinweis zur Umsetzung**: In diesem Projekt wurde abweichend von der Vorgabe (`.txt`) das Dateiformat `.json` gewählt, um die Syntax-Kompatibilität mit modernen Editoren zu gewährleisten. Als Serialisierer kommt `System.Text.Json` zum Einsatz.

## Projektstruktur

| Datei | Beschreibung |
| :--- | :--- |
| **SerializationConsoleApp** | Hauptanwendung |
| `Models/Person.cs` | POCO-Datenklasse mit Eigenschaften für Vorname, Nachname und Alter |
| `Services/SerializationService.cs` | Kapselt die Logik für `System.Text.Json` und Dateioperationen |
| `Program.cs` | Einstiegspunkt mit Menüsystem (Laden/Speichern) |
| **SerializationConsoleApp.Tests** | xUnit-Tests zur Validierung der Persistenz |

## Behandelte Konzepte

### 1. JSON Serialisierung
Verwendung des performanten `System.Text.Json` Namespace (Best Practice).

* **SerializeAsync**: Speichereffiziente Umwandlung eines Objekts direkt in einen Dateistream.
* **DeserializeAsync**: Asynchrone Rekonstruktion eines Objekts aus einem Dateistream.
* **JsonSerializerOptions**: Konfiguration `WriteIndented = true` für formatierten Output.

### 2. Asynchrone Datei-I/O
* Nutzung von `async` und `await` zur Vermeidung blockierender Threads.
* Verwendung von `FileStream` für performanten Datenzugriff.
* Sichere Pfadgenerierung zur Verhinderung von Path-Traversal-Angriffen.

## Ausführung

Starten der Anwendung über die CLI:
```bash
dotnet run --project SerializationConsoleApp
Ausführen der Unit-Tests:
```

```Bash
dotnet test
Beispielhafter Inhalt einer generierten Datei
Pfad: Data/Mustermann.json
```

```JSON
{
  "Vorname": "Max",
  "Nachname": "Mustermann",
  "Alter": 30
}
```
