using System;
using System.IO;
using FileConsoleApp.Services;

namespace FileConsoleApp
{
    /// <summary>
    /// Haupteinstiegspunkt für die Demonstration von Datei- und Stream-Operationen.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Koordiniert die Erstellung von Testdaten und führt Vergleiche durch.
        /// </summary>
        /// <param name="args">Kommandozeilenargumente.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("=== 23_FilesAndStreams Demo ===\n");

            var fileService = new FileManagementService();
            string testDir = "TestData";
            string fileA = Path.Combine(testDir, "fileA.bin");
            string fileB = Path.Combine(testDir, "fileB.bin");

            // Vorbereitung der Testumgebung
            fileService.EnsureDirectoryExists(testDir);

            // Erstellung identischer Testdaten
            byte[] dummyData = { 0x49, 0x48, 0x4B, 0x20, 0x32, 0x30, 0x32, 0x36 }; // "IHK 2026"
            File.WriteAllBytes(fileA, dummyData);
            File.WriteAllBytes(fileB, dummyData);

            // Durchführung des Vergleichs
            bool identical = fileService.AreFilesIdentical(fileA, fileB);
            Console.WriteLine($"Vergleich Ergebnis: {(identical ? "Identisch" : "Unterschiedlich")}");

            Console.WriteLine("\nBeliebige Taste zum Beenden drücken...");
            Console.ReadKey();
        }
    }
}
