using System;

namespace _12_Relationships.src
{
    public class Transaction
    {
        public decimal Amount { get; }
        public string Description { get; }
        public DateTime Timestamp { get; }

        public Transaction(decimal amount, string description)
        {
            Amount = amount;
            Description = description;
            Timestamp = DateTime.Now;
        }
    }
}
