using System;
using System.IO;

namespace FileConsoleApp.Services
{
    /// <summary>
    /// Stellt Dienste für die Verwaltung von Dateien und Verzeichnissen bereit.
    /// Implementiert Methoden zum byte-weisen Vergleich und zur Verzeichnisbereinigung.
    /// </summary>
    public class FileManagementService
    {
        /// <summary>
        /// Vergleicht zwei Dateien byte-weise auf exakte Identität.
        /// </summary>
        /// <param name="path1">Pfad zur ersten Datei.</param>
        /// <param name="path2">Pfad zur zweiten Datei.</param>
        /// <returns>True, wenn Inhalt, Existenz und Größe identisch sind; andernfalls False.</returns>
        public bool AreFilesIdentical(string path1, string path2)
        {
            FileInfo first = new FileInfo(path1);
            FileInfo second = new FileInfo(path2);

            // Vorabprüfung: Existenz und Dateigröße
            if (!first.Exists || !second.Exists) return false;
            if (first.Length != second.Length) return false;

            // Byte-weiser Vergleich mittels Streams
            using (FileStream fs1 = first.OpenRead())
            using (FileStream fs2 = second.OpenRead())
            {
                int byte1, byte2;
                do
                {
                    byte1 = fs1.ReadByte();
                    byte2 = fs2.ReadByte();
                } 
                while (byte1 == byte2 && byte1 != -1);

                return byte1 == byte2;
            }
        }

        /// <summary>
        /// Erstellt ein Verzeichnis, falls es noch nicht existiert.
        /// </summary>
        /// <param name="directoryPath">Der zu erstellende Pfad.</param>
        public void EnsureDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
