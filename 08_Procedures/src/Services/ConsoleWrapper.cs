using _08_Procedures.src.Interfaces;
using System;

namespace _08_Procedures.src.Services
{
    /// <summary>
    /// Implementierung von IConsoleService, die auf System.Console zugreift.
    /// </summary>
    public class ConsoleWrapper : IConsoleService
    {
        public string ReadLine() => Console.ReadLine() ?? string.Empty;

        public void Write(string message) => Console.Write(message);

        public void WriteLine(string message) => Console.WriteLine(message);
    }
}
