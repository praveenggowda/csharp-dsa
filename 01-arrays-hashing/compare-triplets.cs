using System;

class Solution
{
    static void Main(string[] args)
    {
        int[] a1 = {5, 6, 7};
        int[] b1 = {3, 6, 10};

        int[] a2 = {17, 28, 30};
        int[] b2 = {99, 16, 8};

        Console.WriteLine(string.Join(", ", CompareTriplets(a1, b1)));  // 1, 1
        Console.WriteLine(string.Join(", ", CompareTriplets(a2, b2)));  // 2, 1
    }

    private static int[] CompareTriplets(int[] a, int[] b)
    {
        int alice = 0;
        int bob = 0;

        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > b[i]) alice++;
            if (a[i] < b[i]) bob++;
        }

        return new int[] {alice, bob};
    }
}

// CLARIFICATIONS
// Positive integers only
// Both arrays always same length
// Equal values → no point for either

// APPROACH — One Pass
// Loop both arrays together by index
// a[i] > b[i] → alice point
// a[i] < b[i] → bob point
// a[i] == b[i] → skip
// Time Complexity: O(n)
// Space Complexity: O(1)
