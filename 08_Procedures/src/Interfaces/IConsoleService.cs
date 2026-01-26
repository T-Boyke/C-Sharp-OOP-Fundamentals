namespace _08_Procedures.src.Interfaces
{
    /// <summary>
    /// Abstrahiert die Konsolenausgabe für bessere Testbarkeit (TDD).
    /// </summary>
    public interface IConsoleService
    {
        void WriteLine(string message);
        void Write(string message);
        string ReadLine();
    }
}
