using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int[] input1 = {1, 2, 3, 1};
        int[] input2 = {1, 2, 3, 4};
        int[] input3 = {};

        Console.WriteLine(IsDuplicate(input1));  // true
        Console.WriteLine(IsDuplicate(input2));  // false
        Console.WriteLine(IsDuplicate(input3));  // false
    }

    private static bool IsDuplicate(int[] nums)
    {
        HashSet<int> seen = [];

        foreach (int num in nums)
        {
            if (seen.Contains(num))
                return true;

            seen.Add(num);
        }

        return false;
    }
}

// CLARIFICATIONS
// Negative numbers allowed
// Return bool
// Empty array → false

// BRUTE FORCE
// Two nested loops — compare every pair — O(n²) time, O(1) space

// OPTIMISED — HashSet
// For each number, check if already in HashSet → return true
// Otherwise add to HashSet and continue
// Time Complexity: O(n)
// Space Complexity: O(n)
