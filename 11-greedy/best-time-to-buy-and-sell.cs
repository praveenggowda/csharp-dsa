using System;

class Solution
{
    static void Main(string[] args)
    {
        int[] input1 = {7, 1, 5, 3, 6, 4};
        int[] input2 = {7, 6, 4, 3, 1};

        Console.WriteLine(BestTimeToBuyAndSell(input1));  // 5
        Console.WriteLine(BestTimeToBuyAndSell(input2));  // 0
    }

    private static int BestTimeToBuyAndSell(int[] prices)
    {
        int minPrice = prices[0];
        int maxProfit = 0;

        foreach (int price in prices)
        {
            minPrice = Math.Min(minPrice, price);
            maxProfit = Math.Max(maxProfit, price - minPrice);
        }

        return maxProfit;
    }
}

// CLARIFICATIONS
// Positive numbers only
// Buy before sell — one transaction only
// Empty array → 0
// Prices only go down → return 0

// BRUTE FORCE
// Two nested loops — try every buy/sell pair — O(n²) time, O(1) space

// OPTIMISED — One Pass
// Track minPrice seen so far
// At each price, calculate profit = price - minPrice
// Track maxProfit seen so far
// Time Complexity: O(n)
// Space Complexity: O(1)
