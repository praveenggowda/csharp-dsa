using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int[] input = {-1, 0, 1, 2, -1, -4};
        var output = ThreeSum(input);
        foreach (var triplet in output)
        {
            Console.WriteLine($"[{string.Join(", ", triplet)}]");
        }
    }

    private static List<List<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var triplets = new List<List<int>>();
        int left = 0;
        int right = 0;

        for (int i = 0; i <= nums.Length - 1; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            left = i + 1;
            right = nums.Length - 1;

            while (left < right)
            {
                int total = nums[i] + nums[left] + nums[right];

                if (total == 0)
                {
                    triplets.Add(new List<int>() {
                        nums[i], nums[left], nums[right]
                    });

                    while (left < right && nums[left] == nums[left + 1])
                        left++;

                    while (left < right && nums[right] == nums[right - 1])
                        right--;

                    left++;
                    right--;
                }
                else if (total < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return triplets;
    }
}

// Input:  [-1, 0, 1, 2, -1, -4]
// Output: [[-1, -1, 2], [-1, 0, 1]]

// CLARIFICATION QUESTIONS
// 1. Return empty array if the input is empty
// 2. Can have both +ve and -ve numbers
// 3. If fewer than 3 elements, return empty array
// 4. Zero is valid — [0, 0, 0] is a valid triplet

// BRUTE FORCE
// 3 nested loops — O(n³) time, O(n) space for output

// OPTIMISED — Two Pointer
// Sort the array first — enables left/right pointer decisions
// Fix i in outer loop, use two pointers for the remaining pair
// Skip duplicates on i with i > 0 guard
// Skip duplicates on left and right after finding a valid triplet
// O(n²) time, O(1) auxiliary space
