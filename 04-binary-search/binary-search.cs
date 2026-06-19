using System;

class Solution
{
    static void Main(string[] args)
    {
        int[] input1 = {-1, 0, 3, 5, 9, 12};
        int[] input3 = {};

        var output1 = BinarySearch(input1, 9);
        var output2 = BinarySearch(input1, 4);
        var output3 = BinarySearch(input1, 5);
        var output4 = BinarySearch(input3, 0);

        Console.WriteLine(output1);
        Console.WriteLine(output2);
        Console.WriteLine(output3);
        Console.WriteLine(output4);
    }

    private static int BinarySearch(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target)
                return mid;

            if (nums[mid] > target)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return -1;
    }
}

// CLARIFICATION QUESTIONS
// Expected O(log n) time complexity
// Array is always sorted
// Return -1 if empty or target not found
// All numbers are unique

// BRUTE FORCE
// Single loop — O(n) time, O(1) space

// OPTIMISED — Binary Search
// left, right, mid pointers
// mid = (left + right) / 2
// If nums[mid] == target → return mid
// If nums[mid] > target → right = mid - 1
// If nums[mid] < target → left = mid + 1
// while (left <= right) — must be <= to catch single element remaining
// O(log n) time, O(1) space
