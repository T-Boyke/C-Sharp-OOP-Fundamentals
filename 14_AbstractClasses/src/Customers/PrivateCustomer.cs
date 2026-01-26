using System;

namespace _14_AbstractClasses.src.Customers
{
    public class PrivateCustomer : Customer
    {
        public PrivateCustomer(string name) : base(name)
        {
        }

        public override void PrintCustomerInfo()
        {
            Console.WriteLine($"Privatkunde: {Name}");
        }
    }
}
