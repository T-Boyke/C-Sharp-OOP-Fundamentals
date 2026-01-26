using AbstractApp.Customers;
using AbstractApp.Interfaces;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 14 Abstract Classes & Interfaces ===");

        // Liste von Kunden (Basisklasse)
        List<Customer> customers = new List<Customer>
        {
            new PrivateCustomer("Max Mustermann"),
            new BusinessCustomer("Anna Chef", "TechCorp GmbH")
        };

        foreach (var c in customers)
        {
            // Nutzung der abstrakten Methode (Polymorphie)
            Console.WriteLine(c.GetCustomerInfo());

            // Nutzung des Interfaces
            if (c is ILogable logger)
            {
                logger.Log("Wurde verarbeitet.");
            }
        }
    }
}
