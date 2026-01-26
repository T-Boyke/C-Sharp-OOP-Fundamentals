using MethodPlayground;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Method Playground ===");

        // 1. Potenz
        long pow = MathHelper.CalculatePower(2, 10);
        Console.WriteLine($"2^10 = {pow}");

        // 2. Out Params
        int[] nums = { 10, 5, 20, 3, 8 };
        MathHelper.GetStatistics(nums, out int min, out int max);
        Console.WriteLine($"Array Stats: Min={min}, Max={max}");

        // 3. Ref Params
        int a = 1;
        int b = 99;
        Console.WriteLine($"Vor Swap: a={a}, b={b}");
        MathHelper.Swap(ref a, ref b);
        Console.WriteLine($"Nach Swap: a={a}, b={b}");
    }
}
