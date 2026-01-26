using CollectionsApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 19 Collections (Hotel) ===");

        string csvData = 
            "101;Single;Max Mustermann;Berlin\n" +
            "102;Double;Anna Schmidt;Hamburg\n" +
            "201;Suite;John Doe;New York";

        HotelService service = new HotelService();
        var result = service.ParseBookingData(csvData);

        service.PrintBookings(result);
        
        // Dictionary Test
        if (result.Count > 0)
        {
            var firstGuest = result[0];
            Console.WriteLine($"\nDetailzugriff Dictionary: {firstGuest["Name"]} wohnt in Zimmer {firstGuest["RoomNumber"]}");
        }
    }
}
