# 22_LINQ - Grundlagen der Datenabfrage

Dieses Projekt behandelt die Grundlagen von LINQ (Language Integrated Query) in C#. Es vereint Logik für **Filterung**, **Sortierung** und **Partitionierung** von Datenkollektionen und demonstriert den Vergleich zwischen **Extension Method Syntax** und **Query Expression Syntax**.

## Projektstruktur

Das Projekt ist modular aufgebaut und trennt die Logik in spezifische Services:

* **LinqConsoleApp**: Die Hauptanwendung.
    * `Services/FilteringService.cs`: Logik zur Filterung komplexer Objekte (z. B. Fahrzeuge).
    * `Services/IntSortingService.cs`: Sortieralgorithmen für Integer-Arrays.
    * `Services/StringSortingService.cs`: Komplexe Sortierungen für String-Arrays.
    * `Services/PartitioningService.cs`: Aufteilung und Segmentierung von Datenströmen.
* **LinqConsoleApp.Tests**: xUnit-Tests zur Validierung aller Service-Methoden (TDD-Ansatz).

## Behandelte Konzepte

### 1. Syntax-Varianten

| Variante | Beschreibung | Beispiel |
| :--- | :--- | :--- |
| **Extension Method Syntax** | Methodenketten (Fluent API) mit Lambda-Ausdrücken. | `data.Where(x => x > 5).Take(3)` |
| **Query Expression Syntax** | Deklarative, SQL-ähnliche Syntax. | `from x in data where x > 5 select x` |

### 2. Genutzte LINQ-Operatoren

* **Filterung (`Where`)**: Selektion von Elementen basierend auf Bedingungen.
* **Sortierung (`OrderBy`, `ThenBy`, `Reverse`)**: Primäre und sekundäre Ordnung sowie Invertierung.
* **Partitionierung (`Take`, `Skip`)**: Auswahl von Elementen anhand ihrer Position (Anfang/Ende).
* **Bedingte Partitionierung (`TakeWhile`, `SkipWhile`)**: Auswahl, solange eine Bedingung wahr ist.
* **Chunking (`Chunk`)**: Aufteilen einer Liste in gleich große Blöcke (z. B. für Paging).

## Aufgabenübersicht

### Teil 1: Filterung (Fahrzeuge)
*Quelle: Aufgabe LINQ Filterung.pdf*

* Filterung von Listen komplexer Objekte (Fahrzeuge) anhand von Eigenschaften wie Hersteller, Baujahr oder Farbe.

### Teil 2: Sortierung (Numbers & Strings)
*Quelle: Aufgabe LINQ Sortierung.pdf*

* [cite_start]**Integer-Operationen**: [cite: 23, 24, 25, 26]
    * Aufsteigende und absteigende Sortierung.
    * Kombination aus Filterung (gerade Zahlen) und Sortierung.
    * Wertebereich-Filterung (5-11) mit Sortierung.
* [cite_start]**String-Operationen**: [cite: 31, 32, 33, 34]
    * Sortierung nach Wortlänge.
    * Mehrstufige Sortierung (Länge aufsteigend, Alphabet absteigend).
    * Invertierung der Reihenfolge.
    * Custom-Sortierung nach erstem und letztem Buchstaben.

### Teil 3: Partitionierung (Numbers)
*Quelle: Aufgabe LINQ Partitionierung.pdf*

* **Positionsspezifische Abfragen**:
    * [cite_start]Die ersten 5 Elemente (`Take`). [cite: 8]
    * [cite_start]Die letzten 5 Elemente (`TakeLast`). [cite: 9]
    * [cite_start]Mittelteil ohne Ränder (Erste/Letzte 3 ignorieren). [cite: 10]
* **Werteabhängige Partitionierung**:
    * [cite_start]Alles vor einem bestimmten Wert (z. B. vor der 22). [cite: 11]
    * [cite_start]Alles nach einem bestimmten Wert (z. B. nach der 12). [cite: 12]
* **Paging**:
    * [cite_start]Seitenweise Ausgabe des Arrays (5 Elemente pro Seite). [cite: 13]

## Ausführung

Starten der Konsolenanwendung:

```bash
dotnet run --project LinqConsoleApp
```

```Bash
dotnet test
```
