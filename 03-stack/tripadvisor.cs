using System;
using System.Collections.Generic;

public class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Your result: " + GetFinalSearchString("ab#c") + " Expected: ac");
        Console.WriteLine("Your result: " + GetFinalSearchString("paris##") + " Expected: par");
        Console.WriteLine("Your result: " + GetFinalSearchString("tour\\#") + " Expected: tour#");
        Console.WriteLine("Your result: " + GetFinalSearchString("tour\\\\") + " Expected: tour\\");
    }

    private static string GetFinalSearchString(string input)
    {
        Stack<char> stack = new();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '#')
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else if (input[i] == '\\')
            {
                // Check if the next character is also a backslash
                if (i + 1 < input.Length && input[i + 1] == '\\')
                {
                    stack.Push('\\'); // Add a single backslash to the stack
                    i++; // Skip the next character since it's part of the escape sequence
                }
                else
                {
                    stack.Push('\\'); // Add the single backslash to the stack
                }
            }
            else
            {
                stack.Push(input[i]);
            }
        }

        // Build the final string from the stack
        char[] result = new char[stack.Count];
        int index = stack.Count - 1;
        while (stack.Count > 0)
        {
            result[index--] = stack.Pop();
        }

        return new string(result);
    }
}
