using Xunit;
using InheritanceApp.Accounts;

namespace InheritanceApp.Tests
{
    public class AccountTests
    {
        [Fact]
        public void BankAccount_StandardWithdraw_FailsIfNotEnoughMoney()
        {
            var acc = new BankAccount(1, 50);
            bool success = acc.Withdraw(100);
            
            Assert.False(success);
            Assert.Equal(50, acc.Balance);
        }

        [Fact]
        public void SavingsAccount_ApplyInterest_IncreasesBalance()
        {
            var saver = new SavingsAccount(1, 100, 0.10m); // 10%
            saver.ApplyInterest();

            // 100 + 10 = 110
            Assert.Equal(110, saver.Balance);
        }

        [Fact]
        public void CheckingAccount_Withdraw_UsesOverdraft()
        {
            var grid = new CheckingAccount(1, 10, 100); // 10 Guthaben, 100 Dispo = 110 Max
            
            // Abheben von 50 (mehr als Guthaben, aber im Dispo)
            bool success = grid.Withdraw(50);
            
            Assert.True(success);
            Assert.Equal(-40, grid.Balance); // 10 - 50 = -40
        }

        [Fact]
        public void CheckingAccount_Withdraw_FailsIfLimitExceeded()
        {
            var grid = new CheckingAccount(1, 0, 100);
            bool success = grid.Withdraw(101); // Zu viel
            
            Assert.False(success);
            Assert.Equal(0, grid.Balance);
        }
    }
}
