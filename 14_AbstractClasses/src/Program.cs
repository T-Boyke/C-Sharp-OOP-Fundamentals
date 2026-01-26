using _14_AbstractClasses.src.Customers;
using System;

namespace _14_AbstractClasses.src
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new PrivateCustomer("John Doe");
            Customer c2 = new BusinessCustomer("Max Mustermann", "Musterfirma GmbH");

            Console.WriteLine("--- Polymorphie ---");
            c1.PrintCustomerInfo();
            c2.PrintCustomerInfo();

            Console.WriteLine("\n--- Interface ---");
            c1.Log("Login");
            c2.Log("Logout");
        }
    }
}
