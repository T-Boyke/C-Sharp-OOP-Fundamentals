using Xunit;
using CollectionsApp;
using System.Collections.Generic;

namespace CollectionsApp.Tests
{
    public class HotelTests
    {
        [Fact]
        public void ParseBookingData_ReturnsCorrectCount()
        {
            string data = "1;S;A;B\n2;D;C;D";
            var service = new HotelService();
            var list = service.ParseBookingData(data);
            
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void ParseBookingData_MapsKeysCorrectly()
        {
            string data = "101;Single;Max;Berlin";
            var service = new HotelService();
            var list = service.ParseBookingData(data);
            
            var guest = list[0];
            Assert.Equal("101", guest["RoomNumber"]);
            Assert.Equal("Single", guest["Category"]);
            Assert.Equal("Max", guest["Name"]);
            Assert.Equal("Berlin", guest["City"]);
        }

        [Fact]
        public void ParseBookingData_HandlesEmptyInput()
        {
            var service = new HotelService();
            var list = service.ParseBookingData("");
            Assert.Empty(list);
        }
    }
}
