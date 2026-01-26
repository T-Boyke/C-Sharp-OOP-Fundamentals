using _13_Inheritance.src.Accounts;
using Xunit;

namespace _13_Inheritance.Tests
{
    public class InheritanceTests
    {
        [Fact]
        public void SavingsAccount_IsABankAccount()
        {
            var savings = new SavingsAccount(100, 0.05m);
            
            // Vererbung prüfen
            Assert.IsAssignableFrom<BankAccount>(savings);
        }

        [Fact]
        public void CheckingAccount_Withdraw_UsesOverdraft()
        {
            // 100 Start, 500 Dispo -> Max Abhebung 600
            var checking = new CheckingAccount(100, 500);
            
            bool success = checking.Withdraw(500); // 100 - 500 = -400 (im Limit)
            
            Assert.True(success);
            Assert.Equal(-400, checking.GetBalance());
        }

        [Fact]
        public void BankAccount_Withdraw_FailsIfInsufficient()
        {
            // Basisklasse hat KEINEN Dispo
            var account = new BankAccount(100);
            
            bool success = account.Withdraw(200);
            
            Assert.False(success);
            Assert.Equal(100, account.GetBalance());
        }

        [Fact]
        public void Polymorphism_CollectionHandling()
        {
            // Array vom Basistyp kann Subtypen speichern
            BankAccount[] accounts = new BankAccount[2];
            accounts[0] = new SavingsAccount(1000, 0.01m);
            accounts[1] = new CheckingAccount(500, 100);

            // Aufruf der gemeinsamen Methode Deposit
            foreach (var acc in accounts)
            {
                acc.Deposit(100);
            }

            Assert.Equal(1100, accounts[0].GetBalance());
            Assert.Equal(600, accounts[1].GetBalance());
        }

        [Fact]
        public void TypeCheck_IsOperator()
        {
            BankAccount acc = new SavingsAccount(100, 0.01m);
            
            // Upcasting (implizit) -> Variable ist BankAccount
            // Prüfung ob es "in Wirklichkeit" ein SavingsAccount ist
            Assert.True(acc is SavingsAccount);
            Assert.False(acc is CheckingAccount);
        }
    }
}
