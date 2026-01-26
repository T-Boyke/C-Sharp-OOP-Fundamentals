using System;

namespace ClassesApp
{
    /// <summary>
    /// Repräsentiert einen Fernseher mit grundlegenden Funktionen.
    /// </summary>
    public class Tv
    {
        // Private Felder (Encapsulation)
        private int _volume;
        private bool _switchedOn;

        // Eigenschaften (Properties) für den Lesezugriff
        public int Volume => _volume;
        public bool IsOn => _switchedOn;

        /// <summary>
        /// Schaltet den Fernseher ein.
        /// </summary>
        public void TurnOn()
        {
            _switchedOn = true;
            Console.WriteLine("Tv: Eingeschaltet.");
        }

        /// <summary>
        /// Schaltet den Fernseher aus.
        /// </summary>
        public void TurnOff()
        {
            _switchedOn = false;
            Console.WriteLine("Tv: Ausgeschaltet.");
        }

        /// <summary>
        /// Erhöht die Lautstärke um 1 (Max 100).
        /// </summary>
        public void RaiseVolume()
        {
            if (!_switchedOn) return;

            if (_volume < 100)
            {
                _volume++;
                Console.WriteLine($"Tv: Lautstärke erhöht auf {_volume}.");
            }
            else
            {
                Console.WriteLine("Tv: Maximale Lautstärke erreicht.");
            }
        }

        /// <summary>
        /// Verringert die Lautstärke um 1 (Min 0).
        /// </summary>
        public void LowerVolume()
        {
            if (!_switchedOn) return;

            if (_volume > 0)
            {
                _volume--;
                Console.WriteLine($"Tv: Lautstärke verringert auf {_volume}.");
            }
            else
            {
                Console.WriteLine("Tv: Ton ist bereits aus.");
            }
        }

        /// <summary>
        /// Liefert einen Statusbericht.
        /// </summary>
        public string GetInfo()
        {
            string status = _switchedOn ? "AN" : "AUS";
            return $"TV Status: {status}, Lautstärke: {_volume}";
        }
    }
}
