using Xunit;
using RelationshipsApp;
using System.Collections.Generic;

namespace RelationshipsApp.Tests
{
    public class RelationshipTests
    {
        [Fact]
        public void Association_OwnerIsSetCorrectly()
        {
            var c = new Customer { Name = "Bob" };
            var acc = new BankAccount(c);
            Assert.Equal("Bob", acc.GetOwnerName());
        }

        [Fact]
        public void Composition_CardIsCreatedWithAccount()
        {
            var c = new Customer { Name = "Bob" };
            var acc = new BankAccount(c);
            Assert.NotNull(acc.AccountCard);
            Assert.False(string.IsNullOrEmpty(acc.AccountCard.Number));
        }

        [Fact]
        public void Aggregation_BalanceCalculatesCorrectly()
        {
            var c = new Customer { Name = "Bob" };
            var acc = new BankAccount(c);
            var logger = new LoggingService(); // Real logger, prints to console (allowed here for simplicity)

            acc.Deposit(100, logger);
            acc.Deposit(50, logger);

            Assert.Equal(150, acc.GetBalance());
        }
    }
}
