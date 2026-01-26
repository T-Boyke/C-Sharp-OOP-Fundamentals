using System;

namespace GradeCalculator
{
    /// <summary>
    /// Service zur Berechnung von IHK-Noten.
    /// </summary>
    public static class GradeService
    {
        /// <summary>
        /// Ermittelt die Textnote basierend auf der IHK-Punkteskala.
        /// </summary>
        /// <param name="points">Die erreichte Punktzahl (0-100).</param>
        /// <returns>Die Textnote (z.B. "Sehr gut").</returns>
        /// <exception cref="ArgumentOutOfRangeException">Bei Punkten kleiner 0 oder größer 100.</exception>
        /// <example>
        /// <code>
        /// string grade = GradeService.GetGrade(95); // "Sehr gut"
        /// </code>
        /// </example>
        /// <remarks>
        /// Verwendet eine C# Switch Expression für kompakten Code.
        /// </remarks>
        public static string GetGrade(int points)
        {
            if (points < 0 || points > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(points), "Punkte müssen zwischen 0 und 100 liegen.");
            }

            return points switch
            {
                >= 92 => "Sehr gut",
                >= 81 => "Gut",
                >= 67 => "Befriedigend",
                >= 50 => "Ausreichend",
                >= 30 => "Mangelhaft",
                _ => "Ungenügend"
            };
        }
    }
}
