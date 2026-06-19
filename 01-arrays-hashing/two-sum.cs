using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int[] input1 = {2, 7, 11, 15};
        int[] input2 = {3, 2, 4};
        int[] input3 = {3, 3};

        Console.WriteLine(string.Join(", ", TwoSum(input1, 9)));   // 0, 1
        Console.WriteLine(string.Join(", ", TwoSum(input2, 6)));   // 1, 2
        Console.WriteLine(string.Join(", ", TwoSum(input3, 6)));   // 0, 1
    }

    private static int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> seen = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];

            if (seen.ContainsKey(complement))
                return [seen[complement], i];

            seen[nums[i]] = i;
        }

        return [];
    }
}

// CLARIFICATIONS
// Negative numbers allowed
// Empty array → return empty array
// Return indices of the two numbers
// Exactly one solution guaranteed (unless no sum found)
// Duplicates possible

// BRUTE FORCE
// Two nested loops — check every pair — O(n²) time, O(1) space

// OPTIMISED — HashMap
// For each number, calculate complement = target - nums[i]
// If complement already seen → return [seen[complement], i]
// Otherwise store nums[i] → i in dictionary
// Time Complexity: O(n)
// Space Complexity: O(n)
