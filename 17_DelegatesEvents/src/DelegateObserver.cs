using System;

namespace _17_DelegatesEvents.src
{
    public class Clock
    {
        // Event using Action<T> delegate
        public event Action<DateTime>? OnTick;

        public void Tick()
        {
            // Trigger event
            OnTick?.Invoke(DateTime.Now);
        }
    }

    public class Display
    {
        public string LastMessage { get; private set; } = "";

        public void Subscribe(Clock clock)
        {
            // Subscribe method to event
            clock.OnTick += ShowTime;
        }

        public void ShowTime(DateTime time)
        {
            LastMessage = $"Time is: {time:HH:mm:ss}";
            // In a real app: Console.WriteLine(...)
        }
    }
}
