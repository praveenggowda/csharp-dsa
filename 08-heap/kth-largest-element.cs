using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        Console.WriteLine(KthLargestNumber(new int[] {3, 1, 5, 2, 4}, 2));  // 4
        Console.WriteLine(KthLargestNumber(new int[] {3, 1, 5, 2, 4}, 1));  // 5
        Console.WriteLine(KthLargestNumber(new int[] {3, 1, 5, 2, 4}, 5));  // 1
    }

    private static int KthLargestNumber(int[] nums, int k)
    {
        var heap = new PriorityQueue<int, int>();

        foreach (var num in nums)
        {
            if (heap.Count == k)
            {
                if (num > heap.Peek())
                {
                    heap.Dequeue();
                    heap.Enqueue(num, num);
                }
            }
            else
            {
                heap.Enqueue(num, num);
            }
        }

        return heap.Peek();
    }
}

// PATTERN — Min Heap of size K
// Keep only the K largest elements in the heap
// Min Heap top = smallest of the K largest = Kth largest overall
// If new number beats the top, swap it in

// PriorityQueue<TElement, TPriority>
// TElement = value stored, TPriority = ordering key (lower = out first)
// Here both are the same number

// Time Complexity: O(n log k) — n elements, each heap op is log k
// Space Complexity: O(k) — heap holds at most k elements
