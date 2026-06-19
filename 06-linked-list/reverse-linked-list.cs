using System;

class Solution
{
    static void Main(string[] args)
    {
        Node node = new Node(1);
        node.Next = new Node(2);
        node.Next.Next = new Node(3);
        node.Next.Next.Next = new Node(4);
        node.Next.Next.Next.Next = new Node(5);

        Console.WriteLine("Original List:");
        PrintLinkedList(node);

        node = ReverseLinkedList(node);

        Console.WriteLine("\nReversed List:");
        PrintLinkedList(node);
    }

    private static Node ReverseLinkedList(Node head)
    {
        Node prev = null;
        Node current = head;

        while (current != null)
        {
            Node next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    private static void PrintLinkedList(Node node)
    {
        Node current = node;

        while (current != null)
        {
            Console.Write(current.Value);

            if (current.Next != null)
                Console.Write(" -> ");

            current = current.Next;
        }
    }
}

public class Node
{
    public int Value;
    public Node Next;

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}

// PATTERN — Three Pointer Reversal
// prev = null, current = head
// Each step:
//   1. Save next = current.Next
//   2. Flip current.Next = prev
//   3. Move forward: prev = current, current = next
// When current == null, prev is the new head

// Time Complexity: O(n)
// Space Complexity: O(1)
