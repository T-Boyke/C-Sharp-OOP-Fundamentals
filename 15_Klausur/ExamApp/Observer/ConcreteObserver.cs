using System;

namespace ExamApp.Observer
{
    public class PatientModel : Model
    {
        private string _latestDiagnosis;

        public void SetDiagnosis(string diagnosis)
        {
            _latestDiagnosis = diagnosis;
            NotifyObservers($"Neue Diagnose: {diagnosis}");
        }
    }

    public class TableView : IObserver
    {
        public string ViewName { get; }

        public TableView(string name)
        {
            ViewName = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"[{ViewName}] hat Update erhalten: {message}");
        }
    }
}
