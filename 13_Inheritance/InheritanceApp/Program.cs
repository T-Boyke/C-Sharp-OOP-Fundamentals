using InheritanceApp.Accounts;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 13 Inheritance ===");

        // Polymorphismus: Liste vom Typ der Basisklasse
        List<BankAccount> accounts = new List<BankAccount>
        {
            new BankAccount(101, 100),            // Standard
            new SavingsAccount(202, 1000, 0.05m), // Sparbuch (5%)
            new CheckingAccount(303, 50, 200)     // Giro (200 Dispo)
        };

        foreach (var acc in accounts)
        {
            Console.WriteLine($"\n--- Konto {acc.AccountId} ---");
            
            // Typ-Prüfung und Casting
            if (acc is SavingsAccount saver)
            {
                Console.WriteLine("-> Das ist ein Sparbuch.");
                saver.ApplyInterest();
            }
            else if (acc is CheckingAccount checker)
            {
                Console.WriteLine("-> Das ist ein Girokonto.");
            }

            // Normales Verhalten (Polymorph bei Withdraw)
            acc.Withdraw(150);
        }
    }
}
