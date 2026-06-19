using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        Node tree = new Node(1);
        tree.Left = new Node(2);
        tree.Right = new Node(3);
        tree.Left.Left = new Node(4);
        tree.Left.Right = new Node(5);

        BinaryTreeLevelOrderTraversal(tree);
    }

    private static void BinaryTreeLevelOrderTraversal(Node tree)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(tree);

        while (queue.Count != 0)
        {
            int levelSize = queue.Count;

            for (int i = 0; i < levelSize; i++)
            {
                Node node = queue.Dequeue();
                Console.Write(node.Value + " ");

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }

            Console.WriteLine();
        }
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

// PATTERN — BFS with Queue
// Enqueue root first
// While queue not empty:
//   levelSize = queue.Count (tells you how many nodes on this level)
//   Process exactly levelSize nodes — dequeue, print, enqueue children
//   Console.WriteLine() after each level

// Time Complexity: O(n) — visit every node once
// Space Complexity: O(n) — queue holds at most one full level
