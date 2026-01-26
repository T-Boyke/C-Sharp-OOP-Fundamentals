using System;

namespace _12_Relationships.src
{
    public class LoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
}
