using System;

namespace _14_AbstractClasses.src.Customers
{
    public class BusinessCustomer : Customer
    {
        public string CompanyName { get; }

        public BusinessCustomer(string name, string companyName) : base(name)
        {
            CompanyName = companyName;
        }

        public override void PrintCustomerInfo()
        {
            Console.WriteLine($"Geschäftskunde: {Name} (Firma: {CompanyName})");
        }
    }
}
