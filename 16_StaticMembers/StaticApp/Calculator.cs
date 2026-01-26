using System;

namespace StaticApp
{
    /// <summary>
    /// Eine statische Klasse kann nicht instanziiert werden.
    /// Sie dient als Container für Hilfsmethoden.
    /// </summary>
    public static class Calculator
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        
        public static double Divide(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
    }
}
