using System;
using System.Text;

namespace ProceduresApp
{
    /// <summary>
    /// Beinhaltet die Lösungen für die Aufgaben 1-9 (Prozeduren).
    /// </summary>
    public class ProcedureContainer
    {
        private readonly IOutputService _output;

        /// <summary>
        /// Konstruktor mit Dependency Injection.
        /// </summary>
        /// <param name="output">Der Ausgabeservice (Konsole oder Mock).</param>
        public ProcedureContainer(IOutputService output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        // Aufgabe 1
        public void AusgabeGutenMorgen()
        {
            _output.WriteLine("Guten Morgen!");
        }

        // Aufgabe 2 & 3
        public void AusgabeText(string text)
        {
            _output.WriteLine(text);
        }

        // Aufgabe 4
        public void Addition(int zahl1, int zahl2)
        {
            _output.WriteLine($"{zahl1} + {zahl2} = {zahl1 + zahl2}");
        }

        // Aufgabe 5
        public void AusgabeText(string text, int anzahl)
        {
            for (int i = 0; i < anzahl; i++)
            {
                _output.WriteLine(text);
            }
        }

        // Aufgabe 6
        public void Prozedur3() => _output.WriteLine("Prozedur 3");

        public void Prozedur2()
        {
            Prozedur3();
            _output.WriteLine("Prozedur 2");
        }

        public void Prozedur1()
        {
            Prozedur2();
            _output.WriteLine("Prozedur 1");
        }

        // Aufgabe 7 (Taschenrechner)
        public void Subtraktion(int a, int b) => _output.WriteLine($"{a} - {b} = {a - b}");
        public void Multiplikation(int a, int b) => _output.WriteLine($"{a} * {b} = {a * b}");
        public void Division(double a, double b)
        {
            if (b == 0) _output.WriteLine("Fehler: Division durch Null!");
            else _output.WriteLine($"{a} / {b} = {a / b}");
        }

        // Aufgabe 8
        public void ArrayAusgabe(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                var sb = new StringBuilder();
                for (int c = 0; c < cols; c++)
                {
                    sb.Append($"{matrix[r, c]} ");
                }
                _output.WriteLine(sb.ToString().Trim());
            }
        }

        // Aufgabe 9
        public void AnzeigeTeiler(int zahl)
        {
            var sb = new StringBuilder();
            sb.Append($"Teiler von {zahl}: ");
            
            for (int i = 1; i <= zahl; i++)
            {
                if (zahl % i == 0)
                {
                    sb.Append($"{i} ");
                }
            }
            _output.WriteLine(sb.ToString().Trim());
        }
    }
}
