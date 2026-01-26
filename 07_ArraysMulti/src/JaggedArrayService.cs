using System;

namespace _07_ArraysMulti.src
{
    /// <summary>
    /// Service für Operationen auf verzweigten Arrays (Jagged Arrays).
    /// </summary>
    public class JaggedArrayService
    {
        /// <summary>
        /// Erzeut ein Dreieck mit wiederholenden Zahlen.
        /// 1
        /// 2 2
        /// 3 3 3 ...
        /// </summary>
        public int[][] CreateTriangleRepetition(int rows)
        {
            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int val = i + 1;
                jagged[i] = new int[val]; // Zeile i hat i+1 Elemente
                
                // Füllen
                Array.Fill(jagged[i], val); // C# Feature für schnelles Füllen
            }
            return jagged;
        }

        /// <summary>
        /// Erzeugt ein Dreieck mit zählenden Zahlen.
        /// 1
        /// 1 2
        /// 1 2 3 ...
        /// </summary>
        public int[][] CreateTriangleCounting(int rows)
        {
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
