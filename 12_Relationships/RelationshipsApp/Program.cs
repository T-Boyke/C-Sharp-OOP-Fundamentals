using RelationshipsApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 12 Relationships ===");

        // Customer (Association)
        var customer = new Customer { Name = "Alice" };
        
        // Account init
        var account = new BankAccount(customer);
        Console.WriteLine($"Konto eröffnet für: {account.GetOwnerName()}");
        Console.WriteLine($"Karte erstellt: {account.AccountCard.Number}");

        // Dependency injection
        var logger = new LoggingService();
        account.Deposit(100, logger);
        account.Deposit(50, logger);

        Console.WriteLine($"Final Balance: {account.GetBalance()}");
    }
}
