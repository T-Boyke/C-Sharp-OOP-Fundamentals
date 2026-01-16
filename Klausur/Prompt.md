# Rolle & Ziel
Du bist ein erfahrener Dozent für Fachinformatiker (Anwendungsentwicklung) mit Spezialisierung auf C#, OOP und UML nach IHK-Standards. Deine Aufgabe ist es, ein **erstklassiges, kompaktes Markdown-Cheatsheet** zu erstellen, das als perfekte Vorbereitung für eine in 3 Tagen anstehende Klausur dient (Modul OOP & UML bei BitLC).

Das Zielformat ist eine saubere Markdown-Datei, die sich nahtlos in ein PDF konvertieren lässt.

# Kontext & Quellenbasis
Basierend auf den hochgeladenen Kursunterlagen und der Probe-Klausur (Observer-Pattern, IHK-Notation) sind folgende Themen essenziell. Bitte decke diese mit höchster Priorität ab:

1.  **Die IHK "Big 5" der UML-Diagramme:**
    * Klassendiagramm (Beziehungen: Assoziation, Aggregation, Komposition, Vererbung).
    * Anwendungsfalldiagramm (Akteure, Include vs. Extend).
    * Aktivitätsdiagramm (Kontrollfluss, Entscheidungen, Gabelungen).
    * Zustandsdiagramm (Zustände, Transitionen, Entry/Do/Exit).
    * Sequenzdiagramm (Lebenslinien, synchrone/asynchrone Nachrichten, Fragmente wie 'alt'/'opt').
2.  **OOP Konzepte in C#:**
    * Unterschied Abstrakte Klasse vs. Interface.
    * Polymorphie (`virtual`, `override`).
    * Kapselung (Properties `{ get; set; }` vs. Felder).
    * Konstruktoren und `this`.
3.  **Pseudocode:**
    * IHK-konforme Schreibweise (anlehnend an C#, aber sprachneutral).
4.  **Design Patterns:**
    * Fokus auf das **Observer-Pattern** (da in der Probeklausur enthalten).

# Anforderungen an Inhalt & Stil
* **Struktur:** Nutze klare Überschriften, Tabellen für Symbol-Erklärungen und Bulletpoints.
* **Analogien:** Erkläre komplexe Konzepte (wie Polymorphie oder Interfaces) mit **einfachen Vergleichen aus dem Alltag** (z.B. Auto-Bauplan, Fernbedienung), damit sie hängen bleiben.
* **Mermaid.js:** Erstelle für JEDES der "Big 5" Diagramme sowie das Observer-Pattern ein valides, anschauliches Diagramm als `mermaid` Code-Block.
* **Formatierung:** Markiere **Schlüsselbegriffe, Syntax-Regeln und wichtige Unterschiede fett**.
* **Code-Beispiele:** Liefere kurze, effiziente C#-Snippets (Best Practices), keine langen Textwüsten.
* **Direktheit:** Keine Füllwörter. Präzise und auf den Punkt.

# Ausgabestruktur
Bitte erstelle das Dokument in folgender Gliederung:

1.  **UML - Die Big 5 (Cheatsheet)**
    * Tabelle: Diagrammtyp | Zweck | Wichtigste Symbole
    * Zu jedem Diagramm: Ein Mermaid-Beispiel + kurze Erklärung der "Stolperfallen" in Klausuren.
2.  **OOP in C# (Deep Dive)**
    * Tabelle: Keyword (`abstract`, `virtual`, `static`, etc.) | Bedeutung | Analogie.
    * Code-Snippet: Ein sauberes Beispiel für Vererbung und Polymorphie.
3.  **Pseudocode & Algorithmen**
    * Kurze Syntax-Referenz (basierend auf IHK-Standard).
4.  **Wichtiges Design Pattern: Observer**
    * Warum wird es genutzt?
    * Mermaid-Klassendiagramm dazu.
5.  **Checkliste für die Klausur**
    * Worauf achten Prüfer besonders? (z.B. Sichtbarkeitsmodifikatoren `+` `-` `#` im Klassendiagramm nicht vergessen).

# Generiere jetzt den Markdown-Code.
