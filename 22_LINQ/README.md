# 22_LINQ - Grundlagen der Datenabfrage

Dieses Projekt behandelt die Grundlagen von LINQ (Language Integrated Query) in C#. Es vereint Logik für **Filterung**, **Sortierung**, **Partitionierung** und **Aggregation** von Datenkollektionen. Dabei wird der direkte Vergleich zwischen **Extension Method Syntax** und **Query Expression Syntax** demonstriert.

## Projektstruktur

Das Projekt ist modular aufgebaut und trennt die Logik in spezifische Services:

* **LinqConsoleApp**: Die Hauptanwendung.
    * `Services/FilteringService.cs`: Logik zur Filterung komplexer Objekte (z. B. Fahrzeuge).
    * `Services/IntSortingService.cs`: Sortieralgorithmen für Integer-Arrays.
    * `Services/StringSortingService.cs`: Komplexe Sortierungen für String-Arrays.
    * `Services/PartitioningService.cs`: Aufteilung und Segmentierung von Datenströmen.
    * `Services/AggregationService.cs`: Berechnung statistischer Kennzahlen (Summe, Min, Max etc.).
* **LinqConsoleApp.Tests**: xUnit-Tests zur Validierung aller Service-Methoden (TDD-Ansatz).

## Behandelte Konzepte

### 1. Syntax-Varianten

| Variante | Beschreibung | Beispiel |
| :--- | :--- | :--- |
| **Extension Method Syntax** | Methodenketten (Fluent API) mit Lambda-Ausdrücken. | `data.Where(x => x > 5).Sum()` |
| **Query Expression Syntax** | Deklarative, SQL-ähnliche Syntax. | `from x in data where x > 5 select x` |

### 2. Genutzte LINQ-Operatoren

* **Filterung (`Where`)**: Selektion von Elementen basierend auf Bedingungen.
* **Sortierung (`OrderBy`, `ThenBy`, `Reverse`)**: Primäre und sekundäre Ordnung sowie Invertierung.
* **Partitionierung (`Take`, `Skip`, `Chunk`)**: Auswahl von Elementen anhand ihrer Position oder Paging.
* **Aggregation (`Sum`, `Min`, `Max`, `Average`, `Count`)**: Berechnung einzelner Werte aus einer Sequenz.

## Aufgabenübersicht

### Teil 1: Filterung (Fahrzeuge)
*Quelle: Aufgabe LINQ Filterung*

* Filterung von Listen komplexer Objekte (Fahrzeuge) anhand von Eigenschaften wie Hersteller, Baujahr oder Farbe.

### Teil 2: Sortierung (Numbers & Strings)
*Quelle: Aufgabe LINQ Sortierung*

* **Integer-Operationen**:
    * Aufsteigende und absteigende Sortierung.
    * Kombination aus Filterung (gerade Zahlen) und Sortierung.
    * Wertebereich-Filterung (5-11) mit absteigender Sortierung.
* **String-Operationen**:
    * Sortierung nach Wortlänge.
    * Mehrstufige Sortierung (Länge aufsteigend, Alphabet absteigend).
    * Invertierung der Reihenfolge.
    * Custom-Sortierung nach erstem (asc) und letztem (desc) Buchstaben.

### Teil 3: Partitionierung (Numbers)
*Quelle: Aufgabe LINQ Partitionierung*

* **Positionsspezifische Abfragen**:
    * Die ersten fünf Elemente (`Take`).
    * Die letzten fünf Elemente (`TakeLast`).
    * Mittelteil ohne Ränder (Erste und letzte drei ignorieren).
* **Werteabhängige Partitionierung**:
    * Alle Elemente, die *vor* der 22 stehen (`TakeWhile`).
    * Alle Elemente, die *nach* der 12 stehen (`SkipWhile`).
* **Paging**:
    * Seitenweise Ausgabe des Arrays (5 Elemente pro Seite) (`Chunk`).

### Teil 4: Aggregation (Numbers)
*Quelle: Aufgabe LINQ Aggregation*

* **Statistische Kennzahlen**:
    * Summe aller Werte (`Sum`).
    * Kleinste (`Min`) und größte (`Max`) Zahl.
    * Durchschnittswert (`Average`).
* **Bedingte Aggregation**:
    * Kleinste gerade Zahl.
    * Größte ungerade Zahl.
    * Summe und Durchschnitt spezifischer Teilmengen (z. B. nur gerade Zahlen).
    * Zählen von Elementen mit Bedingung (`Count` mit Prädikat).

## Ausführung

Starten der Konsolenanwendung zur Demonstration aller Features:

```bash
dotnet run --project LinqConsoleApp
```

```Bash
dotnet test
```
