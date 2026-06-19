using System;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(string.Join(", ", ParitySorting(new int[] {1, 2, 3, 4, 5})));  // 2, 4, 1, 3, 5
        Console.WriteLine(string.Join(", ", ParitySorting(new int[] {3, 1, 2, 4})));     // 2, 4, 3, 1
        Console.WriteLine(string.Join(", ", ParitySorting(new int[] {1, 3, 5})));        // 1, 3, 5 (no evens)
    }

    private static int[] ParitySorting(int[] arr)
    {
        int left = 0;

        for (int right = 0; right < arr.Length; right++)
        {
            if (arr[right] % 2 == 0)
            {
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
                left++;
            }
        }

        return arr;
    }
}

// PATTERN — Two Pointers (partition style)
// left pointer tracks next position for even numbers
// right pointer scans every element
// When even found — swap with left position, advance left
// Same pattern as QuickSort partition
// Time Complexity: O(n)
// Space Complexity: O(1)
