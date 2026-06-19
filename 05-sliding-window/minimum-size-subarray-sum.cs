using System;

class Solution
{
    static void Main(string[] args)
    {
        int[] input1 = {2, 3, 1, 2, 4, 3};
        int[] input2 = {1, 4, 4};
        int[] input3 = {1, 1, 1, 1, 1};

        Console.WriteLine(MinSizeSubArray(input1, 7));   // 2
        Console.WriteLine(MinSizeSubArray(input2, 4));   // 1
        Console.WriteLine(MinSizeSubArray(input3, 11));  // 0
    }

    private static int MinSizeSubArray(int[] nums, int target)
    {
        int left = 0;
        int sum = 0;
        int minLength = int.MaxValue;

        for (int right = 0; right < nums.Length; right++)
        {
            sum += nums[right];

            while (sum >= target)
            {
                minLength = Math.Min(minLength, right - left + 1);
                sum -= nums[left];
                left++;
            }
        }

        return minLength == int.MaxValue ? 0 : minLength;
    }
}

// CLARIFICATIONS
// Positive integers only
// Return minimum length of subarray with sum >= target
// Return 0 if no such subarray exists or array is empty

// BRUTE FORCE
// Two nested loops — check every subarray — O(n²) time, O(1) space

// OPTIMISED — Variable Sliding Window
// Grow right: add nums[right] to sum each iteration
// Shrink left: when sum >= target, record length, remove nums[left], left++
// int.MaxValue as initial minLength — return 0 if never updated

// Time Complexity: O(n)
// Space Complexity: O(1)
