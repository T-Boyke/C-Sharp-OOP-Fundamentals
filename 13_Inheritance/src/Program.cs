using _13_Inheritance.src.Accounts;
using System;

namespace _13_Inheritance.src
{
    class Program
    {
        static void Main(string[] args)
        {
            var savings = new SavingsAccount(1000m, 0.02m);
            var checking = new CheckingAccount(500m, 200m);

            Console.WriteLine("--- Vererbung ---");
            savings.ApplyInterest();
            
            checking.Withdraw(600); // 500 - 600 = -100 (OK)
            checking.Withdraw(200); // -100 - 200 = -300 (Fail, Limit 200)
        }
    }
}
