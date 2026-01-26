using System.Collections.Generic;

namespace _15_Klausur.src.Observer
{
    public abstract class Model
    {
        private List<IObserver> _observers = new();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

        public abstract void SetData(int id, string data);
        public abstract string GetData();
    }
}
