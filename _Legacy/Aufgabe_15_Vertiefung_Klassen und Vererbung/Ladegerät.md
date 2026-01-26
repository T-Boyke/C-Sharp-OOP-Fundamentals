Konstruktor der Klasse Ladegerät
// Initialisierung über die statische Methode (Singleton/Flyweight Pattern laut UML)
this.zustand = NichtLadend.getNichtLadend();

// Zugriff auf den Ladestand über das übergebene Objekt 'ladegerät'
if (ladegerät.getLadestand() >= 20 && ladegerät.getLadestand() < 100) {
    // Zustandswechsel auf NormalLadend
    ladegerät.setZustand(NormalLadend.getNormalLadend());
}

### bc) Erläuterung Polymorphie

Die Instanzvariable `zustand` ist vom allgemeinen Datentyp der Oberklasse `Zustand` deklariert. Dank der **Polymorphie** (Vielgestaltigkeit) kann diese Variable jedoch zur Laufzeit Objekte jeder beliebigen Unterklasse (`NichtLadend`, `NormalLadend`, `SchnellLadend`) aufnehmen.

Wenn das `Ladegerät` die Methode `zustand.bearbeiten()` aufruft, wird nicht eine allgemeine Funktion ausgeführt, sondern automatisch die **spezifische Implementierung** des Objekts, das gerade in der Variable liegt (**Dynamische Bindung**).

> **Analogie aus dem Alltag:**
> Stell dir die Variable `zustand` wie einen **Universal-Steckplatz** an einer Konsole vor. Es ist egal, welches Spielmodul (konkreter Zustand: Mario, Zelda, Tetris) du einsteckst – die Konsole drückt immer nur "Start" (`bearbeiten()`). Was dann auf dem Bildschirm passiert (das Verhalten), hängt komplett vom eingesteckten Modul ab, ohne dass die Konsole umgebaut werden muss.
