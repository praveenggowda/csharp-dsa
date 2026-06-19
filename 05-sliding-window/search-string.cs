using System;

class Solution
{
    static void Main(string[] args)
    {
        bool output1 = SearchString("hello", "ll");
        bool output2 = SearchString("hello", "world");
        bool output3 = SearchString("hello", "hello");
        bool output4 = SearchString("", "ll");
        bool output5 = SearchString("", "          ");

        Console.WriteLine(output1);
        Console.WriteLine(output2);
        Console.WriteLine(output3);
        Console.WriteLine(output4);
        Console.WriteLine(output5);
    }

    private static bool SearchString(string text, string pattern)
    {
        for (int i = 0; i <= text.Length - pattern.Length; i++)
        {
            string window = text.Substring(i, pattern.Length);

            if (window == pattern)
                return true;
        }

        return false;
    }
}

// CLARIFICATIONS
// Any characters allowed — numbers, words, sentences
// Return bool
// Empty text → false (loop never runs)

// APPROACH — Fixed Sliding Window
// Window size = pattern.Length
// Slide window one step at a time across text
// Compare window substring with pattern
// Return true on first match, false if no match found

// Time Complexity: O(n * m) — n positions, m chars compared each time
// Space Complexity: O(1)
