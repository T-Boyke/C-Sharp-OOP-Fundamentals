# 22_LINQ - Grundlagen der Datenabfrage

Dieses Projekt behandelt die Grundlagen von LINQ (Language Integrated Query) in C#. Es vereint Logik für **Filterung**, **Sortierung**, **Partitionierung**, **Aggregation** und **komplexe Datenbeziehungen**. Dabei wird der direkte Vergleich zwischen **Extension Method Syntax** und **Query Expression Syntax** demonstriert.

## Projektstruktur

Das Projekt ist modular aufgebaut und trennt die Logik in spezifische Services:

* **LinqConsoleApp**: Die Hauptanwendung.
    * `Services/FilteringService.cs`: Logik zur Filterung komplexer Objekte.
    * `Services/IntSortingService.cs`: Sortieralgorithmen für Integer-Arrays.
    * `Services/StringSortingService.cs`: Komplexe Sortierungen für String-Arrays.
    * `Services/PartitioningService.cs`: Aufteilung und Segmentierung von Datenströmen.
    * `Services/AggregationService.cs`: Berechnung statistischer Kennzahlen.
    * `Services/ShoppingCartService.cs`: **(Neu)** Joins, Gruppierungen und komplexe Aggregationen (Warenkorb).
* **LinqConsoleApp.Tests**: xUnit-Tests zur Validierung aller Service-Methoden (TDD-Ansatz).

## Behandelte Konzepte

### 1. Syntax-Varianten

| Variante | Beschreibung | Beispiel |
| :--- | :--- | :--- |
| **Extension Method Syntax** | Methodenketten (Fluent API) mit Lambda-Ausdrücken. | `data.Where(x => x > 5).Sum()` |
| **Query Expression Syntax** | Deklarative, SQL-ähnliche Syntax. | `from x in data where x > 5 select x` |

### 2. Genutzte LINQ-Operatoren

* **Filterung & Sortierung**: `Where`, `OrderBy`, `ThenBy`, `OrderByDescending`.
* **Partitionierung**: `Take`, `Skip`, `Chunk`.
* **Aggregation**: `Sum`, `Min`, `Max`, `Average`, `Count`.
* **Relationen (Neu)**: `Join`, `SelectMany`, `GroupBy`.

## Aufgabenübersicht

... (Teil 1-4 wie bisher) ...

### Teil 5: Komplexe Datenbeziehungen (Warenkorb)
*Quelle: Aufgabe LINQ Warenkorb (30. Januar 2026)*

* **Joins**: Verknüpfung von Bestellungen und Produkten via ProduktNr.
* **Gruppierung**: Kunden nach Land und Produkte nach Anfangsbuchstaben.
* **Verschachtelte Aggregation**: Berechnung des Gesamtumsatzes pro Kunde.

## Ausführung

```bash
dotnet run --project LinqConsoleApp
dotnet test
```
---
