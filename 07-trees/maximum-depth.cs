using System;

class Solution
{
    static void Main(string[] args)
    {
        Node tree = new Node(1);
        tree.Left = new Node(2);
        tree.Right = new Node(3);
        tree.Left.Left = new Node(4);
        tree.Left.Right = new Node(5);

        Console.WriteLine(MaxDepth(tree));  // 3
    }

    private static int MaxDepth(Node node)
    {
        if (node == null)
            return 0;

        int leftDepth = MaxDepth(node.Left);
        int rightDepth = MaxDepth(node.Right);

        return 1 + Math.Max(leftDepth, rightDepth);
    }
}

class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

// PATTERN — DFS Recursion
// Three questions:
// Q1: null → return 0 (empty tree has depth 0)
// Q2: recurse on Left and Right children
// Q3: return 1 + Max(leftDepth, rightDepth)

// Time Complexity: O(n) — visit every node once
// Space Complexity: O(h) — recursion stack depth = height of tree
