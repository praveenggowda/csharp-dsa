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

        Traverse(tree);         // 1 2 4 5 3
        InvertBinaryTree(tree);
        Traverse(tree);         // 1 3 2 5 4
    }

    private static Node InvertBinaryTree(Node node)
    {
        if (node == null)
            return null;

        InvertBinaryTree(node.Left);
        InvertBinaryTree(node.Right);

        Node temp = node.Left;
        node.Left = node.Right;
        node.Right = temp;

        return node;
    }

    private static void Traverse(Node node)
    {
        if (node == null) return;

        Console.Write(node.Value + " ");
        Traverse(node.Left);
        Traverse(node.Right);
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
// Q1: null → return null
// Q2: recurse left and right first (children get inverted before parent swaps)
// Q3: swap node.Left and node.Right using temp variable
// Children come along when parent swaps — no need to go deepest first

// Time Complexity: O(n) — visit every node once
// Space Complexity: O(h) — recursion stack height
