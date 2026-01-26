using System;

namespace _15_Klausur.src.Observer
{
    public class TableView : IObserver
    {
        private Model _model;

        public TableView(Model model)
        {
            _model = model;
            _model.AddObserver(this); // Task 2b: Self-Registration
        }

        public void Update()
        {
            Display(); // Task 2a: Missing method in UML
        }

        public void Display()
        {
            Console.WriteLine($"TableView updated: {_model.GetData()}");
        }
    }
}
