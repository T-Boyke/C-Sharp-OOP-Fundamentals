using _14_AbstractClasses.src.Customers;
using _14_AbstractClasses.src.Interfaces;
using Xunit;

namespace _14_AbstractClasses.Tests
{
    public class PolymorphismTests
    {
        [Fact]
        public void PrivateCustomer_IsACustomer()
        {
            var customer = new PrivateCustomer("John");
            Assert.IsAssignableFrom<Customer>(customer);
        }

        [Fact]
        public void BusinessCustomer_IsACustomer()
        {
            var customer = new BusinessCustomer("Max", "TechCorp");
            Assert.IsAssignableFrom<Customer>(customer);
        }

        [Fact]
        public void Polymorphism_CollectionHandling()
        {
            Customer[] customers = new Customer[2];
            customers[0] = new PrivateCustomer("John");
            customers[1] = new BusinessCustomer("Max", "Corp");

            // Wir können PrintCustomerInfo aufrufen, obwohl der Typ "Customer" ist.
            // Es wird die jeweilige Implementierung ausgeführt (kann man im Unit Test schlecht asserten ohne IConsoleWrapper, 
            // aber dass es kompiliert und läuft beweist Polymorphie).
            foreach (var c in customers)
            {
                c.PrintCustomerInfo();
                // Wenn dies nicht abstrakt wäre und nicht überschrieben, würde immer die Basis-Methode laufen.
            }
        }

        [Fact]
        public void Interface_Implementation()
        {
            ILogable logable = new PrivateCustomer("Jane");
            // Kann Log aufrufen
            logable.Log("Test");
            
            Assert.IsAssignableFrom<ILogable>(logable);
        }
    }
}
