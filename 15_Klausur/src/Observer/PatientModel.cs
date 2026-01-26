namespace _15_Klausur.src.Observer
{
    public class PatientModel : Model
    {
        private string _patientName = "";

        public override void SetData(int id, string data)
        {
            _patientName = data;
            NotifyObservers();
        }

        public override string GetData()
        {
            return _patientName;
        }
    }
}
