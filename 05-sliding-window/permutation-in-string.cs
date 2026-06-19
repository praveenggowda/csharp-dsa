using System;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(PermutationInString("ab", "eidbaooo"));  // true
        Console.WriteLine(PermutationInString("ab", "eidboaoo"));  // false
        Console.WriteLine(PermutationInString("adc", "dcda"));     // true
    }

    private static bool PermutationInString(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        int[] s1Count = new int[26];
        foreach (char c in s1)
            s1Count[c - 'a']++;

        int[] windowCount = new int[26];
        for (int i = 0; i < s1.Length; i++)
            windowCount[s2[i] - 'a']++;

        for (int i = 0; i <= s2.Length - s1.Length - 1; i++)
        {
            if (s1Count.SequenceEqual(windowCount))
                return true;

            windowCount[s2[i + s1.Length] - 'a']++;  // add incoming char
            windowCount[s2[i] - 'a']--;               // remove outgoing char
        }

        return s1Count.SequenceEqual(windowCount);
    }
}

// CLARIFICATIONS
// Lowercase English letters only
// Empty s1 → true, empty s2 → false (s1.Length > s2.Length guard handles it)
// Return bool

// BRUTE FORCE
// Generate all permutations of s1, check if any appear in s2
// Time Complexity: O(n! * m) — factorial permutation generation
// Space Complexity: O(n)

// OPTIMISED — Fixed Sliding Window + Character Count
// Build s1Count — character frequency of s1
// Build first windowCount — first window of s2 (size = s1.Length)
// Slide window across s2 — add incoming char, remove outgoing char
// Compare counts at each position using SequenceEqual
// Check last window after loop ends

// Time Complexity: O(n) — one pass through s2
// Space Complexity: O(1) — fixed size arrays of 26
