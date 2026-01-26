using _08_Procedures.src.Interfaces;
using System.Collections.Generic;

namespace _08_Procedures.Tests
{
    public class MockConsole : IConsoleService
    {
        public List<string> Outputs { get; } = new();
        public Queue<string> Inputs { get; } = new();

        public void WriteLine(string message) => Outputs.Add(message + "\n");
        public void Write(string message) => Outputs.Add(message);
        
        public string ReadLine()
        {
            return Inputs.Count > 0 ? Inputs.Dequeue() : string.Empty;
        }
    }
}
