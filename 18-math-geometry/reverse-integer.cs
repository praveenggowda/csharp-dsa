using System;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(ReverseInteger(123));   // 321
        Console.WriteLine(ReverseInteger(-123));  // -321
        Console.WriteLine(ReverseInteger(120));   // 21
        Console.WriteLine(ReverseInteger(0));     // 0
    }

    private static int ReverseInteger(int number)
    {
        int result = 0;

        while (number != 0)
        {
            int lastDigit = number % 10;

            if (result > int.MaxValue / 10 || result < int.MinValue / 10)
                return 0;

            result = result * 10 + lastDigit;
            number = number / 10;
        }

        return result;
    }
}

// CLARIFICATIONS
// Positive and negative integers allowed
// Negative sign stays at the beginning
// Trailing zeros dropped (120 → 21)
// Return 0 if reversed number overflows 32-bit int

// BRUTE FORCE
// Convert to string, reverse characters, convert back — O(n) time, O(n) space

// OPTIMISED — Math
// Peel last digit with % 10
// Build result with result * 10 + lastDigit
// Check overflow BEFORE multiplying: result > int.MaxValue / 10
// C# int is fixed 32-bit — overflow check must be inside the loop
// Time Complexity: O(log n) — number of digits
// Space Complexity: O(1)
