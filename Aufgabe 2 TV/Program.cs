namespace Aufgabe_2_TV
{
    class Fernbedienung
    {
        static void Main(string[] args)
        {
            // Objekt erzeugen
            TV Sony = new TV();

            Sony.GetInfo();      // Ist noch aus, Lautstärke 10, Programm 1

            Sony.TurnOn();       // Anschalten
            Sony.RaiseVolume();  // Lauter +1
            Sony.RaiseVolume(15); // Lauter +15 (Aufgabe d)
            Sony.SetChannel(5);  // Programm wechseln (Aufgabe e)
            Sony.LowerVolume();  // Leiser

            Sony.GetInfo();      // An, Lautstärke 25, Programm 5

            Sony.TurnOff();      // Ausschalten

            Console.ReadKey();
        }
    }
    // Aufgabe A Erstellen sie eine Klasse TV in C# mit den Attributen switchOn (bool), volume (int) und channel (int) und weiteren Methoden.
    public class TV
    {
        // Private attributes
        private bool switchOn;
        private int volume;
        private int channel;

        // Constructor
        public TV()
        {
            switchOn = false;
            volume = 10; // Default volume
            channel = 1; // Default channel
        }

        // Fernbedienung Methoden
        public void TurnOn()
        {
            switchOn = true;
            Console.WriteLine("Glotze ist an!");
        }
        public void TurnOff()
        {
            switchOn = false;
            Console.WriteLine("Glotze ist aus!");
        }
        public bool IsOn()
        {
            return switchOn;
        }
        // Aufgabe C Erweitern sie die Klasse in c# so dass die Lautstärke nur zwischen 0 und 100 liegen kann.
        public void RaiseVolume()
        {
            if (switchOn)
            {
                if (volume < 100)
                {
                    volume++;
                    Console.WriteLine($"Lautstärke erhöht auf: {volume}");
                }
                else
                {
                    Console.WriteLine("Maximale Lautstärke erreicht (100).");
                }
            }
            else
            {
                Console.WriteLine("TV ist aus. Lautstärke kann nicht geändert werden.");
            }
        }
        // Zu Aufgabe d) Änderung in anderen Schrittweiten - Lösung: Überberladung
        public void RaiseVolume(int step)
        {
            if (switchOn)
            {
                if (volume + step <= 100)
                {
                    volume += step;
                    Console.WriteLine($"Lautstärke um {step} erhöht auf: {volume}");
                }
                else
                {
                    volume = 100;
                    Console.WriteLine("Maximale Lautstärke erreicht (100).");
                }
            }
        }

        public void LowerVolume()
        {
            if (switchOn)
            {
                if (volume > 0)
                {
                    volume--;
                    Console.WriteLine($"Lautstärke verringert auf: {volume}");
                }
                else
                {
                    Console.WriteLine("Ton ist bereits aus (0).");
                }
            }
        }
        // Zu Aufgabe e) Programm einstellen
        // Lösung: Neues Attribut 'channel' und eine Methode zum Setzen
        public void SetChannel(int newChannel)
        {
            if (switchOn)
            {
                if (newChannel > 0 && newChannel <= 999) // Annahme: Sender 1-999
                {
                    channel = newChannel;
                    Console.WriteLine($"Programm gewechselt auf: {channel}");
                }
                else
                {
                    Console.WriteLine("Ungültiger Programmplatz.");
                }
            }
        }

        public void GetInfo()
        {
            string zustandText = switchOn ? "an" : "aus";
            Console.WriteLine($"---------------------------");
            Console.WriteLine($"Fernseher {zustandText}");
            Console.WriteLine($"Lautstärke: {volume}");
            Console.WriteLine($"Programm:   {channel}");
            Console.WriteLine($"---------------------------");
        }
    }
}
