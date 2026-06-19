using System;
using System.Collections;

class Solution
{
    static void Main(string[] args)
    {
        string[] input1 = { "2", "1", "+", "3", "*" };
        string[] input2 = { "4", "13", "5", "/", "+" };
        string[] input3 = { "10", "6", "9", "3", "+", "-", "11", "*", "/", "17", "+", "5", "+" };
        string[] input4 = { "5" };

        Console.WriteLine(ReversePolishNotation(input1));
        Console.WriteLine(ReversePolishNotation(input2));
        Console.WriteLine(ReversePolishNotation(input3));
        Console.WriteLine(ReversePolishNotation(input4));
    }

    private static int ReversePolishNotation(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();

        foreach (var token in tokens)
        {
            if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                int b = stack.Pop();
                int a = stack.Pop();

                switch (token)
                {
                    case "+":
                        stack.Push(a + b);
                        break;
                    case "-":
                        stack.Push(a - b);
                        break;
                    case "*":
                        stack.Push(a * b);
                        break;
                    case "/":
                        stack.Push(a / b);
                        break;
                }
            }
            else
            {
                stack.Push(Convert.ToInt32(token));
            }
        }

        return stack.Pop();
    }
}

// Input:  ["2","1","+","3","*"]                              → 9
// Input:  ["4","13","5","/","+"]                             → 6
// Input:  ["10","6","9","3","+","-","11","*","/","17","+","5","+"] → 22

// CLARIFICATIONS
// Operators: +, -, *, / only
// Integers only — no decimals, negatives allowed
// Division truncates toward zero
// Input is always valid RPN — single result on stack at end

// APPROACH
// Stack — push numbers, on operator pop b then a, calculate a op b, push result
// Order matters: pop b first (top), pop a second — calculate a op b not b op a
// Final answer is always stack.Pop() at the end

// Time Complexity: O(n)
// Space Complexity: O(n)
