# 23_FilesAndStreams - Dateisystem und Datenströme

Dieses Projekt behandelt den professionellen Umgang mit Dateien, Verzeichnissen und Streams in C#. Es demonstriert effiziente I/O-Operationen und die Überwachung des Dateisystems.

## Behandelte Konzepte

### 1. Datei-Operationen
* **File & FileInfo**: Erstellen, Lesen, Schreiben und Metadaten-Abfrage.
* **Directory & DirectoryInfo**: Verzeichnisstrukturen verwalten und durchsuchen.

### 2. Streams
* **FileStream**: Byte-orientierter Zugriff für Binärdaten und große Dateien.
* **StreamReader / StreamWriter**: Textbasierte Datenströme mit Encoding-Unterstützung.

### 3. Fortgeschrittene Themen
* **Byte-weiser Vergleich**: Algorithmus zur Prüfung der Datei-Identität (Aufgabe 20260202).
* **FileSystemWatcher**: Ereignisgesteuerte Überwachung von Ordneränderungen.

## Aufgabenübersicht
* **Datei-Vergleich**: Prüfung zweier Dateien auf bit-genaue Gleichheit.
* **Stream-Performance**: Vergleich von Datei-Lese-Methoden.

## Ausführung
```bash
dotnet run --project FileConsoleApp
dotnet test
```
