namespace _06_Arrays.src;

/// <summary>
/// Service für allgemeine Array-Operationen und Erzeugung.
/// </summary>
public class ArrayService
{
    private readonly Random _random = new();

    /// <summary>
    /// Erstellt ein Integer-Array mit Zufallszahlen.
    /// </summary>
    /// <param name="size">Größe des Arrays.</param>
    /// <param name="min">Minimaler Wert (inklusiv).</param>
    /// <param name="max">Maximaler Wert (inklusiv?! Random.Next ist exklusiv für Max. Wir passen das an).</param>
    /// <returns>Das gefüllte Array.</returns>
    public int[] CreateRandomArray(int size, int min, int max)
    {
        int[] numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            // Random.Next(min, max) -> max ist exclusive.
            // Wenn Aufgabe sagt "zwischen 1 und 100", ist meist [1, 100] gemeint, also Next(1, 101).
            numbers[i] = _random.Next(min, max + 1);
        }
        return numbers;
    }

    /// <summary>
    /// Generiert Quadratzahlen von 1 bis count.
    /// </summary>
    /// <param name="count">Anzahl der Zahlen (z.B. 10 für 1..10).</param>
    /// <returns>Ein Array mit Quadratzahlen.</returns>
    public int[] GetSquareNumbers(int count)
    {
        int[] squares = new int[count];
        for (int i = 0; i < count; i++)
        {
            int n = i + 1;
            squares[i] = n * n;
        }
        return squares;
    }
}
