# Modul 22: LINQ Filtering

Dieses Modul behandelt die Grundlagen von LINQ (Language Integrated Query) zur effizienten Filterung von Datenstrukturen.

## Lernziele
* Beherrschung der **Extension-Method-Syntax** (Lambda-Ausdrücke).
* Beherrschung der **Query-Expression-Syntax** (SQL-ähnlich).
* Anwendung von Filtern auf numerische Arrays und Strings.

## Enthaltene Aufgaben (Stand 28.01.2026)
Die Implementierungen basieren auf dem Aufgabenblatt `Aufgabe LINQ Filterung.pdf`:

### 1. Numerische Filterung (int[])
* Zahlen kleiner als 7.
* Gerade und ungerade einstellige Zahlen.
* Filterung ab einem bestimmten Index (Kombination mit `Skip`).
* Teilbarkeit durch 2 oder 3.

### 2. Text-Filterung (string[])
* Filterung nach String-Länge.
* Prüfung auf enthaltene Teilstrings (z. B. "o" oder "four").
* Suchen nach spezifischen Endungen (z. B. "teen") inklusive Transformation in Großbuchstaben.

## Projektstruktur
* `LinqFilteringApp/`: Konsolenanwendung mit den LINQ-Lösungen in beiden Syntax-Varianten.
* `LinqFiltering.Tests/`: Unit-Tests zur Validierung der Abfrageergebnisse.

## Referenzmaterial
* `Aufgabe LINQ Filterung.pdf`: Detaillierte Liste der Abfrage-Anforderungen.

---
*Stand: 28. Januar 2026*
