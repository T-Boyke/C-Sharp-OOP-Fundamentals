using System;
using System.Collections.Generic;

namespace _12_Relationships.src
{
    public class BankAccount
    {
        // Association (Has-A: Owner)
        private readonly Customer _owner;
        
        // Aggregation (Has-Many: Transactions)
        private readonly List<Transaction> _transactions = new();

        // Composition (Has-A + Ownership: Card)
        public Card AccountCard { get; }

        private decimal _balance;

        public BankAccount(Customer owner, decimal initialBalance)
        {
            _owner = owner;
            _balance = initialBalance;
            
            // Composition: Card is created HERE and lives with the account
            AccountCard = new Card("CARD-" + Guid.NewGuid().ToString().Substring(0, 8));
        }

        public Customer GetOwner() => _owner;

        public decimal GetBalance() => _balance;

        public List<Transaction> GetTransactions() => _transactions;

        // Dependency (Uses-A: Logger)
        public void Deposit(decimal amount, LoggingService logger)
        {
            _balance += amount;
            
            // Create Transaction (Aggregation)
            var trans = new Transaction(amount, "Deposit");
            _transactions.Add(trans);

            // Use Logger (Dependency)
            logger.Log($"Deposited {amount:C}. New Balance: {_balance:C}");
        }
    }
}
