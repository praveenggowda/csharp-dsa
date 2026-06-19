using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        var input = new List<string> {"eat", "tea", "tan", "ate", "nat", "bat"};

        foreach (var group in GroupAnagram(input))
            Console.WriteLine($"[{string.Join(", ", group)}]");
    }

    private static List<string[]> GroupAnagram(List<string> anagrams)
    {
        Dictionary<string, List<string>> groupedAnagrams = new Dictionary<string, List<string>>();

        foreach (var word in anagrams)
        {
            string sortedWord = new string(word.OrderBy(c => c).ToArray());

            if (!groupedAnagrams.ContainsKey(sortedWord))
                groupedAnagrams[sortedWord] = [];

            groupedAnagrams[sortedWord].Add(word);
        }

        return groupedAnagrams.Values.Select(g => g.ToArray()).ToList();
    }
}

// CLARIFICATIONS
// Lowercase letters only
// Empty list → empty result

// BRUTE FORCE
// Compare every word against every other word with isAnagram check — O(n² × m)

// OPTIMISED — HashMap with sorted key
// Sort each word alphabetically → same sorted key for all anagrams
// Group words under their sorted key in a Dictionary
// Return dictionary values
// Time Complexity: O(n × m log m) — n words, each sorted in m log m
// Space Complexity: O(n)
