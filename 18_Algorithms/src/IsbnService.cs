using System;
using System.Linq;

namespace _18_Algorithms.src
{
    public class IsbnService
    {
        public bool ValidateIsbn10(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn)) return false;

            // Remove dashes and spaces
            string cleanIsbn = isbn.Replace("-", "").Replace(" ", "");

            if (cleanIsbn.Length != 10) return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                if (!char.IsDigit(cleanIsbn[i])) return false;
                
                int digit = cleanIsbn[i] - '0'; // Char to Int
                sum += digit * (i + 1);
            }

            // Check digit
            char lastChar = cleanIsbn[9];
            int checkDigit;

            if (lastChar == 'X' || lastChar == 'x')
            {
                checkDigit = 10;
            }
            else if (char.IsDigit(lastChar))
            {
                checkDigit = lastChar - '0';
            }
            else
            {
                return false;
            }

            return (sum % 11) == checkDigit;
        }
    }
}
