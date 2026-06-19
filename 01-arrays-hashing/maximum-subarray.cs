using System;

class Solution
{
    static void Main(string[] args)
    {
        int[] input1 = {-2, 1, -3, 4, -1, 2, 1, -5, 4};
        int[] input2 = {1};
        int[] input3 = {5, 4, -1, 7, 8};

        Console.WriteLine(MaximumSubarray(input1));  // 6
        Console.WriteLine(MaximumSubarray(input2));  // 1
        Console.WriteLine(MaximumSubarray(input3));  // 23
    }

    private static int MaximumSubarray(int[] nums)
    {
        int currentSum = 0;
        int maxSum = int.MinValue;

        foreach (int num in nums)
        {
            currentSum = Math.Max(num, currentSum + num);
            maxSum = Math.Max(currentSum, maxSum);
        }

        return maxSum;
    }
}

// CLARIFICATIONS
// Positive and negative numbers
// Return maximum sum (not length)
// Empty array → 0

// BRUTE FORCE
// Two nested loops — try every subarray — O(n²) time, O(1) space

// OPTIMISED — Kadane's Algorithm
// Initialise currentSum and maxSum to nums[0]
// From index 1: currentSum = Max(num, currentSum + num)
//   → if currentSum goes negative, start fresh from current number
// maxSum = Max(currentSum, maxSum)
// Time Complexity: O(n)
// Space Complexity: O(1)
