using System;

namespace _15_Klausur.src
{
    public class Film
    {
        private int _id;
        private string _titel;
        private string _genre;
        private int _jahr;
        private int _dauer;

        public Film(int id, string titel, string genre, int jahr, int dauer)
        {
            _id = id;
            _titel = titel;
            _genre = genre;
            _jahr = jahr;
            _dauer = dauer;
        }

        public string GetTitel()
        {
            return _titel;
        }

        public void SetTitel(string titel)
        {
            _titel = titel;
        }
    }
}
