using System;

namespace ProceduresApp
{
    /// <summary>
    /// Abstraktion für die Ausgabe (Dependency Injection).
    /// Ermöglicht das Testen von Void-Methoden, die auf die Konsole schreiben.
    /// </summary>
    public interface IOutputService
    {
        void WriteLine(string message);
        void Write(string message);
    }

    /// <summary>
    /// Echte Implementierung für die Konsole.
    /// </summary>
    public class ConsoleOutputService : IOutputService
    {
        public void WriteLine(string message) => Console.WriteLine(message);
        public void Write(string message) => Console.Write(message);
    }
}
