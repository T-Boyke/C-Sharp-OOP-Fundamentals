using System;

internal class MyDate
{
    // Statisches Array für die Tage pro Monat (Index 0 = Januar - 1, hier direkt Werte 1-12 simulieren oder Index anpassen)
    // Aufgabenstellung nutzt Array direkt, Vorsicht: Array ist 0-indiziert, Monate sind 1-indiziert.
    private static int[] monthLengths = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    public int Day { get; private set; }
    public int Month { get; private set; }
    public int Year { get; private set; }

    // Konstruktor 1: Standard Datum
    public MyDate(int day, int month, int year)
    {
        // Validierung gemäß Hinweis: Bei Fehler 1.1.1900
        if (IsValidDate(day, month, year))
        {
            Day = day;
            Month = month;
            Year = year;
        }
        else
        {
            SetDefaultDate();
        }
    }

    // Konstruktor 2: Tag des Jahres
    public MyDate(int day, int year)
    {
        int maxDays = IsLeapYear(year) ? 366 : 365;

        // Validierung
        if (year < 1 || year > 9999 || day < 1 || day > maxDays)
        {
            SetDefaultDate();
            return;
        }

        Year = year;
        int currentMonth = 1;
        
        // Monat ermitteln durch Subtraktion der Tage
        while (day > GetMonthLength(currentMonth, year))
        {
            day -= GetMonthLength(currentMonth, year);
            currentMonth++;
        }

        Month = currentMonth;
        Day = day;
    }

    // Hilfsmethode für den Fehlerfall (Code-Vermeidung)
    private void SetDefaultDate()
    {
        Day = 1;
        Month = 1;
        Year = 1900;
    }

    // Hilfsmethode zur Validierung
    private bool IsValidDate(int day, int month, int year)
    {
        if (year < 1 || year > 9999) return false;
        if (month < 1 || month > 12) return false;
        if (day < 1 || day > GetMonthLength(month, year)) return false;
        return true;
    }

    public static int GetMonthLength(int month, int year)
    {
        // Array ist 0-basiert, Monat 1-basiert -> month - 1
        if (month < 1 || month > 12) return 0;

        // Februar Sonderfall Schaltjahr
        if (month == 2 && IsLeapYear(year))
        {
            return 29;
        }

        return monthLengths[month - 1];
    }

    public static bool IsLeapYear(int year)
    {
        // Regel für Schaltjahre: durch 4 teilbar, NICHT durch 100, AUSSER durch 400
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    public bool Equals(MyDate date)
    {
        if (date == null) return false;
        return this.Day == date.Day && this.Month == date.Month && this.Year == date.Year;
    }

    public bool IsSameDay(MyDate date)
    {
        if (date == null) return false;
        return this.Day == date.Day && this.Month == date.Month;
    }

    public override string ToString()
    {
        // Format TT.MM.JJJJ. D2 sorgt für führende Nullen (01.01.2025)
        return $"{Day:D2}.{Month:D2}.{Year:D4}";
    }

    public MyDate Tomorrow()
    {
        int nextDay = Day + 1;
        int nextMonth = Month;
        int nextYear = Year;

        // Wenn der Tag die Monatslänge überschreitet
        if (nextDay > GetMonthLength(Month, Year))
        {
            nextDay = 1;
            nextMonth++;
            // Wenn der Monat 12 überschreitet
            if (nextMonth > 12)
            {
                nextMonth = 1;
                nextYear++;
            }
        }

        // Limitierung auf 9999 könnte hier greifen, wird aber laut Aufgabe nicht explizit für Methoden verlangt,
        // Konstruktor fängt es ab (setzt auf 1900) oder wir erlauben den Überlauf.
        // Hier wird ein neues Objekt zurückgegeben.
        return new MyDate(nextDay, nextMonth, nextYear);
    }

    public MyDate Yesterday()
    {
        int prevDay = Day - 1;
        int prevMonth = Month;
        int prevYear = Year;

        if (prevDay < 1)
        {
            prevMonth--;
            if (prevMonth < 1)
            {
                prevMonth = 12;
                prevYear--;
            }
            // Der Tag wird auf den letzten Tag des vorherigen Monats gesetzt
            prevDay = GetMonthLength(prevMonth, prevYear);
        }

        return new MyDate(prevDay, prevMonth, prevYear);
    }
}
