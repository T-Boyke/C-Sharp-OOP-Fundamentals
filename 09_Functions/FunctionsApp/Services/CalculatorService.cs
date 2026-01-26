using System;

namespace FunctionsApp.Services
{
    /// <summary>
    /// Service for mathematical and logical operations.
    /// </summary>
    public static class CalculatorService
    {
        public static int GibMir5() => 5;

        public static int Addition(int a, int b) => a + b;
        public static int Subtraktion(int a, int b) => a - b;
        public static int Multiplikation(int a, int b) => a * b;
        
        public static double Division(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Division durch Null nicht erlaubt.");
            return a / b;
        }

        /// <summary>
        /// Prüft, ob ein Jahr ein Schaltjahr ist.
        /// Regel: Durch 4 teilbar, NICHT durch 100, außer durch 400.
        /// </summary>
        public static bool IstSchaltjahr(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        // Aufgabe 5: Temp Converter
        public static double CelsiusToFahrenheit(double c) => (c * 9.0 / 5.0) + 32;
        public static double FahrenheitToCelsius(double f) => (f - 32) * 5.0 / 9.0;
        public static double CelsiusToKelvin(double c) => c + 273.15;
        
        // Aufgabe 7: Int Reverse (Mathematisch)
        public static int IntReverse(int number)
        {
            int reversed = 0;
            // Handle negative numbers
            bool negative = number < 0;
            number = Math.Abs(number);

            while (number > 0)
            {
                int digit = number % 10;
                reversed = (reversed * 10) + digit;
                number /= 10;
            }

            return negative ? -reversed : reversed;
        }
    }
}
