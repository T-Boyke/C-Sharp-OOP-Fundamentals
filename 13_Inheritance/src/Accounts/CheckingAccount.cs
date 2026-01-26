using System;

namespace _13_Inheritance.src.Accounts
{
    public class CheckingAccount : BankAccount
    {
        private decimal _overdraftLimit;

        public CheckingAccount(decimal initialBalance, decimal overdraftLimit) : base(initialBalance)
        {
            _overdraftLimit = overdraftLimit;
        }

        public override bool Withdraw(decimal amount)
        {
            // Logic: Balance can go down to -_overdraftLimit
            if (amount > 0 && (_balance + _overdraftLimit) >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Abgehoben (Giro): {amount:C}. Neuer Stand: {_balance:C}");
                return true;
            }
            Console.WriteLine("Abhebung (Giro) abgelehnt: Limit überschritten.");
            return false;
        }
    }
}
