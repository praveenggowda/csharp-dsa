using System;
using System.Text;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(FizzBuzz(15));
        Console.WriteLine(FizzBuzz(1));
        Console.WriteLine(FizzBuzz(5));
    }

    private static string FizzBuzz(int size)
    {
        StringBuilder result = new StringBuilder();

        for (int i = 1; i <= size; i++)
        {
            if (i % 5 == 0 && i % 3 == 0)
                result.Append("FizzBuzz, ");
            else if (i % 5 == 0)
                result.Append("Buzz, ");
            else if (i % 3 == 0)
                result.Append("Fizz, ");
            else
                result.Append($"{i}, ");
        }

        return result.ToString().TrimEnd(',', ' ');
    }
}

// APPROACH — One Pass
// Check FizzBuzz (divisible by both) first, then Fizz, then Buzz, then number
// Order matters — FizzBuzz must be checked before individual checks
// TrimEnd to remove trailing comma and space
// Time Complexity: O(n)
// Space Complexity: O(n)
