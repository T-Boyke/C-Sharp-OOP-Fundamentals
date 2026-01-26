using System;
using System.Collections.Generic;

namespace CollectionsApp
{
    public class HotelService
    {
        public List<Dictionary<string, string>> ParseBookingData(string rawData)
        {
            var bookings = new List<Dictionary<string, string>>();

            if (string.IsNullOrWhiteSpace(rawData)) return bookings;

            // Zerlegen in einzelne Zeilen (Buchungen)
            // Annahme: Datensätze getrennt durch '\n' oder Pipe '|' oder ähnliches?
            // Aufgabe sagt "15;D;Peter Schmidt;Wuppertal\n..."
            
            var lines = rawData.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length >= 4)
                {
                    // Erstelle Dictionary für diesen Gast
                    var guest = new Dictionary<string, string>();
                    
                    guest["RoomNumber"] = parts[0];
                    guest["Category"]   = parts[1];
                    guest["Name"]       = parts[2];
                    guest["City"]       = parts[3];

                    bookings.Add(guest);
                }
            }

            return bookings;
        }

        public void PrintBookings(List<Dictionary<string, string>> bookings)
        {
            Console.WriteLine($"\n--- Gefundene Buchungen: {bookings.Count} ---");
            foreach (var guest in bookings)
            {
                if (guest.ContainsKey("Name") && guest.ContainsKey("RoomNumber"))
                {
                    Console.WriteLine($"Gast: {guest["Name"]} (Zimmer {guest["RoomNumber"]}) aus {guest["City"]}");
                }
            }
        }
    }
}
