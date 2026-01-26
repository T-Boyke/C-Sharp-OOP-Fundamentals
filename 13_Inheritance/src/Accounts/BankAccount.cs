using System;

namespace _13_Inheritance.src.Accounts
{
    public class BankAccount
    {
        protected decimal _balance;
        protected int _accountId;
        private static int _nextId = 1;

        public BankAccount(decimal initialBalance)
        {
            _balance = initialBalance;
            _accountId = _nextId++;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Eingezahlt: {amount:C}. Neuer Stand: {_balance:C}");
            }
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount > 0 && _balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Abgehoben: {amount:C}. Neuer Stand: {_balance:C}");
                return true;
            }
            Console.WriteLine("Abhebung abgelehnt.");
            return false;
        }

        public decimal GetBalance() => _balance;
    }
}
