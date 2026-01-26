using System;

namespace _13_Inheritance.src.Accounts
{
    public class SavingsAccount : BankAccount
    {
        private decimal _interestRate;

        public SavingsAccount(decimal initialBalance, decimal interestRate) : base(initialBalance)
        {
            _interestRate = interestRate;
        }

        public void ApplyInterest()
        {
            decimal interest = _balance * _interestRate;
            Deposit(interest);
            Console.WriteLine($"Zinsen gutgeschrieben: {interest:C}");
        }

        public decimal GetInterestRate() => _interestRate;
    }
}
