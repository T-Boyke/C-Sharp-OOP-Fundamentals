using _08_Procedures.src.Interfaces;
using System;
using System.Collections.Generic;

namespace _08_Procedures.src.Services
{
    /// <summary>
    /// Beinhaltet die Logik für alle Prozedur-Aufgaben.
    /// Nutzt IConsoleService für Ausgaben, um Testbarkeit zu gewährleisten.
    /// </summary>
    public class ProcedureService(IConsoleService console)
    {
        // Aufgabe 1
        public void AusgabeGutenMorgen()
        {
            console.WriteLine("Guten Morgen!");
        }

        // Aufgabe 2
        public void AusgabeText(string text)
        {
            console.WriteLine(text);
        }

        // Aufgabe 3
        public void InputOutput()
        {
            console.Write("Eingabe: ");
            string input = console.ReadLine();
            console.WriteLine($"Sie haben '{input}' eingegeben.");
        }

        // Aufgabe 4
        public void Addition(int n1, int n2)
        {
            int sum = n1 + n2;
            console.WriteLine($"Das Ergebnis der Addition ist {sum}.");
        }

        // Aufgabe 5
        public void MehrfacheAusgabe(string text, int count)
        {
            for (int i = 0; i < count; i++)
            {
                console.WriteLine(text);
            }
        }

        // Aufgabe 6 (Verkettung)
        public void Prozedur1()
        {
            console.WriteLine("Hallo von Prozedur1");
            Prozedur2();
        }

        public void Prozedur2() // Sollte public sein oder private? Task says "Programm contains...".
        {
            console.WriteLine("Hallo von Prozedur2");
            Prozedur3();
        }

        public void Prozedur3()
        {
            console.WriteLine("Hallo von Prozedur3");
        }

        // Aufgabe 7 (Taschenrechner)
        public void Calculate(int n1, int n2, string op)
        {
            switch (op)
            {
                case "+": Addition(n1, n2); break; // Reuse Aufgabe 4 method? Format might differ.
                case "-": console.WriteLine($"Das Ergebnis der Subtraktion ist {n1 - n2}."); break;
                case "*": console.WriteLine($"Das Ergebnis der Multiplikation ist {n1 * n2}."); break;
                case "/":
                    if (n2 == 0) console.WriteLine("Teilen durch Null nicht erlaubt.");
                    else console.WriteLine($"Das Ergebnis der Division ist {(double)n1 / n2}.");
                    break;
                default: console.WriteLine("Ungültiger Operator."); break;
            }
        }

        // Aufgabe 8
        public void PrintArray(int[,] array)
        {
            console.WriteLine("Inhalt des Arrays:");
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    console.Write($"{array[i, j]} ");
                }
                console.WriteLine(""); // Newline after row
            }
        }

        // Aufgabe 9
        public void PrintDivisors(int number)
        {
            var divisors = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }
            console.WriteLine($"Teiler von {number} sind: {string.Join(", ", divisors)}");
        }
    }
}
