using System;
using System.Collections.Generic;

namespace _19_Collections.src
{
    public class HotelService
    {
        public List<Dictionary<string, string>> ProcessBookings(string rawData)
        {
            var bookings = new List<Dictionary<string, string>>();

            if (string.IsNullOrWhiteSpace(rawData)) return bookings;

            // Split by lines (handling diverse line endings)
            var lines = rawData.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                // Format: "15;D;Peter Schmidt;Wuppertal"
                var parts = line.Split(';');
                if (parts.Length < 4) continue; // Skip invalid lines

                var booking = new Dictionary<string, string>();
                
                // 1. Zimmer
                booking["Zimmer"] = parts[0];

                // 2. Typ
                string typ = parts[1] == "D" ? "Doppelzimmer" : "Einzelzimmer";
                booking["Typ"] = typ;

                // 3. Name (Split Vorname Nachname)
                var nameParts = parts[2].Split(' ');
                if (nameParts.Length >= 2)
                {
                    booking["Vorname"] = nameParts[0];
                    booking["Nachname"] = nameParts.Length > 1 ? string.Join(" ", nameParts[1..]) : ""; // Handle multi-part last names
                }
                else
                {
                    booking["Vorname"] = parts[2];
                    booking["Nachname"] = "";
                }

                // 4. Wohnort
                booking["Wohnort"] = parts[3];

                bookings.Add(booking);
            }

            return bookings;
        }

        public void PrintBookings(List<Dictionary<string, string>> bookings)
        {
            foreach (var booking in bookings)
            {
                if (booking.ContainsKey("Zimmer"))
                {
                    Console.WriteLine($"Zimmer {booking["Zimmer"]}:");
                    Console.WriteLine($" Typ: {booking["Typ"]}");
                    Console.WriteLine($" Vorname: {booking.GetValueOrDefault("Vorname", "")}");
                    Console.WriteLine($" Nachname: {booking.GetValueOrDefault("Nachname", "")}");
                    Console.WriteLine($" Wohnort: {booking.GetValueOrDefault("Wohnort", "")}");
                    Console.WriteLine();
                }
            }
        }
    }
}
