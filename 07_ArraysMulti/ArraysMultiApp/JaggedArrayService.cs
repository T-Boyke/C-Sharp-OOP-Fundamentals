using System;

namespace ArraysMultiApp
{
    /// <summary>
    /// Service for operations on Jagged Arrays (Arrays of Arrays).
    /// </summary>
    public static class JaggedArrayService
    {
        /// <summary>
        /// Erstellt ein Dreiecksmuster, bei dem die Zahl der Zeilennummer entspricht.
        /// 1
        /// 2 2
        /// 3 3 3
        /// </summary>
        public static int[][] CreateTriangleRepetition(int rows)
        {
            if (rows < 1) throw new ArgumentOutOfRangeException(nameof(rows));

            int[][] jagged = new int[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                int rowNum = i + 1;     // Zeile 1, 2, 3...
                jagged[i] = new int[rowNum]; // Länge entspricht Zeilennummer

                // Füllen
                Array.Fill(jagged[i], rowNum);
            }
            return jagged;
        }

        /// <summary>
        /// Erstellt ein Dreiecksmuster, das hochzählt.
        /// 1
        /// 1 2
        /// 1 2 3
        /// </summary>
        public static int[][] CreateTriangleCounting(int rows)
        {
            if (rows < 1) throw new ArgumentOutOfRangeException(nameof(rows));

            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int length = i + 1;
                jagged[i] = new int[length];

                for (int j = 0; j < length; j++)
                {
                    jagged[i][j] = j + 1;
                }
            }
            return jagged;
        }
    }
}
