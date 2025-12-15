static void RunBinary()
{
    Console.WriteLine("--- Aufgabe 3: Binärumrechnung (mit byte) ---");

    // Auch das Array kann byte sein (spart Speicher: 8 Bit statt 32 Bit pro Zahl)
    byte[] binaerArray = new byte[8];

    Console.Write("Eingabe Dezimalzahl (0-255): ");

    // byte.TryParse stellt sicher, dass die Zahl zwischen 0 und 255 liegt
    if (byte.TryParse(Console.ReadLine(), out byte dezimal))
    {
        for (int i = 7; i >= 0; i--)
        {
            // Der Modulo-Operator (%) liefert standardmäßig int, daher Cast zu (byte)
            binaerArray[i] = (byte)(dezimal % 2);

            // Division durch 2
            dezimal = (byte)(dezimal / 2);
        }

        Console.Write("Ergebnis Binärzahl: ");
        foreach (byte bit in binaerArray)
        {
            Console.Write(bit);
        }
    }
    else
    {
        Console.WriteLine("Fehler: Ungültige Eingabe (muss 0-255 sein).");
    }
    Console.WriteLine();
}