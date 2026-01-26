using System;

namespace AbstractApp.Customers
{
    public class PrivateCustomer : Customer
    {
        public PrivateCustomer(string name) : base(name) { }

        public override string GetCustomerInfo()
        {
            return $"Privatkunde: {Name}";
        }
    }

    public class BusinessCustomer : Customer
    {
        public string CompanyName { get; set; }

        public BusinessCustomer(string name, string company) : base(name)
        {
            CompanyName = company;
        }

        public override string GetCustomerInfo()
        {
            return $"Firmenkunde: {Name} ({CompanyName})";
        }
    }
}
