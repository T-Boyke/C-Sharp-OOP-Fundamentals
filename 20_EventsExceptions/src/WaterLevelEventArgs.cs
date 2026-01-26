using System;

namespace _20_EventsExceptions.src
{
    public class WaterLevelEventArgs : EventArgs
    {
        public int OldLevel { get; }
        public int NewLevel { get; }

        public WaterLevelEventArgs(int oldLevel, int newLevel)
        {
            OldLevel = oldLevel;
            NewLevel = newLevel;
        }
    }
}
