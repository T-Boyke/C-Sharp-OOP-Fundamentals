# C-Sharp-OOP-and-UML-Fundamentals

![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C# 14](https://img.shields.io/badge/C%23-14.0-239120?style=for-the-badge&logo=csharp&logoColor=white)
![LTS](https://img.shields.io/badge/Support-LTS-blue?style=for-the-badge)
![License MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)
![TDD Optimized](https://img.shields.io/badge/TDD-Optimized-green?style=for-the-badge)

Professional C# learning repository focusing on Clean Code, TDD, and IHK-compliant documentation.

## 📋 Inhaltsverzeichnis (TOC)
- [Einrichtung 2026](#einrichtung-2026)
- [Best Practices & Features](#best-practices--features)
- [Methodik (TDD & SFC)](#methodik-tdd--sfc)
- [Lerneinheiten](#lerneinheiten)

---

## Einrichtung 2026

### 🛠️ Entwicklungsumgebung (IDE)

#### Visual Studio 2026 Community
1.  **Download**: Laden Sie den Installer von der offiziellen Microsoft-Seite.
2.  **Workloads**: Wählen Sie bei der Installation:
    *   `.NET Desktop Development`
    *   `.NET 10 SDK`
3.  **Extensions**: Installieren Sie *GitHub Copilot Chat NEXT* und *Roslyn Analyzers*.

#### JetBrains Rider 2026 (Education Pack)
1.  **Installation**: Nutzen Sie die JetBrains Toolbox App.
2.  **Konfiguration**: Stellen Sie sicher, dass das .NET 10 SDK erkannt wird (`Settings > Build, Execution, Deployment > Toolset and Build`).
3.  **Plugins**:
    *   *ReSharper 2026.1* (integriert)
    *   *SonarLint*

### 📦 .NET 10 SDK
Stellen Sie sicher, dass die Version `10.0.x` installiert ist.
```bash
dotnet --version
```

---

## Best Practices & Features

### 🚀 C# 14 Highlights
Wir setzen konsequent auf moderne Sprachfeatures:

*   **Primary Constructors**: Für prägnante Klassendefinitionen.
    ```csharp
    public class Person(string name, int age);
    ```
*   **Enhanced Collection Expressions**:
    ```csharp
    int[] numbers = [1, 2, 3, 4];
    ```
*   **Lambda Default Parameters**:
    ```csharp
    var greet = (string name = "Welt") => $"Hallo {name}!";
    ```
*   **Field Keywords**: Automatische Properties mit Validierung (Preview Feature).

### 🐙 GitHub Workflow
*   **Branching**: GitFlow (main, develop, feature branches).
*   **Commits**: [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) (z.B. `feat: add array statistics logic`).
*   **Issues**: Nutzen Sie die bereitgestellten Templates für Bugs und Features.

---

## Methodik (TDD & SFC)

### 🔴🟢🔵 Red-Green-Refactor
1.  **Red**: Schreiben Sie einen fehlschlagenden Test, der die Anforderung beschreibt.
2.  **Green**: Implementieren Sie den minimal notwendigen Code, um den Test zu bestehen.
3.  **Refactor**: Optimieren Sie den Code (Clean Code), ohne die Funktionalität zu ändern.

### 🧩 Separation of Concerns (SFC)
*   **Logic**: Reine C#-Logik in Services/Klassen (testbar).
*   **UI**: Konsolenausgaben nur in `Program.cs` oder dedizierten UI-Klassen.
*   **Data**: Datenhaltung getrennt von der Verarbeitung.

---

## Lerneinheiten

| Einheit | Thema | Status |
| :--- | :--- | :--- |
| [06_Arrays](./06_Arrays) | Arrays, Statistik, Algorithmen | 🚧 In Arbeit |
