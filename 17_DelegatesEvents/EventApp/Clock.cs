using System;
using System.Threading;

namespace EventApp
{
    public class Clock
    {
        // Event using the modern 'Action' delegate type
        public event Action<DateTime>? OnTick;

        public void Run(int ticks)
        {
            for (int i = 0; i < ticks; i++)
            {
                Thread.Sleep(100); // Fast simulation: 100ms instead of 1000ms
                
                // Invoke the event safely
                OnTick?.Invoke(DateTime.Now);
            }
        }
    }
}
