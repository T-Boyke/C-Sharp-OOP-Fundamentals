using System;

namespace RelationshipsApp
{
    // Association: Customer exists alone
    public class Customer
    {
        public string Name { get; set; } = "";
    }

    // Composition: Card belongs to BankAccount (conceptual)
    public class Card
    {
        public string Number { get; set; } = "";
    }

    // Dependency: Service used temporarily
    public class LoggingService
    {
        public virtual void Log(string message)
        {
            Console.WriteLine($"LOG: {message}");
        }
    }

    // Aggregation: Transaction is part of the account history
    public record Transaction(decimal Amount, DateTime Date);
}
