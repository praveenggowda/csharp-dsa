using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(LongestSubstring("abcabcbb")); // 3
        Console.WriteLine(LongestSubstring("bbbbb"));    // 1
        Console.WriteLine(LongestSubstring("pwwkew"));   // 3
        Console.WriteLine(LongestSubstring(""));         // 0
    }

    private static int LongestSubstring(string text)
    {
        int left = 0;
        int maxLength = 0;
        var seen = new Dictionary<char, int>();

        for (int right = 0; right < text.Length; right++)
        {
            char c = text[right];

            if (seen.ContainsKey(c) && seen[c] >= left)
                left = seen[c] + 1;

            seen[c] = right;

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}

// CLARIFICATIONS
// Any characters allowed
// Return length of longest substring without repeating characters
// Empty string → 0

// APPROACH — Variable Sliding Window + HashMap
// seen stores char → last seen index
// If duplicate found AND it is inside current window (seen[c] >= left)
//   → jump left to seen[c] + 1
// Always update seen[c] = right
// Track max window size with Math.Max

// Time Complexity: O(n)
// Space Complexity: O(n) — seen dictionary grows with unique chars
