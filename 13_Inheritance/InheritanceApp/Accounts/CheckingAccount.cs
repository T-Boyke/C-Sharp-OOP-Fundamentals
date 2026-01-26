using System;

namespace InheritanceApp.Accounts
{
    public class CheckingAccount : BankAccount
    {
        private decimal _overdraftLimit;

        public CheckingAccount(int id, decimal initialBalance, decimal overdraftLimit) 
            : base(id, initialBalance)
        {
            _overdraftLimit = overdraftLimit;
        }

        /// <summary>
        /// Überschreibt die Abhebe-Logik für Dispo-Funktionalität.
        /// </summary>
        public override bool Withdraw(decimal amount)
        {
            if (amount <= 0) return false;

            // Berechnung: Verfügbar = Guthaben + Dispo
            decimal available = _balance + _overdraftLimit;

            if (available >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Girokonto {AccountId}: Abgehoben {amount:C}. Neue Balance: {_balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine($"Girokonto {AccountId}: Limit überschritten! ({amount:C} > {available:C})");
                return false;
            }
        }
    }
}
