namespace _16_StaticMembers.src
{
    // 1. Static Class
    public static class Calculator
    {
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b)
        {
            if (b == 0) return 0; // Simple handling
            return a / b;
        }
    }

    // 2. Class with Static Field
    public class Entity
    {
        // Static field: shared by all instances
        private static int _instanceCount = 0;

        public int Id { get; }

        public Entity()
        {
            _instanceCount++;
            Id = _instanceCount;
        }

        public static int GetCount()
        {
            return _instanceCount;
        }
        
        public static void ResetCount() // Helper for tests
        {
            _instanceCount = 0;
        }
    }
}
