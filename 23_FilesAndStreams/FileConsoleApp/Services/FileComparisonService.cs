using System;
using System.IO;

namespace FileConsoleApp.Services
{
    /// <summary>
    /// Service zur Durchführung von Datei-Vergleichen und Validierungen.
    /// </summary>
    public class FileComparisonService
    {
        /// <summary>
        /// Vergleicht zwei Dateien byte-weise auf Identität.
        /// </summary>
        /// <param name="path1">Pfad zur ersten Datei.</param>
        /// <param name="path2">Pfad zur zweiten Datei.</param>
        /// <returns>True, wenn die Dateien exakt identisch sind, andernfalls False.</returns>
        public bool AreFilesIdentical(string path1, string path2)
        {
            FileInfo first = new FileInfo(path1);
            FileInfo second = new FileInfo(path2);

            // Vorab-Check: Existenz und Größe
            if (!first.Exists || !second.Exists) return false;
            if (first.Length != second.Length) return false;

            // Byte-weiser Vergleich über FileStreams
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
    }
}
