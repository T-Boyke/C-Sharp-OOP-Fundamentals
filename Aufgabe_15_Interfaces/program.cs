using System;

namespace InterfaceExample
{
    // Der Vertrag: Jede Zahlungsart muss eine Zahlung abwickeln können.
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    // Erste Umsetzung: Kreditkarte
    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            // Logik für Kreditkartenprüfung und Buchung
            Console.WriteLine($"Verarbeite Kreditkartenzahlung in Höhe von {amount:C}.");
        }
    }

    // Zweite Umsetzung: PayPal
    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            // Logik für API-Call zu PayPal
            Console.WriteLine($"Verarbeite PayPal-Zahlung in Höhe von {amount:C}.");
        }
    }

    // Die "Nutzer"-Klasse (High-Level Logik)
    public class CheckoutService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        // Dependency Injection: Wir übergeben den Vertrag, nicht die konkrete Klasse.
        public CheckoutService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void CompleteOrder(decimal total)
        {
            _paymentProcessor.ProcessPayment(total);
        }
    }

    class Program
    {
        static void Main()
        {
            // Hier entscheiden wir uns für eine konkrete Implementierung
            IPaymentProcessor myProcessor = new PayPalProcessor();
            
            CheckoutService checkout = new CheckoutService(myProcessor);
            checkout.CompleteOrder(49.99m);
        }
    }
}
