using System;

namespace _09_Functions.src
{
    public class InputService
    {
        public int EingabeInt(string prompt)
        {
            int result;
            do
            {
                Console.Write(prompt + " ");
            } while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }

        public int EingabeInt(string prompt, int min, int max)
        {
            int result;
            bool valid;
            do
            {
                Console.Write($"{prompt} ({min}-{max}): ");
                valid = int.TryParse(Console.ReadLine(), out result);
                if (valid && (result < min || result > max)) valid = false;
            } while (!valid);
            return result;
        }

        public double EingabeDouble(string prompt)
        {
            double result;
            do
            {
                Console.Write(prompt + " ");
            } while (!double.TryParse(Console.ReadLine(), out result));
            return result;
        }

        public bool EingabeBool(string prompt)
        {
            // Simple approach: true/false, or j/n?
            Console.Write(prompt + " (true/false): ");
            bool.TryParse(Console.ReadLine(), out bool res);
            return res;
        }
    }
}
