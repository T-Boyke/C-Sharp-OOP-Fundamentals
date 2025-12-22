using System;
using System.Collections.Generic;

class Auto
{
    public string Kennzeichen { get; }
    public Auto(string kennzeichen) { Kennzeichen = kennzeichen; }
}

class Parkbox
{
    public Auto GeparktesAuto { get; private set; }

    public bool IstFrei()
    {
        return GeparktesAuto == null;
    }

    public void Einparken(Auto auto)
    {
        if (IstFrei()) GeparktesAuto = auto;
        else Console.WriteLine("Box ist bereits belegt!");
    }

    public Auto Ausparken()
    {
        Auto auto = GeparktesAuto;
        GeparktesAuto = null;
        return auto;
    }
}

class Parkplatz
{
    public List<Parkbox> Boxen { get; } = new List<Parkbox>();

    public Parkplatz(int anzahlBoxen)
    {
        for (int i = 0; i < anzahlBoxen; i++)
        {
            Boxen.Add(new Parkbox());
        }
    }
}

class Program
{
    static void Main()
    {
        // Parkplatz mit 5 Boxen erstellen
        Parkplatz meinParkplatz = new Parkplatz(5);

        // Autos erstellen
        Auto auto1 = new Auto("NE-AB 123");
        Auto auto2 = new Auto("M-XY 987");
        Auto auto3 = new Auto("D-R 32");

        // Parken
        if (meinParkplatz.Boxen[0].IstFrei())
        {
            meinParkplatz.Boxen[0].Einparken(auto1);
            Console.WriteLine($"Auto {auto1.Kennzeichen} geparkt.");
        }

        meinParkplatz.Boxen[1].Einparken(auto2);
        Console.WriteLine($"Auto {auto2.Kennzeichen} geparkt.");

        // Ausparken
        meinParkplatz.Boxen[0].Ausparken();
        Console.WriteLine($"Box 0 ist wieder frei: {meinParkplatz.Boxen[0].IstFrei()}");
    }
}
