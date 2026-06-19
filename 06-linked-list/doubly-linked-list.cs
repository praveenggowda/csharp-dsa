using System;

public class Solution
{
    static void Main(string[] args)
    {
        DoublyLinkedList dll = new DoublyLinkedList();
        Node node10 = new Node(10);
        Node node20 = new Node(20);
        Node node30 = new Node(30);

        dll.InsertAfterHead(node10);
        dll.InsertAfterHead(node20);
        dll.InsertAfterHead(node30);
        dll.Traverse();       // 30 20 10

        dll.Remove(node20);
        dll.Traverse();       // 30 10
    }
}

public class Node
{
    public int Value;
    public Node Prev;
    public Node Next;

    public Node(int value)
    {
        Value = value;
        Prev = null;
        Next = null;
    }
}

public class DoublyLinkedList
{
    public Node Head;
    public Node Tail;

    public DoublyLinkedList()
    {
        Head = new Node(0);
        Tail = new Node(0);
        Head.Next = Tail;
        Tail.Prev = Head;
    }

    public void Remove(Node node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }

    public void InsertAfterHead(Node node)
    {
        node.Next = Head.Next;
        node.Prev = Head;
        Head.Next.Prev = node;
        Head.Next = node;
    }

    public void Traverse()
    {
        Node current = Head.Next;
        while (current != Tail)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }
}

// STRUCTURE
// Dummy Head and Tail — fixed anchors, never hold real data
// Empty list: [Head] ←→ [Tail]
// Real data always lives between Head and Tail

// Remove(node)       — O(1): rewire Prev and Next neighbours around node
// InsertAfterHead    — O(1): wire node between Head and current first node
//   Order matters: update Head.Next LAST to avoid losing reference to old first node
