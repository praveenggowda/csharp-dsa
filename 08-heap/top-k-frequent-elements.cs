using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main()
    {
        Console.WriteLine(string.Join(", ", TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2)));  // 1, 2
        Console.WriteLine(string.Join(", ", TopKFrequent(new int[] { 1 }, 1)));                   // 1
        Console.WriteLine(string.Join(", ", TopKFrequent(new int[] { 3,3,3,2,2,1,1,1,1 }, 2))); // 1, 3
    }

    public static int[] TopKFrequent(int[] nums, int k)
    {
        // Step 1: Build frequency map
        Dictionary<int, int> freq = new();

        foreach (int num in nums)
        {
            if (freq.ContainsKey(num))
                freq[num]++;
            else
                freq[num] = 1;
        }

        // Step 2: Min Heap of size K — priority = frequency
        // Lowest frequency sits at top and gets kicked out when heap exceeds K
        PriorityQueue<int, int> heap = new();

        foreach (var kvp in freq)
        {
            heap.Enqueue(kvp.Key, kvp.Value);

            if (heap.Count > k)
                heap.Dequeue();
        }

        // Step 3: Extract K elements (fill in reverse — highest freq to index 0)
        int[] result = new int[k];

        for (int i = k - 1; i >= 0; i--)
            result[i] = heap.Dequeue();

        return result;
    }
}

// PATTERN — HashMap + Min Heap of size K
// Trigger: "top K" or "K most frequent" → Min Heap of size K
// Step 1: count frequencies with Dictionary
// Step 2: Min Heap of size K, priority = frequency
//         enqueue everything, dequeue when over K → lowest frequency kicked out
// Step 3: remaining K elements are the answer

// PriorityQueue<TElement, TPriority>
// TElement = the number, TPriority = its frequency

// Time Complexity: O(n log k)
// Space Complexity: O(n + k)
