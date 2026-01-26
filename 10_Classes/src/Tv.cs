using System;

namespace _10_Classes.src
{
    /// <summary>
    /// Repräsentiert einen einfachen Fernseher (TV).
    /// Simuliert Zustand (An/Aus) und Lautstärke.
    /// </summary>
    public class Tv
    {
        // Fields (private for encapsulation)
        private bool _switchedOn;
        private int _volume;

        /// <summary>
        /// Gibt an, ob der Fernseher eingeschaltet ist.
        /// </summary>
        public bool SwitchedOn => _switchedOn;

        /// <summary>
        /// Die aktuelle Lautstärke (0-100).
        /// </summary>
        public int Volume => _volume;

        /// <summary>
        /// Schaltet den Fernseher ein.
        /// </summary>
        public void TurnOn()
        {
            _switchedOn = true;
            Console.WriteLine("Fernseher eingeschaltet.");
        }

        /// <summary>
        /// Schaltet den Fernseher aus.
        /// </summary>
        public void TurnOff()
        {
            _switchedOn = false;
            Console.WriteLine("Fernseher ausgeschaltet.");
        }

        /// <summary>
        /// Erhöht die Lautstärke um 1, maximal bis 100.
        /// Funktioniert nur, wenn das Gerät eingeschaltet ist.
        /// </summary>
        public void RaiseVolume()
        {
            if (!_switchedOn) return;
            
            if (_volume < 100)
            {
                _volume++;
                Console.WriteLine($"Lautstärke erhöht: {_volume}");
            }
        }

        /// <summary>
        /// Verringert die Lautstärke um 1, minimal bis 0.
        /// Funktioniert nur, wenn das Gerät eingeschaltet ist.
        /// </summary>
        public void LowerVolume()
        {
            if (!_switchedOn) return;

            if (_volume > 0)
            {
                _volume--;
                Console.WriteLine($"Lautstärke verringert: {_volume}");
            }
        }

        /// <summary>
        /// Prüft den Status (Alternative zu Property SwitchedOn).
        /// </summary>
        /// <returns>True, wenn an, sonst false.</returns>
        public bool IsOn()
        {
            return _switchedOn;
        }

        /// <summary>
        /// Liefert einen formatierten Infostring zum Gerätezustand.
        /// </summary>
        /// <returns>Status-String.</returns>
        public string GetInfo()
        {
            string status = _switchedOn ? "an" : "aus";
            return $"Fernseher {status}: Lautstärke={_volume}";
        }
    }
}
