using System;

namespace FunctionsApp.Services
{
    public static class InputService
    {
        public static int EingabeInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " ");
                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                Console.WriteLine("Fehler: Ungültige Ganzzahl.");
            }
        }

        public static int EingabeInt(string prompt, int min, int max)
        {
            while (true)
            {
                int val = EingabeInt(prompt);
                if (val >= min && val <= max) return val;
                Console.WriteLine($"Fehler: Zahl muss zwischen {min} und {max} liegen.");
            }
        }
    }
}
