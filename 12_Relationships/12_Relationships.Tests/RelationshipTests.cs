using _12_Relationships.src;
using System.Linq;
using Xunit;

namespace _12_Relationships.Tests
{
    public class RelationshipTests
    {
        [Fact]
        public void Association_CustomerOwnerIsSet()
        {
            var customer = new Customer("John", "Doe");
            var account = new BankAccount(customer, 100);

            // Assoziation: Account kennt den Kunden
            Assert.Same(customer, account.GetOwner());
        }

        [Fact]
        public void Composition_CardIsCreatedWithAccount()
        {
            var customer = new Customer("Jane", "Doe");
            var account = new BankAccount(customer, 500);

            // Komposition: Karte wurde intern erzeugt (nicht null)
            Assert.NotNull(account.AccountCard);
            Assert.StartsWith("CARD-", account.AccountCard.CardNumber);
        }

        [Fact]
        public void Aggregation_TransactionsAreStored()
        {
            var customer = new Customer("Test", "User");
            var account = new BankAccount(customer, 0);
            var logger = new LoggingService();

            // Dependency Injection (Logger) + Aggregation (Transaction)
            account.Deposit(100, logger);

            Assert.Single(account.GetTransactions());
            Assert.Equal(100, account.GetTransactions().First().Amount);
        }
    }
}
