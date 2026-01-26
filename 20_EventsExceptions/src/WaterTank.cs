using System;

namespace _20_EventsExceptions.src
{
    public class TankOverflowException : Exception
    {
        public TankOverflowException(string message) : base(message) { }
    }

    public class WaterTank
    {
        public int Capacity { get; }
        public int CurrentLevel { get; private set; }

        public event EventHandler<WaterLevelEventArgs>? LevelChanged;

        public WaterTank(int capacity)
        {
            Capacity = capacity;
            CurrentLevel = 0;
        }

        public void AddWater(int amount)
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative");

            if (CurrentLevel + amount > Capacity)
            {
                throw new TankOverflowException($"Tank overflow! Capacity: {Capacity}, Current: {CurrentLevel}, Add: {amount}");
            }

            int oldLevel = CurrentLevel;
            CurrentLevel += amount;

            // Trigger Event if level changed
            if (oldLevel != CurrentLevel)
            {
                LevelChanged?.Invoke(this, new WaterLevelEventArgs(oldLevel, CurrentLevel));
            }
        }
    }
}
