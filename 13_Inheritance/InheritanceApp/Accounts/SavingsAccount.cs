using System;

namespace InheritanceApp.Accounts
{
    public class SavingsAccount : BankAccount
    {
        private decimal _interestRate; // z.B. 0.03 für 3%

        // Constructor Chaining: Ruft Konstruktor der Basisklasse auf
        public SavingsAccount(int id, decimal initialBalance, decimal interestRate) 
            : base(id, initialBalance)
        {
            _interestRate = interestRate;
        }

        public void ApplyInterest()
        {
            decimal interest = _balance * _interestRate;
            Deposit(interest); // Wiederverwendung der Basis-Logik
            Console.WriteLine($"Zinsen gutgeschrieben: {interest:C}");
        }
    }
}
