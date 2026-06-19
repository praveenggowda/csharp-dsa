using System;
using System.Collections;

class Solution
{
    static void Main(string[] args)
    {
        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine($"{minStack.GetMin()}"); // returns -3
        minStack.Pop();
        Console.WriteLine($"{minStack.Top()}");    // returns 0
        Console.WriteLine($"{minStack.GetMin()}"); // returns -2
    }
}

public class MinStack
{
    Stack<int> mainStack = new Stack<int>();
    Stack<int> minStack = new Stack<int>();

    public void Push(int item)
    {
        mainStack.Push(item);

        if (minStack.Count == 0)
            minStack.Push(item);
        else
            minStack.Push(Math.Min(item, minStack.Peek()));
    }

    public void Pop()
    {
        mainStack.Pop();
        minStack.Pop();
    }

    public int Top()
    {
        return mainStack.Peek();
    }

    public int GetMin()
    {
        return minStack.Peek();
    }
}

// CLARIFICATION
// Methods needed: Push, Pop, Top, GetMin
// Integers only — no alphanumeric
// Built-in Stack allowed under the hood
// No heap — GetMin must be O(1)

// APPROACH
// Two stacks: mainStack for normal operations, minStack to track running minimum
// Push: push to mainStack, push Math.Min(item, minStack.Peek()) to minStack
// Pop: pop from both stacks simultaneously
// Top: mainStack.Peek()
// GetMin: minStack.Peek() — always O(1)

// KEY INSIGHT
// Single minValue variable fails after Pop — you lose the previous minimum
// Second stack preserves minimum at every level of the stack
// O(1) time for all operations, O(n) space for minStack
