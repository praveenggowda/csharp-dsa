using System;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(CheckForPalindrome("abca"));    // true
        Console.WriteLine(CheckForPalindrome("abc"));     // false
        Console.WriteLine(CheckForPalindrome("aba"));     // true
        Console.WriteLine(CheckForPalindrome("abcdef"));  // false
    }

    public static bool CheckForPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (s[left] == s[right])
            {
                left++;
                right--;
            }
            else
            {
                return IsPalindrome(s, left + 1, right) || IsPalindrome(s, left, right - 1);
            }
        }

        return true;
    }

    private static bool IsPalindrome(string s, int left, int right)
    {
        while (left < right)
        {
            if (s[left] == s[right])
            {
                left++;
                right--;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}

// PATTERN — Two Pointers + Helper
// Walk inward from both ends
// First mismatch → one removal allowed → try skip left OR skip right
// Helper checks if substring between left and right is a palindrome
// Return immediately after first mismatch — only one removal allowed

// Time Complexity: O(n)
// Space Complexity: O(1)
