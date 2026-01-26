namespace _06_Arrays.src;

/// <summary>
/// Service für Lottozahl-Logik.
/// </summary>
public class LottoService
{
    private readonly Random _random = new();

    /// <summary>
    /// Zieht 6 zufällige, einzigartige Zahlen zwischen 1 und 49.
    /// </summary>
    /// <returns>Ein Boolean-Array der Größe 50, bei dem die Indizes der gezogenen Zahlen auf true gesetzt sind.</returns>
    /// <remarks>
    /// Index 0 wird ignoriert, um direkt mit den Zahlen 1-49 arbeiten zu können.
    /// </remarks>
    /// <example>
    /// <code>
    /// var drawn = lottoService.DrawLottoNumbers();
    /// if (drawn[6]) Console.WriteLine("Die 6 wurde gezogen!");
    /// </code>
    /// </example>
    public bool[] DrawLottoNumbers()
    {
        // Array Größe 50 (Index 0-49) für Zahlen 1-49
        bool[] drawnNumbers = new bool[50];
        int count = 0;

        while (count < 6)
        {
            int nextNumber = _random.Next(1, 50); // 1 bis 49 (50 ist exklusiv)

            if (!drawnNumbers[nextNumber])
            {
                drawnNumbers[nextNumber] = true;
                count++;
            }
        }

        return drawnNumbers;
    }
}
