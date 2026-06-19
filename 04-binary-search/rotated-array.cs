using System;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] input1 = [4, 5, 6, 7, 0, 1, 2];
        int[] input2 = [];

        var output1 = RotatedArray(input1);
        var output2 = RotatedArray(input2);
        
        Console.WriteLine(output1);
        Console.WriteLine(output2);
    }

    private static int RotatedArray(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;

        if (nums == null || nums.Length == 0)
            return -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] > nums[right])
                left = mid + 1;
            else
                right = mid;          
        }

        return nums[left];
    }
}
