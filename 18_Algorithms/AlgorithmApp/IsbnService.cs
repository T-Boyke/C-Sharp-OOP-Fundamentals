using System;

namespace AlgorithmApp
{
    public static class IsbnService
    {
        public static bool ValidateIsbn10(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn)) return false;

            // Bereinigen (Bindestriche raus)
            string clean = isbn.Replace("-", "").ToUpper();
            
            if (clean.Length != 10) return false;

            int sum = 0;
            
            for (int i = 0; i < 9; i++)
            {
                if (!char.IsDigit(clean[i])) return false;
                
                // Formel: z1*1 + z2*2 ...
                // Gewichtung i+1
                int digit = clean[i] - '0'; // Char to Int
                sum += digit * (i + 1);
            }

            // Prüfziffer (letztes Zeichen)
            char lastChar = clean[9];
            int checksum;

            if (lastChar == 'X')
            {
                checksum = 10;
            }
            else if (char.IsDigit(lastChar))
            {
                checksum = lastChar - '0';
            }
            else
            {
                return false;
            }

            // Finale Prüfung: Summe MOD 11 muss Checksum sein
            return (sum % 11) == checksum;
        }
    }
}
