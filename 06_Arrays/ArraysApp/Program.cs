using ArraysApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 06 Array Master ===");

        // Aufgabe 1: Random Fill
        Console.WriteLine("\n--- Task 1: Random 10 ---");
        int[] randoms = ArrayService.CreateRandomArray(10, 1, 101); // 1-100
        Console.WriteLine(string.Join(", ", randoms));

        // Aufgabe 2: Squares & Reverse
        Console.WriteLine("\n--- Task 2: Squares Reverse ---");
        int[] squares = ArrayService.GetSquares(10);
        int[] reversed = ArrayService.ReverseCopy(squares);
        Console.WriteLine(string.Join(", ", reversed));

        // Aufgabe 4: Statistics
        Console.WriteLine("\n--- Task 4: Statistics ---");
        var stats = StatisticService.Calculate(randoms); // Nutze Array aus Task 1
        Console.WriteLine(stats);

        // Aufgabe 5: Lotto
        Console.WriteLine("\n--- Task 5: Lotto 6 aus 49 ---");
        bool[] lotto = LottoService.DrawSixOutOfFortyNine();
        Console.Write("Gezogen: ");
        for (int i = 1; i < lotto.Length; i++)
        {
            if (lotto[i]) Console.Write($"{i} ");
        }
        Console.WriteLine();

        // Aufgabe 6: Binary
        Console.WriteLine("\n--- Task 6: Binary Converter ---");
        int decimalNum = 42;
        int[] bin = BinaryService.ToBinary8Bit(decimalNum);
        Console.WriteLine($"{decimalNum} in Binär: {string.Join("", bin)}");
    }
}
