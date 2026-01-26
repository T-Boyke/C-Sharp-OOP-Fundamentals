using System;

namespace InheritanceApp.Accounts
{
    /// <summary>
    /// Basisklasse für alle Konten.
    /// </summary>
    public class BankAccount
    {
        // Protected: Sichtbar für Erben, aber nicht von außen.
        protected decimal _balance;
        
        public int AccountId { get; }
        public decimal Balance => _balance;

        public BankAccount(int id, decimal initialBalance = 0)
        {
            AccountId = id;
            _balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0) return;
            _balance += amount;
            Console.WriteLine($"Konto {AccountId}: Eingezahlt {amount:C}. Neue Balance: {_balance:C}");
        }

        /// <summary>
        /// Versucht Geld abzuheben. Kann überschrieben werden.
        /// </summary>
        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0) return false;

            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Konto {AccountId}: Abgehoben {amount:C}. Neue Balance: {_balance:C}");
                return true;
            }
            else
            {
                Console.WriteLine($"Konto {AccountId}: Nicht genug Guthaben für {amount:C}.");
                return false;
            }
        }
    }
}
