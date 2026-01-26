using System;

namespace _10_Classes.src
{
    public class Tv
    {
        // Fields (private for encapsulation)
        private bool _switchedOn;
        private int _volume;

        // Properties (optional, if we wanted public access, but task says GetInfo is the interface)
        public bool SwitchedOn => _switchedOn;
        public int Volume => _volume;

        // Methods
        public void TurnOn()
        {
            _switchedOn = true;
            Console.WriteLine("Fernseher eingeschaltet.");
        }

        public void TurnOff()
        {
            _switchedOn = false;
            Console.WriteLine("Fernseher ausgeschaltet.");
        }

        public void RaiseVolume()
        {
            if (!_switchedOn) return;
            
            if (_volume < 100)
            {
                _volume++;
                Console.WriteLine($"Lautstärke erhöht: {_volume}");
            }
        }

        public void LowerVolume()
        {
            if (!_switchedOn) return;

            if (_volume > 0)
            {
                _volume--;
                Console.WriteLine($"Lautstärke verringert: {_volume}");
            }
        }

        public bool IsOn()
        {
            return _switchedOn;
        }

        public string GetInfo()
        {
            string status = _switchedOn ? "an" : "aus";
            return $"Fernseher {status}: Lautstärke={_volume}";
        }
    }
}
