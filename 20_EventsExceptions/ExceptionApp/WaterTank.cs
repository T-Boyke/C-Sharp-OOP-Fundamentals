using System;

namespace ExceptionApp
{
    public class WaterTank
    {
        public int Capacity { get; }
        private int _currentLevel;
        
        public int CurrentLevel => _currentLevel;

        /// <summary>
        /// Standard .NET Event Pattern: EventHandler<TEventArgs>
        /// </summary>
        public event EventHandler<WaterLevelEventArgs>? LevelChanged;

        public WaterTank(int capacity)
        {
            Capacity = capacity;
            _currentLevel = 0;
        }

        public void AddWater(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Water amount cannot be negative.");
            
            // Check Overflow BEFORE changing state
            if (_currentLevel + amount > Capacity)
            {
                throw new OverflowException($"Tank overflow! Capacity: {Capacity}, Current: {_currentLevel}, Attempted to add: {amount}");
            }

            int oldLevel = _currentLevel;
            _currentLevel += amount;

            // Fire Event if level changed
            if (oldLevel != _currentLevel)
            {
                OnLevelChanged(new WaterLevelEventArgs(oldLevel, _currentLevel));
            }
        }

        protected virtual void OnLevelChanged(WaterLevelEventArgs e)
        {
            LevelChanged?.Invoke(this, e);
        }
    }
}
