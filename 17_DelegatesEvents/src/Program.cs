using _17_DelegatesEvents.src;
using System;

namespace _17_DelegatesEvents.src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Unit 17: Delegates & Events ---");
            
            Clock clock = new Clock();
            Display display = new Display();
            
            Console.WriteLine("Subscribing Display to Clock...");
            display.Subscribe(clock);
            
            Console.WriteLine("Clock Ticks...");
            clock.Tick(); // Should print time via Display
            
            Console.WriteLine($"Display Status: {display.LastMessage}");
        }
    }
}
