using System;
using System.Collections.Generic;

namespace _07_ArraysMulti.src
{
    /// <summary>
    /// Service für Operationen auf zweidimensionalen Arrays (Matrizen).
    /// </summary>
    public class MatrixService
    {
        private readonly Random _random = new();

        /// <summary>
        /// Erstellt eine Multiplikationstabelle (Kleines 1x1) bis zur angegebenen Größe.
        /// </summary>
        /// <param name="size">Die Größe der Tabelle (z.B. 10 für 1x1 bis 10x10).</param>
        /// <returns>Ein quadratisches 2D-Array mit den Ergebnissen.</returns>
        public int[,] CreateMultiplicationTable(int size)
        {
            int[,] table = new int[size, size];

            for (int r = 0; r < size; r++) // Rows
            {
                for (int c = 0; c < size; c++) // Columns
                {
                    table[r, c] = (r + 1) * (c + 1);
                }
            }
            return table;
        }

        /// <summary>
        /// Erstellt eine Matrix gefüllt mit Zufallszahlen.
        /// </summary>
        /// <param name="rows">Anzahl der Zeilen.</param>
        /// <param name="cols">Anzahl der Spalten.</param>
        /// <param name="min">Minimaler Zufallswert.</param>
        /// <param name="max">Maximaler Zufallswert.</param>
        /// <returns>Das gefüllte 2D-Array.</returns>
        public int[,] CreateRandomMatrix(int rows, int cols, int min = 1, int max = 99)
        {
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = _random.Next(min, max + 1);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Sucht alle Positionen eines Wertes in der Matrix.
        /// </summary>
        /// <param name="matrix">Die zu durchsuchende Matrix.</param>
        /// <param name="value">Der gesuchte Wert.</param>
        /// <returns>Eine Liste von Strings im Format "[Zeile, Spalte]".</returns>
        public List<string> FindPositions(int[,] matrix, int value)
        {
            var positions = new List<string>();
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == value)
                    {
                        positions.Add($"[{i}, {j}]");
                    }
                }
            }
            return positions;
        }

        /// <summary>
        /// Findet alle Zahlen in der Matrix, die durch den Divisor teilbar sind.
        /// </summary>
        /// <param name="matrix">Die Matrix.</param>
        /// <param name="divisor">Der Teiler (z.B. 7).</param>
        /// <returns>Eine Liste der teilbaren Zahlen.</returns>
        public List<int> GetDivisibleBy(int[,] matrix, int divisor)
        {
            var results = new List<int>();
            foreach (int num in matrix) // foreach iteriert durch alle Elemente eines 2D-Arrays
            {
                if (num % divisor == 0)
                {
                    results.Add(num);
                }
            }
            return results;
        }
    }
}
