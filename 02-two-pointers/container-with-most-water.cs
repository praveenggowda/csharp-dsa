using System;

class Solution
{
    static void Main(string[] args)
    {
        int[] input1 = [1, 8, 6, 2, 5, 4, 8, 3, 7];
        int[] input2 = [2, 3, 4, 5, 18, 17, 6];
        int[] input3 = [];

        int output1 = ContainerWithMoreWater(input1);
        int output2 = ContainerWithMoreWater(input2);
        int output3 = ContainerWithMoreWater(input3);

        Console.WriteLine(output1);
        Console.WriteLine(output2);
        Console.WriteLine(output3);
    }

    private static int ContainerWithMoreWater(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int h = Math.Min(height[left], height[right]);
            int width = right - left;
            int area = h * width;

            if (maxArea < area)
                maxArea = area;

            if (height[left] > height[right])
                right--;
            else
                left++;
        }

        return maxArea;
    }
}

// Notes:
// left, right pointers — opposite ends moving inward
// while left < right
// Move the shorter pointer inward each step
// Area = min(height[left], height[right]) * (right - left)
// Track max area throughout
// O(n) time, O(1) space
