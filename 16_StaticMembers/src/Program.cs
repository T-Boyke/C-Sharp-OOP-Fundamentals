using _16_StaticMembers.src;
using System;

namespace _16_StaticMembers.src
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Unit 16: Statische Member ---");
            Console.WriteLine($"Calculator Add(5, 5): {Calculator.Add(5, 5)}");

            Entity e1 = new Entity();
            Entity e2 = new Entity();
            Console.WriteLine($"Entity Count: {Entity.GetCount()} (Erwartet: 2)");
        }
    }
}
