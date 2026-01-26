using _19_Collections.src;
using System;

namespace _19_Collections.src
{
    class Program
    {
        static void Main(string[] args)
        {
            string hotelData = "15;D;Peter Schmidt;Wuppertal\n" +
                               "17;E;Hans Meier;Düsseldorf\n" +
                               "23;D;Regina Schulz;Mettmann";

            Console.WriteLine("--- Unit 19: Collections (Hotel) ---");
            
            var service = new HotelService();
            var bookings = service.ProcessBookings(hotelData);
            
            service.PrintBookings(bookings);
        }
    }
}
