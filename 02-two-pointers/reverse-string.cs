using System;
using System.Text;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(ReverseString("Trainline"));  // enileniarT
        Console.WriteLine(ReverseString("hello"));      // olleh
        Console.WriteLine(ReverseString("a"));          // a
        Console.WriteLine(ReverseString(""));           //
    }

    private static string ReverseString(string input)
    {
        char[] chars = input.ToCharArray();
        int left = 0;
        int right = chars.Length - 1;

        while (left < right)
        {
            char temp = chars[left];
            chars[left] = chars[right];
            chars[right] = temp;
            left++;
            right--;
        }

        return new string(chars);
    }
}

// BRUTE FORCE — my version (StringBuilder, O(n) space)
// var result = new StringBuilder();
// for (var i = input.Length - 1; i >= 0; i--)
//     result.Append(input[i]);
// return result.ToString();

// OPTIMISED — Two Pointers (O(1) space)
// Convert to char[] — strings are immutable in C#
// Swap left and right moving inward until they meet
// Time Complexity: O(n)
// Space Complexity: O(n)
