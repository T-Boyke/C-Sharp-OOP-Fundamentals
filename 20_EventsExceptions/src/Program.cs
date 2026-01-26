using _20_EventsExceptions.src;
using System;

namespace _20_EventsExceptions.src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Unit 20: Events & Exceptions (Water Tank) ---");
            
            var tank = new WaterTank(100);
            tank.LevelChanged += (sender, e) => 
            {
                Console.WriteLine($"[EVENT] Water Level Changed: {e.OldLevel} -> {e.NewLevel}");
            };

            try
            {
                Console.WriteLine("Adding 50...");
                tank.AddWater(50);
                
                Console.WriteLine("Adding 60 (Should overflow)...");
                tank.AddWater(60);
            }
            catch (TankOverflowException ex)
            {
                Console.WriteLine($"[ERROR] Caught Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Unexpected Exception: {ex.Message}");
            }
        }
    }
}
