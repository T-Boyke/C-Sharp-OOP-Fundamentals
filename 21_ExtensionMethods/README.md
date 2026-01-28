# Modul 21: Extension Methods

Dieses Modul behandelt die Erweiterung bestehender Datentypen in C# ohne Vererbung oder Neukompilierung des Originaltyps.

## Lernziele
* Verständnis der Funktionsweise und Syntax von Erweiterungsmethoden
* Anwendung des `this`-Keywords in statischen Klassen
* Erweiterung von Interfaces und Berücksichtigung der Methoden-Priorität

## Enthaltene Aufgaben (Stand 27.01.2026)
Die Implementierungen basieren auf dem Aufgabenblatt `Aufgabe ExtensionMethods.pdf`:

* **String-Erweiterungen**:
    * `Left(int n)`: Liefert die linken n Zeichen.
    * `Right(int n)`: Liefert die rechten n Zeichen.
    * `IsPalindrome()`: Prüft auf Palindrome (Groß-/Kleinschreibung ignoriert).
* **Integer-Erweiterungen**:
    * `IsEven()` / `IsOdd()`: Prüfung auf gerade oder ungerade Zahlen.
* **String-Vertiefung**:
    * `ContainsDuplicateChars()`: Prüft auf doppelte Zeichen.
    * `RemoveDuplicateChars()`: Entfernt Duplikate aus einem String.
    * `Capitalize(char[] chars)`: Schreibt spezifische Zeichen groß.

## Projektstruktur
* `ExtensionMethodsApp/`: Konsolenanwendung zur Demonstration der Methoden.
* `ExtensionMethods.Tests/`: Unit-Tests (xUnit/MSTest) zur Sicherstellung der Funktionalität.

## Referenzmaterial
* `05 C# - Extension Methods.pdf`: Vorlesungsfolien zu Grundlagen, statischen Klassen und Interface-Erweiterungen.
* `Aufgabe ExtensionMethods.pdf`: Detaillierte Anforderungen und Beispiele (z. B. "Hello World!".Left(5)).

---
*Stand: 27. Januar 2026*
