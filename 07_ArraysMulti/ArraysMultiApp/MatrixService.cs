using System;
using System.Collections.Generic;

namespace ArraysMultiApp
{
    /// <summary>
    /// Service for operations on 2D Arrays (Matrices).
    /// </summary>
    public static class MatrixService
    {
        private static readonly Random _random = new();

        /// <summary>
        /// Erstellt eine Multiplikationstabelle (Kleines 1x1).
        /// </summary>
        /// <param name="size">Größe der Tabelle (z.B. 10 für 10x10).</param>
        /// <returns>Ein 2D-Array gefüllt mit Produkten.</returns>
        public static int[,] CreateMultiplicationTable(int size)
        {
            if (size < 1) throw new ArgumentOutOfRangeException(nameof(size));

            int[,] table = new int[size, size];
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    table[r, c] = (r + 1) * (c + 1);
                }
            }
            return table;
        }

        /// <summary>
        /// Erstellt eine Matrix mit Zufallszahlen.
        /// </summary>
        public static int[,] CreateRandomMatrix(int rows, int cols, int min, int max)
        {
            if (rows < 1 || cols < 1) throw new ArgumentOutOfRangeException("Dimensions must be positive.");

            int[,] matrix = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = _random.Next(min, max);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Findet alle Positionen eines Wertes in der Matrix.
        /// </summary>
        /// <returns>Eine Liste von Tupeln (Zeile, Spalte).</returns>
        public static List<(int Row, int Col)> FindPositions(int[,] matrix, int value)
        {
            var positions = new List<(int, int)>();
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (matrix[r, c] == value)
                    {
                        positions.Add((r, c));
                    }
                }
            }
            return positions;
        }

        /// <summary>
        /// Gibt alle Zahlen zurück, die durch den Teiler teilbar sind.
        /// </summary>
        public static List<int> GetDivisibleBy(int[,] matrix, int divisor)
        {
            var result = new List<int>();
            foreach (int num in matrix)
            {
                if (num % divisor == 0)
                {
                    result.Add(num);
                }
            }
            // Sortieren für schönere Ausgabe
            result.Sort();
            return result;
        }
    }
}
