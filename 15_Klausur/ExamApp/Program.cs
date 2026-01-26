using ExamApp;
using ExamApp.Observer;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== 15 Klausur Lösungen ===");

        // 1. Film
        Console.WriteLine("\n--- Aufgabe 1: Film ---");
        Film f = new Film("Inception", 148, 2010, "Christopher Nolan");
        Console.WriteLine(f.GetInfo());

        // 2. Observer
        Console.WriteLine("\n--- Aufgabe 2: Observer ---");
        PatientModel patient = new PatientModel();
        
        TableView tv1 = new TableView("Station 1 Display");
        TableView tv2 = new TableView("Arzt Tablet");

        patient.Attach(tv1);
        patient.Attach(tv2);

        Console.WriteLine("Ändere Diagnose zu 'Grippe':");
        patient.SetDiagnosis("Grippe");

        Console.WriteLine("\nStation 1 meldet sich ab...");
        patient.Detach(tv1);

        Console.WriteLine("Ändere Diagnose zu 'Gesund':");
        patient.SetDiagnosis("Gesund");
    }
}
