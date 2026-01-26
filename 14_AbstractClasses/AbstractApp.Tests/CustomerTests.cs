using Xunit;
using AbstractApp.Customers;
using AbstractApp.Interfaces;

namespace AbstractApp.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void PrivateCustomer_ReturnsCorrectInfo()
        {
            Customer c = new PrivateCustomer("Max");
            Assert.Equal("Privatkunde: Max", c.GetCustomerInfo());
        }

        [Fact]
        public void BusinessCustomer_ReturnsCorrectInfo()
        {
            Customer c = new BusinessCustomer("Anna", "Corp");
            Assert.Equal("Firmenkunde: Anna (Corp)", c.GetCustomerInfo());
        }

        [Fact]
        public void Customer_IsILogable()
        {
            Customer c = new PrivateCustomer("LogTest");
            Assert.IsAssignableFrom<ILogable>(c);
        }
    }
}
