using ArraysMultiApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 07 Multi-Dimensional Arrays ===");

        // Task 2: 1x1
        Console.WriteLine("\n--- Task 2: 1x1 Matrix ---");
        var table = MatrixService.CreateMultiplicationTable(10);
        PrintMatrix(table);

        // Task 3: Divisible by 7
        Console.WriteLine("\n--- Task 3: 7x7 Divisible by 7 ---");
        var randomSevens = MatrixService.CreateRandomMatrix(7, 7, 1, 100);
        // PrintMatrix(randomSevens); // Optional
        var divisibles = MatrixService.GetDivisibleBy(randomSevens, 7);
        Console.WriteLine($"Teilbar durch 7: {string.Join(", ", divisibles)}");

        // Task 4: Search
        Console.WriteLine("\n--- Task 4: Matrix Search ---");
        var searchMatrix = MatrixService.CreateRandomMatrix(10, 10, 1, 100);
        PrintMatrix(searchMatrix);
        Console.Write("Welche Zahl suchen? ");
        if (int.TryParse(Console.ReadLine(), out int searchVal))
        {
            var positions = MatrixService.FindPositions(searchMatrix, searchVal);
            if (positions.Count > 0)
            {
                foreach (var pos in positions)
                {
                    Console.WriteLine($"Gefunden bei Zeile {pos.Row}, Spalte {pos.Col}");
                }
            }
            else
            {
                Console.WriteLine("Nicht gefunden.");
            }
        }

        // Task 5: Jagged Repetition
        Console.WriteLine("\n--- Task 5: Triangle Repetition ---");
        var triRep = JaggedArrayService.CreateTriangleRepetition(5);
        PrintJagged(triRep);

        // Task 6: Jagged Counting
        Console.WriteLine("\n--- Task 6: Triangle Counting ---");
        var triCount = JaggedArrayService.CreateTriangleCounting(5);
        PrintJagged(triCount);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Console.Write($"{matrix[r, c],4}"); // Right align formatting
            }
            Console.WriteLine();
        }
    }

    private static void PrintJagged(int[][] jagged)
    {
        foreach (var row in jagged)
        {
            foreach (var val in row)
            {
                Console.Write($"{val} ");
            }
            Console.WriteLine();
        }
    }
}
