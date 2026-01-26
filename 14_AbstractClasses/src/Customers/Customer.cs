using _14_AbstractClasses.src.Interfaces;
using System;

namespace _14_AbstractClasses.src.Customers
{
    // Abstract Class: Cannot be instantiated
    public abstract class Customer : ILogable
    {
        public string Name { get; }

        protected Customer(string name)
        {
            Name = name;
        }

        // Abstract Method: Must be implemented by derived classes
        public abstract void PrintCustomerInfo();

        // Interface Implementation
        public void Log(string message)
        {
            Console.WriteLine($"[LOG - {Name}]: {message}");
        }
    }
}
