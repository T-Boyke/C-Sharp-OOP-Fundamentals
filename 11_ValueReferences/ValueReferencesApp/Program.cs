using ValueReferencesApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 11 Value vs References ===");

        // 1. Value Type
        int a = 10;
        Console.WriteLine($"\nOriginal int: {a}");
        MemoryExperiment.ModifyValue(a);
        Console.WriteLine($"Nach 'ModifyValue': {a} (unverändert)");
        MemoryExperiment.ModifyValueRef(ref a);
        Console.WriteLine($"Nach 'ModifyValueRef': {a} (geändert!)");

        // 2. Reference Type Content
        int[] arr = { 100 };
        Console.WriteLine($"\nOriginal Array[0]: {arr[0]}");
        MemoryExperiment.ModifyReferenceContent(arr);
        Console.WriteLine($"Nach 'ModifyReferenceContent': {arr[0]} (geändert!)");

        // 3. Reassign
        Person p = new Person { Name = "Max" };
        Console.WriteLine($"\nOriginal Person: {p.Name}");
        MemoryExperiment.ReassignReference(p);
        Console.WriteLine($"Nach 'ReassignReference': {p.Name} (unverändert)");
        MemoryExperiment.ReassignReferenceRef(ref p);
        Console.WriteLine($"Nach 'ReassignReferenceRef': {p.Name} (geändert!)");
    }
}
