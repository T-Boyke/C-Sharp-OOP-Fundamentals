using System;

namespace _12_Relationships.src
{
    class Program
    {
        static void Main(string[] args)
        {
            var owner = new Customer("John", "Doe");
            var account = new BankAccount(owner, 1000m);
            var logger = new LoggingService();

            Console.WriteLine($"Konto eröffnet für: {account.GetOwner().LastName}");
            account.Deposit(500, logger);
            
            Console.WriteLine($"Karte: {account.AccountCard.CardNumber}");
        }
    }
}
