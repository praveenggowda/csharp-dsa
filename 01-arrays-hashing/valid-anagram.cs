using System;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(IsValidAnagram("anagram", "nagaram"));  // true
        Console.WriteLine(IsValidAnagram("rat", "cat"));      // false
        Console.WriteLine(IsValidAnagram("rat", ""));         // false
        Console.WriteLine(IsValidAnagram("rat", "catcat"));   // false
    }

    private static bool IsValidAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        int[] count = new int[26];

        foreach (char c in s)
            count[c -'a']++;

        foreach (char c in t)
            count[c - 'a']--;

        foreach (int num in count)
        {
            if (num != 0)
                return false;
        }

        return true;
    }
}

// CLARIFICATIONS
// Lowercase letters only
// Return bool
// Different lengths → false immediately

// BRUTE FORCE
// For each char in t, search s — O(n²) time

// OPTIMISED — Character Count Array
// int[26] count array, index using c - 'a'
// Increment for s, decrement for t
// If any count != 0 → not an anagram
// Time Complexity: O(n)
// Space Complexity: O(1) — fixed size array of 26
