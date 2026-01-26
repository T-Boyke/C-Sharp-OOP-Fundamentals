using System;
using AbstractApp.Interfaces;

namespace AbstractApp.Customers
{
    /// <summary>
    /// Abstrakte Basisklasse für Kunden.
    /// Kann selbst nicht instanziiert werden.
    /// </summary>
    public abstract class Customer : ILogable
    {
        public string Name { get; set; }

        public Customer(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Abstrakte Methode: Muss von Subklassen implementiert werden.
        /// </summary>
        public abstract string GetCustomerInfo();

        /// <summary>
        /// Implementierung des Interfaces ILogable.
        /// </summary>
        public void Log(string message)
        {
            Console.WriteLine($"LOG [{Name}]: {message}");
        }
    }
}
