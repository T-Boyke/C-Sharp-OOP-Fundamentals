# 22_LINQ - Grundlagen der Datenabfrage

Dieses Projekt behandelt die Grundlagen von LINQ (Language Integrated Query) in C#. Es vereint Logik für **Filterung**, **Sortierung** und **Partitionierung** von Datenkollektionen und demonstriert den Vergleich zwischen **Extension Method Syntax** und **Query Expression Syntax**.

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
| **Extension Method Syntax** | [cite_start]Methodenketten (Fluent API) mit Lambda-Ausdrücken[cite: 22]. | `data.Where(x => x > 5).Take(3)` |
| **Query Expression Syntax** | [cite_start]Deklarative, SQL-ähnliche Syntax[cite: 22]. | `from x in data where x > 5 select x` |

### 2. Genutzte LINQ-Operatoren

* **Filterung (`Where`)**: Selektion von Elementen basierend auf Bedingungen.
* [cite_start]**Sortierung (`OrderBy`, `ThenBy`, `Reverse`)**: Primäre und sekundäre Ordnung sowie Invertierung[cite: 23, 33].
* [cite_start]**Partitionierung (`Take`, `Skip`)**: Auswahl von Elementen anhand ihrer Position (Anfang/Ende)[cite: 8, 10].
* [cite_start]**Bedingte Partitionierung (`TakeWhile`, `SkipWhile`)**: Auswahl, solange eine Bedingung wahr ist[cite: 11, 12].
* [cite_start]**Chunking (`Chunk`)**: Aufteilen einer Liste in gleich große Blöcke (z. B. für Paging)[cite: 13].

## Aufgabenübersicht

### Teil 1: Filterung (Fahrzeuge)
*Quelle: Aufgabe LINQ Filterung*

* Filterung von Listen komplexer Objekte (Fahrzeuge) anhand von Eigenschaften wie Hersteller, Baujahr oder Farbe.

### Teil 2: Sortierung (Numbers & Strings)
*Quelle: Aufgabe LINQ Sortierung*

* [cite_start]**Integer-Operationen** (Datenbasis: `[5, 4, 1, ...]` [cite: 21]):
    * [cite_start]Aufsteigende [cite: 23] [cite_start]und absteigende Sortierung[cite: 24].
    * [cite_start]Kombination aus Filterung (gerade Zahlen) und Sortierung[cite: 25].
    * [cite_start]Wertebereich-Filterung (5-11) mit absteigender Sortierung[cite: 26].
* [cite_start]**String-Operationen** (Datenbasis: `["zero", "one", ...]` [cite: 28]):
    * [cite_start]Sortierung nach Wortlänge[cite: 31].
    * [cite_start]Mehrstufige Sortierung (Länge aufsteigend, Alphabet absteigend)[cite: 32].
    * [cite_start]Invertierung der Reihenfolge[cite: 33].
    * [cite_start]Custom-Sortierung nach erstem (asc) und letztem (desc) Buchstaben[cite: 34].

### Teil 3: Partitionierung (Numbers)
*Quelle: Aufgabe LINQ Partitionierung*

* [cite_start]**Positionsspezifische Abfragen** (Datenbasis: `[5, 4, 1, ...]` [cite: 6]):
    * [cite_start]Die ersten fünf Elemente (`Take`)[cite: 8].
    * [cite_start]Die letzten fünf Elemente (`TakeLast`)[cite: 9].
    * [cite_start]Mittelteil ohne Ränder (Erste und letzte drei ignorieren)[cite: 10].
* **Werteabhängige Partitionierung**:
    * [cite_start]Alle Elemente, die *vor* der 22 stehen (`TakeWhile`)[cite: 11].
    * [cite_start]Alle Elemente, die *nach* der 12 stehen (`SkipWhile`)[cite: 12].
* **Paging**:
    * [cite_start]Seitenweise Ausgabe des Arrays (5 Elemente pro Seite) (`Chunk`)[cite: 13].

## Ausführung

Starten der Konsolenanwendung:

```bash
dotnet run --project LinqConsoleApp

## Ausführung

Starten der Konsolenanwendung:

```bash
dotnet run --project LinqConsoleApp
```

```Bash
dotnet test
```
