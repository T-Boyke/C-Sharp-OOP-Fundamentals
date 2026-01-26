using _19_Collections.src;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace _19_Collections.Tests
{
    public class CollectionTests
    {
        private readonly HotelService _service = new();

        [Fact]
        public void ParseBookingData_ParsesCorrectly()
        {
            string input = "15;D;Peter Schmidt;Wuppertal\n17;E;Hans Meier;Düsseldorf";
            
            List<Dictionary<string, string>> result = _service.ProcessBookings(input);

            Assert.Equal(2, result.Count);

            // Check first entry
            var entry1 = result[0];
            Assert.Equal("15", entry1["Zimmer"]);
            Assert.Equal("Doppelzimmer", entry1["Typ"]); // D -> Doppelzimmer
            Assert.Equal("Peter", entry1["Vorname"]);
            Assert.Equal("Schmidt", entry1["Nachname"]);
            Assert.Equal("Wuppertal", entry1["Wohnort"]);

            // Check second entry
            var entry2 = result[1];
            Assert.Equal("17", entry2["Zimmer"]);
            Assert.Equal("Einzelzimmer", entry2["Typ"]); // E -> Einzelzimmer
        }

        [Fact]
        public void ParseBookingData_HandlesEmptyInput()
        {
            var result = _service.ProcessBookings("");
            Assert.Empty(result);
        }
    }
}
