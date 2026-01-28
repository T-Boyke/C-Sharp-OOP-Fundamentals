# 22_LINQ - Grundlagen der Datenabfrage

Dieses Projekt behandelt die Grundlagen von LINQ (Language Integrated Query) in C#. Es vereint Logik für **Filterung** und **Sortierung** von Datenkollektionen und demonstriert den direkten Vergleich zwischen **Extension Method Syntax** und **Query Expression Syntax**.

## Projektstruktur

Das Projekt ist modular aufgebaut und trennt die Logik in spezifische Services:

* **LinqConsoleApp**: Die Hauptanwendung.
    * `Services/FilteringService.cs`: Beinhaltet Logik zur Filterung von Objekten (z. B. Fahrzeuge).
    * `Services/IntSortingService.cs`: Implementiert Sortieralgorithmen für Integer-Arrays.
    * `Services/StringSortingService.cs`: Implementiert komplexe Sortierungen für String-Arrays.
* **LinqConsoleApp.Tests**: Enthält xUnit-Tests zur Validierung aller Service-Methoden (TDD-Ansatz).

## Behandelte Konzepte

### 1. Syntax-Varianten

Der Code zeigt für fast jede Aufgabe beide Implementierungswege:

| Variante | Beschreibung | Beispiel |
| :--- | :--- | :--- |
| **Extension Method Syntax** | Methodenketten (Fluent API) mit Lambda-Ausdrücken. | `data.Where(n => n > 5).OrderBy(n => n)` |
| **Query Expression Syntax** | Deklarative, SQL-ähnliche Syntax. | `from n in data where n > 5 orderby n select n` |

### 2. Genutzte LINQ-Operatoren

* **Filterung (`Where`)**: Extraktion von Elementen, die eine bestimmte Bedingung erfüllen.
* **Sortierung (`OrderBy`, `OrderByDescending`)**: Primäre Sortierung einer Sequenz.
* **Folgesortierung (`ThenBy`, `ThenByDescending`)**: Sekundäre Sortierkriterien bei gleichen Werten.
* **Invertierung (`Reverse`)**: Umkehrung der aktuellen Reihenfolge (Index-basiert).

## Aufgabenübersicht

### Teil 1: Sortierung (Numbers & Strings)
*Quelle: Aufgabe LINQ Sortierung.pdf*

* **Integer-Operationen**:
    * Einfache Sortierung (aufsteigend/absteigend).
    * Kombination aus Filterung (nur gerade Zahlen / Wertebereich 5-11) und Sortierung.
* **String-Operationen**:
    * Sortierung nach Wortlänge.
    * Mehrstufige Sortierung: Primär nach Länge (asc), Sekundär alphabetisch (desc).
    * Spezialsortierung nach erstem und letztem Buchstaben.

### Teil 2: Filterung (Fahrzeuge)
*Quelle: Aufgabe LINQ Filterung.pdf*

* Filterung von Listen komplexer Objekte anhand von Eigenschaften (z. B. "Alle VWs ab Baujahr 2020").

## Ausführung

Starten der Konsolenanwendung zur Demonstration der Ergebnisse:

```bash
dotnet run --project LinqConsoleApp

```

Ausführen der Unit-Tests:

```bash
dotnet test

```


### Nächste Schritte
* Ersetze den Inhalt der `README.md` im Ordner `22_LINQ` mit dem obigen Text.
* Stelle sicher, dass die Projektdatei (`.csproj`) und die Ordnerstruktur (Services-Ordner) dem neuen Stand entsprechen.

```
