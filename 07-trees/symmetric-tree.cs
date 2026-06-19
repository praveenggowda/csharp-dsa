using System;

class Solution
{
    static void Main(string[] args)
    {
        Node tree1 = new Node(1);
        tree1.Left = new Node(2);
        tree1.Right = new Node(2);
        tree1.Left.Left = new Node(3);
        tree1.Left.Right = new Node(4);
        tree1.Right.Left = new Node(4);
        tree1.Right.Right = new Node(3);
        Console.WriteLine(IsSymmetric(tree1));  // true

        Node tree2 = new Node(1);
        tree2.Left = new Node(2);
        tree2.Right = new Node(2);
        tree2.Left.Left = new Node(3);
        tree2.Right.Left = new Node(3);
        Console.WriteLine(IsSymmetric(tree2));  // false
    }

    private static bool IsSymmetric(Node root)
    {
        if (root == null) return false;
        return IsMirror(root.Left, root.Right);
    }

    private static bool IsMirror(Node left, Node right)
    {
        if (left == null && right == null) return true;
        if (left == null || right == null) return false;

        return left.Value == right.Value
            && IsMirror(left.Left, right.Right)
            && IsMirror(left.Right, right.Left);
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

// PATTERN — DFS Recursion comparing two nodes simultaneously
// Q1: both null → true (perfect mirror at leaf level)
// Q2: one null → false (one side has node, other does not)
// Q3: values must match AND outer pair mirrors AND inner pair mirrors
//     IsMirror(left.Left, right.Right) — outer
//     IsMirror(left.Right, right.Left) — inner

// Time Complexity: O(n)
// Space Complexity: O(h)
