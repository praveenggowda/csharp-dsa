using System;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(StringToInteger("42"));        // 42
        Console.WriteLine(StringToInteger("   -42"));   // -42
        Console.WriteLine(StringToInteger("4193abc"));  // 4193
        Console.WriteLine(StringToInteger("abc"));      // 0
    }

    private static int StringToInteger(string number)
    {
        int result = 0;
        int sign = 1;
        string nums = number.Trim();

        foreach (char c in nums)
        {
            if (c == '+')
                sign = 1;
            else if (c == '-')
                sign = -1;
            else if (char.IsDigit(c))
            {
                if (result > int.MaxValue / 10)
                    return sign == 1 ? int.MaxValue : int.MinValue;

                result = result * 10 + (c - '0');
            }
            else
                break;
        }

        return result * sign;
    }
}

// CLARIFICATIONS
// Can contain leading whitespace — trim first
// Optional + or - sign
// Read digits until non-digit → stop
// Overflow → return int.MaxValue or int.MinValue based on sign

// APPROACH — One Pass
// Trim whitespace
// Check sign character, set sign = 1 or -1
// For each digit: check overflow before multiplying, then result = result * 10 + (c - '0')
// On non-digit: break
// Return result * sign
// Time Complexity: O(n)
// Space Complexity: O(1)
