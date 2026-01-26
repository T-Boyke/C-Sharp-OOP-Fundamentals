using System;

namespace ExamApp
{
    public class Film
    {
        private string _title;
        private int _duration;
        private int _year;
        private string _director;

        public Film(string title, int duration, int year, string director)
        {
            _title = title;
            _duration = duration;
            _year = year;
            _director = director;
        }

        public string GetInfo()
        {
            return $"Film: {_title} ({_year}), {_duration} Min, Regie: {_director}";
        }
    }
}
