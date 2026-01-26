using System;

namespace _13_Inheritance.src.Accounts
{
    /// <summary>
    /// Basisklasse für ein Bankkonto.
    /// Verwaltet Guthaben und Konto-ID.
    /// </summary>
    public class BankAccount
    {
        protected decimal _balance;
        protected int _accountId;
        private static int _nextId = 1;

        /// <summary>
        /// Erstellt ein neues Konto mit einem Startguthaben.
        /// </summary>
        /// <param name="initialBalance">Das Startguthaben.</param>
        public BankAccount(decimal initialBalance)
        {
            _balance = initialBalance;
            _accountId = _nextId++;
        }

        /// <summary>
        /// Zahlt einen Betrag auf das Konto ein.
        /// </summary>
        /// <param name="amount">Betrag (> 0).</param>
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Eingezahlt: {amount:C}. Neuer Stand: {_balance:C}");
            }
        }

        /// <summary>
        /// Hebt einen Betrag vom Konto ab, sofern Deckung vorhanden ist.
        /// </summary>
        /// <param name="amount">Betrag (> 0).</param>
        /// <returns>True wenn erfolgreich, sonst False.</returns>
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

        /// <summary>
        /// Liefert den aktuellen Kontostand.
        /// </summary>
        /// <returns>Guthaben.</returns>
        public decimal GetBalance() => _balance;
    }
}
