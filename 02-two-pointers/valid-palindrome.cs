using System;

class Solution
{
    static void Main(string[] args)
    {
        bool output1 = IsValidPalindrome("A man, a plan, a canal: Panama");
        bool output2 = IsValidPalindrome("race a car");
        bool output3 = IsValidPalindrome("       ");

        Console.WriteLine(output1);
        Console.WriteLine(output2);
        Console.WriteLine(output3);
    }

    private static bool IsValidPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (!char.IsLetterOrDigit(s[left]))
                left++;
            else if (!char.IsLetterOrDigit(s[right]))
                right--;
            else if (char.ToLower(s[left]) != char.ToLower(s[right]))
                return false;
            else
            {
                left++;
                right--;
            }
        }

        return true;
    }
}
