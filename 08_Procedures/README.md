[⬅️ Zurück zum Hauptverzeichnis](../README.md)

# 08 - Prozeduren (Void Methoden)

## 💡 Theorie
Prozeduren sind Methoden ohne Rückgabewert (`void`). Sie führen Befehle aus (Side-Effects).
Das macht sie schwerer zu testen, da sie kein Ergebnis `return`-en, sondern z.B. nur auf die Konsole schreiben.

### Dependency Injection (Testbarkeit)
Um `Console.WriteLine` testbar zu machen, nutzen wir ein Interface:
```csharp
public interface IOutputService { void WriteLine(string s); }

// Im Code nutzen wir NUR das Interface:
class MyService(IOutputService output) {
    public void DoWork() => output.WriteLine("Work Done");
}
```
So können wir im Test das "Schreiben" abfangen und prüfen!

## 📝 Aufgabenstellung
Implementieren Sie diverse Prozeduren (siehe Source):
1.  `AusgabeGutenMorgen()`
2.  `AusgabeText(string text)`
3.  `Addition(int a, int b)`
4.  `AusgabeText(string text, int anzahl)`
5.  `Prozedur1` -> `Prozedur2` -> `Prozedur3` (Verkettung)
6.  `Taschenrechner` (Add, Sub, Mul, Div) mit Fehlerbehandlung für Div/0.
7.  `ArrayAusgabe(int[,] matrix)`
8.  `AnzeigeTeiler(int zahl)`

## 🧩 UML Klassendiagramm

```mermaid
classDiagram
    class IOutputService {
        <<interface>>
        +WriteLine(string msg)
        +Write(string msg)
    }

    class ConsoleOutputService {
        +WriteLine(string msg)
        +Write(string msg)
    }

    class ProcedureContainer {
        -IOutputService _output
        +AusgabeGutenMorgen()
        +Addition(int a, int b)
        +Division(double a, double b)
        +AnzeigeTeiler(int zahl)
    }

    IOutputService <|.. ConsoleOutputService : implements
    ProcedureContainer o-- IOutputService : injects
```

## ✅ Definition of Done
- [ ] Alle Ausgaben laufen über `IOutputService`.
- [ ] Unit Tests nutzen einen `MockOutputService`.
- [ ] Division durch Null fängt Fehler ab.
