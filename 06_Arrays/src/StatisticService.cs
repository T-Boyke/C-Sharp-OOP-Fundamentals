namespace _06_Arrays.src;

/// <summary>
/// Berechnet statistische Auswertungen für Integer-Arrays.
/// </summary>
/// <remarks>
/// Diese Klasse folgt dem Prinzip der Separation of Concerns (SoC).
/// </remarks>
public class StatisticService
{
    /// <summary>
    /// Berechnet Minimum, Maximum, Summe und Durchschnitt eines Arrays.
    /// </summary>
    /// <param name="numbers">Das Integer-Array, das analysiert werden soll.</param>
    /// <returns>Ein Objekt vom Typ <see cref="ArrayStatistics"/> mit den berechneten Werten.</returns>
    /// <exception cref="ArgumentNullException">Wird geworfen, wenn das Array null ist.</exception>
    /// <exception cref="ArgumentException">Wird geworfen, wenn das Array leer ist.</exception>
    /// <example>
    /// <code>
    /// int[] data = { 1, 2, 3 };
    /// var stats = statisticService.CalculateStatistics(data);
    /// Console.WriteLine(stats.Sum); // Output: 6
    /// </code>
    /// </example>
    public ArrayStatistics CalculateStatistics(int[] numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers), "Das Array darf nicht null sein.");
        }

        if (numbers.Length == 0)
        {
            throw new ArgumentException("Das Array darf nicht leer sein.", nameof(numbers));
        }

        // C# 14 / LINQ Optimierungen
        int min = numbers.Min();
        int max = numbers.Max();
        int sum = numbers.Sum();
        double avg = numbers.Average();

        return new ArrayStatistics(min, max, sum, avg);
    }
}

/// <summary>
/// Datencontainer für statistische Werte.
/// </summary>
/// <param name="Min">Der kleinste Wert.</param>
/// <param name="Max">Der größte Wert.</param>
/// <param name="Sum">Die Summe aller Werte.</param>
/// <param name="Average">Der Durchschnittswert.</param>
public record ArrayStatistics(int Min, int Max, int Sum, double Average);
