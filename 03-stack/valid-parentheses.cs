using System;
using System.Collections;

class Solution
{
    static void Main(string[] args)
    {
        bool input1 = IsValidParenthes("()");
        bool input2 = IsValidParenthes("()[]{}");
        bool input3 = IsValidParenthes("(]");
        bool input4 = IsValidParenthes("([)]");
        bool input5 = IsValidParenthes("{[]}");
        bool input6 = IsValidParenthes("");

        Console.WriteLine(input1);
        Console.WriteLine(input2);
        Console.WriteLine(input3);
        Console.WriteLine(input4);
        Console.WriteLine(input5);
        Console.WriteLine(input6);
    }

    public static bool IsValidParenthes(string parenthese)
    {
        Stack<char> stack = new();

        foreach (var c in parenthese)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                    return false;

                if (c == ')' && stack.Peek() == '(' ||
                    c == ']' && stack.Peek() == '[' ||
                    c == '}' && stack.Peek() == '{')
                {
                    stack.Pop();
                }
                else
                    return false;
            }
        }

        return stack.Count == 0;
    }
}

// INPUTS
// Input:  "()"       → true
// Input:  "()[]{}"   → true
// Input:  "(]"       → false
// Input:  "([)]"     → false
// Input:  "{[]}"     → true
// Input:  ""         → true (empty = valid — no unmatched brackets)

// CLARIFICATIONS
// Only brackets in the input — no alphanumerics
// Returns boolean
// Empty string → true (vacuously valid — mention assumption to interviewer)

// APPROACH
// Stack — push open brackets, match and pop on close brackets
// If stack is empty when a close bracket arrives → false
// If close bracket does not match stack top → false
// If stack is empty at the end → true

// Time Complexity: O(n)
// Space Complexity: O(n) — stack can hold up to n/2 open brackets
