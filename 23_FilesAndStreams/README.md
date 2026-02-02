# 23_FilesAndStreams - Dateisystem und Datenströme

Dieses Projekt behandelt den professionellen Umgang mit Dateien, Verzeichnissen und Streams in C#. Es demonstriert effiziente I/O-Operationen und die Überwachung des Dateisystems unter Berücksichtigung der IHK-Vorgaben.

## Projektstruktur

Das Projekt ist modular aufgebaut und trennt die Logik in spezifische Services:

* **FileConsoleApp**: Die Hauptanwendung.
    * `Services/FileManagementService.cs`: Kernlogik für byte-weise Vergleiche und Verzeichnisverwaltung.
    * `Program.cs`: Einstiegspunkt zur Demonstration der Datei-Operationen.
* **FileConsoleApp.Tests**: xUnit-Tests zur Validierung der I/O-Logik (TDD-Ansatz).

## Behandelte Konzepte

### 1. Datei-Operationen
* **File & FileInfo**: Methoden zum Erstellen, Lesen, Schreiben und Abfragen von Metadaten.
* **Directory & DirectoryInfo**: Verwaltung und Durchsuchen von Verzeichnisstrukturen.

### 2. Streams
* **FileStream**: Byte-orientierter, performanter Zugriff auf Binärdaten und große Dateien.
* **StreamReader / StreamWriter**: Abstraktion für textbasierte Datenströme mit Encoding-Support.

### 3. Fortgeschrittene Themen
* **Byte-weiser Vergleich**: Algorithmus zur exakten Prüfung der Datei-Identität (Aufgabe 20260202).
* **FileSystemWatcher**: Ereignisgesteuerte Echtzeit-Überwachung von Ordneränderungen.

## Aufgabenübersicht

### Teil 1: Datei-Vergleich
* Implementierung eines effizienten byte-weisen Vergleichs zweier Dateien.
* Validierung von Existenz, Größe und Inhalt.

### Teil 2: Verzeichnisverwaltung
* Sicherstellung von Ordnerstrukturen (`EnsureDirectoryExists`).
* Automatisierte Testdaten-Generierung für Validierungsprozesse.

## Ausführung

Starten der Konsolenanwendung:
```bash
dotnet run --project FileConsoleApp
```

```Bash
dotnet test
```
