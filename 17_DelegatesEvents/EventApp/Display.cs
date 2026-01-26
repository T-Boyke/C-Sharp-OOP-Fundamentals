using System;

namespace EventApp
{
    public class Display
    {
        public void ShowTime(DateTime time)
        {
            Console.WriteLine($"Display: Aktuelle Zeit ist {time:HH:mm:ss.fff}");
        }
    }
}
