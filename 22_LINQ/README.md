# 22_LINQ - Grundlagen der Datenabfrage

Dieses Projekt behandelt die Grundlagen von LINQ (Language Integrated Query) in C#. Es vereint Logik für **Filterung**, **Sortierung** und **Partitionierung** von Datenkollektionen und demonstriert den direkten Vergleich zwischen **Extension Method Syntax** und **Query Expression Syntax**.

## Projektstruktur

Das Projekt ist modular aufgebaut und trennt die Logik in spezifische Services:

* **LinqConsoleApp**: Die Hauptanwendung.
    * `Services/FilteringService.cs`: Logik zur Filterung komplexer Objekte (z. B. Fahrzeuge).
    * `Services/IntSortingService.cs`: Implementiert Sortieralgorithmen für Integer-Arrays.
    * `Services/StringSortingService.cs`: Implementiert komplexe Sortierungen für String-Arrays.
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
*Quelle: Aufgabe LINQ Filterung*

* Filterung von Listen komplexer Objekte (Fahrzeuge) anhand von Eigenschaften wie Hersteller, Baujahr oder Farbe.

### Teil 2: Sortierung (Numbers & Strings)
*Quelle: Aufgabe LINQ Sortierung*

* **Integer-Operationen** (Datenbasis: `[5, 4, 1, ...]`):
    * Aufsteigende und absteigende Sortierung.
    * Kombination aus Filterung (gerade Zahlen) und Sortierung.
    * Wertebereich-Filterung (5-11) mit absteigender Sortierung.
* **String-Operationen** (Datenbasis: `["zero", "one", ...]`):
    * Sortierung nach Wortlänge.
    * Mehrstufige Sortierung (Länge aufsteigend, Alphabet absteigend).
    * Invertierung der Reihenfolge.
    * Custom-Sortierung nach erstem (asc) und letztem (desc) Buchstaben.

### Teil 3: Partitionierung (Numbers)
*Quelle: Aufgabe LINQ Partitionierung*

* **Positionsspezifische Abfragen** (Datenbasis: `[5, 4, 1, ...]`):
    * Die ersten fünf Elemente (`Take`).
    * Die letzten fünf Elemente (`TakeLast`).
    * Mittelteil ohne Ränder (Erste und letzte drei ignorieren).
* **Werteabhängige Partitionierung**:
    * Alle Elemente, die *vor* der 22 stehen (`TakeWhile`).
    * Alle Elemente, die *nach* der 12 stehen (`SkipWhile`).
* **Paging**:
    * Seitenweise Ausgabe des Arrays (5 Elemente pro Seite) (`Chunk`).

## Ausführung

Starten der Konsolenanwendung:

```bash
dotnet run --project LinqConsoleApp
```

```Bash
dotnet test
```
