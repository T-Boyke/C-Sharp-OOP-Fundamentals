using System;

namespace _20_EventsExceptions.src
{
    public class TankOverflowException : Exception
    {
        public TankOverflowException(string message) : base(message) { }
    }

    /// <summary>
    /// Simuliert einen Wassertank mit Überlaufschutz und Events.
    /// </summary>
    public class WaterTank
    {
        /// <summary>
        /// Maximale Kapazität des Tanks.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Aktueller Füllstand.
        /// </summary>
        public int CurrentLevel { get; private set; }

        /// <summary>
        /// Wird gefeuert, wenn sich der Wasserstand ändert.
        /// </summary>
        public event EventHandler<WaterLevelEventArgs>? LevelChanged;

        /// <summary>
        /// Initialisiert einen neuen Tank.
        /// </summary>
        /// <param name="capacity">Maximale Kapazität.</param>
        public WaterTank(int capacity)
        {
            Capacity = capacity;
            CurrentLevel = 0;
        }

        /// <summary>
        /// Fügt Wasser hinzu.
        /// Wirft <see cref="TankOverflowException"/>, wenn der Tank überläuft.
        /// Feuert <see cref="LevelChanged"/>, wenn erfolgreich.
        /// </summary>
        /// <param name="amount">Menge des Wassers.</param>
        /// <exception cref="ArgumentException">Bei negativer Menge.</exception>
        /// <exception cref="TankOverflowException">Bei Überlauf.</exception>
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
