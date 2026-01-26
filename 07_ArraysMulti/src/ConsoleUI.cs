using System;
using System.Text;

namespace _07_ArraysMulti.src
{
    class ConsoleUI
    {
        private readonly MatrixService _matrixService = new();
        private readonly JaggedArrayService _jaggedService = new();
        private bool _running = true;

        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (_running)
            {
                Console.Clear();
                Console.WriteLine("=== 07_ArraysMulti: Mehrdimensionale Arrays ===");
                Console.WriteLine("1 - Aufgabe 1: 2x2 Array (Input/Output)");
                Console.WriteLine("2 - Aufgabe 2: Kleines 1x1 (Matrix)");
                Console.WriteLine("3 - Aufgabe 3: 7x7 durch 7 teilbar");
                Console.WriteLine("4 - Aufgabe 4: 10x10 Zahlensuche");
                Console.WriteLine("5 - Aufgabe 5: Dreieck (Wiederholung)");
                Console.WriteLine("6 - Aufgabe 6: Dreieck (Zählung)");
                Console.WriteLine("0 - Ende");
                Console.Write("\nAuswahl: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine("\n-------------------------------");

                switch (choice)
                {
                    case "1": RunTask1(); break;
                    case "2": RunTask2(); break;
                    case "3": RunTask3(); break;
                    case "4": RunTask4(); break;
                    case "5": RunTask5(); break;
                    case "6": RunTask6(); break;
                    case "0": _running = false; break;
                    default: Console.WriteLine("Ungültige Auswahl."); break;
                }

                if (_running)
                {
                    Console.WriteLine("\nBeliebige Taste drücken...");
                    Console.ReadKey();
                }
            }
        }

        private void RunTask1()
        {
            int[,] matrix = new int[2, 2];

            // Input Loop
            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    Console.Write($"Eingabe [{r},{c}]: ");
                    if (int.TryParse(Console.ReadLine(), out int val))
                    {
                        matrix[r, c] = val;
                    }
                }
            }

            // Output Loop
            Console.Write("Eingegebene Zahlen: ");
            for (int r = 0; r < 2; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    // Komma-Logik vereinfacht: einfach alle ausgeben
                    Console.Write($"{matrix[r, c]} ");
                }
            }
        }

        private void RunTask2()
        {
            var table = _matrixService.CreateMultiplicationTable(10);
            PrintMatrix(table);
        }

        private void RunTask3()
        {
            var matrix = _matrixService.CreateRandomMatrix(7, 7, 1, 99);
            PrintMatrix(matrix);
            
            var divisible = _matrixService.GetDivisibleBy(matrix, 7);
            Console.WriteLine($"\nDurch 7 teilbar ({divisible.Count} Stück):");
            Console.WriteLine(string.Join(", ", divisible));
        }

        private void RunTask4()
        {
            var matrix = _matrixService.CreateRandomMatrix(10, 10, 1, 99);
            PrintMatrix(matrix);

            Console.Write("\nWelche Zahl suchen (1-99)? ");
            if (int.TryParse(Console.ReadLine(), out int search))
            {
                var positions = _matrixService.FindPositions(matrix, search);
                if (positions.Count > 0)
                {
                    foreach (var pos in positions)
                        Console.WriteLine($"Gefunden an Position {pos}");
                }
                else
                {
                    Console.WriteLine("Nicht gefunden.");
                }
            }
        }

        private void RunTask5()
        {
            var triangle = _jaggedService.CreateTriangleRepetition(7);
            PrintJagged(triangle);
        }

        private void RunTask6()
        {
            var triangle = _jaggedService.CreateTriangleCounting(7);
            PrintJagged(triangle);
        }

        // Helper Methods for Visualization
        private void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for(int i=0; i<rows; i++)
            {
                for(int j=0; j<cols; j++)
                {
                    Console.Write($"{matrix[i, j],4}"); // Right-aligned width 4
                }
                Console.WriteLine();
            }
        }

        private void PrintJagged(int[][] jagged)
        {
            foreach(var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
