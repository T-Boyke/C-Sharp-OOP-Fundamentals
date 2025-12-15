using System;

namespace Aufgabe_3_Konstruktoren
{
    // Definition der Enums für Farbe und Größe
    public enum EColor
    {
        White,
        Red,
        Blue,
        Green,
        Black
    }

    public enum ESize
    {
        S,
        M,
        L,
        XL,
        XXL
    }

    // a) Erstellen Sie ein UML-Klassendiagramm für die Klasse Sweatshirt.
    // Update: Hier verwenden wir nun Enums statt Strings für bessere Typsicherheit.

//classDiagram
//  class EColor
//  {
//  <<enumeration>>
//  Red
//  Blue
//  Green
//  Black
//  White
//}

//  class ESize
//  {
//  <<enumeration>>
//  S
//  M
//  L
//  XL
//  XXL
//}

//  class Sweatshirt
//  {
//  -EColor _color
//  -ESize _size
//  -bool _isDry
//
//  +Sweatshirt()
//  +Sweatshirt(EColor color)
//  +Sweatshirt(EColor color, ESize size)
//  +IsDry() bool
//  +Dry() void
//  +Wash() void
//  +PrintInfos() void
//}

//Sweatshirt..> EColor
//Sweatshirt..> ESize

    // b) Erstellen Sie die Klasse in C#. 
    public class Sweatshirt
    {
        // Attribute mit Enums
        private EColor _color;
        private ESize _size;
        private bool _isDry;

        // d) Erstellen Sie mehrere Konstruktoren, um Farbe, Größe oder beides variabel angeben zu können.

        // Standard-Konstruktor
        public Sweatshirt()
        {
            _color = EColor.White;
            _size = ESize.M;
            _isDry = true;
        }

        // Konstruktor nur mit Farbe
        public Sweatshirt(EColor color)
        {
            _color = color;
            _size = ESize.M; // Standardgröße
            _isDry = true;
        }

        // c) Erstellen Sie einen Konstruktor, der es erlaubt, Farbe und Größe bei der Erzeugung festzulegen.
        public Sweatshirt(EColor color, ESize size)
        {
            _color = color;
            _size = size;
            _isDry = true;
        }

        // Methoden

        // Gibt zurück, ob das Sweatshirt trocken ist
        public bool IsDry()
        {
            return _isDry;
        }

        // Trocknet das Sweatshirt
        public void Dry()
        {
            Console.WriteLine("Das Sweatshirt wird getrocknet...");
            _isDry = true;
        }

        // Wäscht das Sweatshirt
        public void Wash()
        {
            Console.WriteLine("Das Sweatshirt wird gewaschen...");
            _isDry = false;
        }

        // Gibt eine Meldung über die Details des Sweatshirts auf der Konsole aus
        public void PrintInfos()
        {
            string zustand = _isDry ? "trocken" : "nass";
            // Enums werden beim String-Interpolation automatisch in ihren Text-Namen umgewandelt (z.B. "Blue")
            Console.WriteLine($"Das Sweatshirt in der Farbe {_color} hat die Größe {_size} und ist {zustand}.");
        }
    }

    class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Test 1: Voller Konstruktor mit Enums ---");
            // Erzeugen Sie anschließend in der Main()-Methode mindestens ein Sweatshirt-Objekt 
            // und testen Sie alle Funktionalitäten.

            // Instanziierung nun mit Enum-Werten statt Strings
            Sweatshirt meinShirt = new Sweatshirt(EColor.Blue, ESize.L);

            meinShirt.PrintInfos();

            // Testen: Waschen
            meinShirt.Wash();
            meinShirt.PrintInfos();

            // Testen: Trocknen
            meinShirt.Dry();
            meinShirt.PrintInfos();

            Console.WriteLine("\n--- Test 2: Konstruktor nur mit Farbe ---");
            Sweatshirt rotesShirt = new Sweatshirt(EColor.Red);
            rotesShirt.PrintInfos();

            Console.ReadKey();
        }
    }
}