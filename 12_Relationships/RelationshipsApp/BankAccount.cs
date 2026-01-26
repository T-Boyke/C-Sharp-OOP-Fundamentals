using System;
using System.Collections.Generic;
using System.Linq;

namespace RelationshipsApp
{
    public class BankAccount
    {
        // 2. Association (Hat ein)
        private readonly Customer _owner;

        // 3. Aggregation (Besteht aus Teilen)
        private readonly List<Transaction> _transactions = new();

        // 4. Composition (Existenzabhängig)
        public Card AccountCard { get; private set; }

        public BankAccount(Customer owner)
        {
            _owner = owner ?? throw new ArgumentNullException(nameof(owner));
            
            // Composition: Wir erstellen die Karte HIER. Sie gehört uns.
            AccountCard = new Card { Number = Guid.NewGuid().ToString().Substring(0, 8) };
        }

        // 1. Dependency (Benutzt)
        public void Deposit(decimal amount, LoggingService logger)
        {
            if (amount <= 0) return;

            // Aggregation: Neue Transaktion hinzufügen
            _transactions.Add(new Transaction(amount, DateTime.Now));

            // Dependency: Logger nutzen
            logger?.Log($"Deposited {amount} for {_owner.Name}");
        }

        public decimal GetBalance()
        {
            return _transactions.Sum(t => t.Amount);
        }

        public string GetOwnerName() => _owner.Name;
    }
}
