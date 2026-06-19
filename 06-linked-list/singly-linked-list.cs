using System;

class Node
{
    public int Value;
    public Node Next;

    public Node(int value)
    {
        Value = value;
        Next = null;
    }
}

class SinglyLinkedList
{
    public Node Head;

    public void InsertAtHead(int value)
    {
        Node node = new Node(value);
        node.Next = Head;
        Head = node;
    }

    public void InsertAtTail(int value)
    {
        Node node = new Node(value);

        if (Head == null)
        {
            Head = node;
            return;
        }

        Node current = Head;
        while (current.Next != null)
            current = current.Next;

        current.Next = node;
    }

    public void Traverse()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    public void Delete(int value)
    {
        if (Head == null) return;

        if (Head.Value == value)
        {
            Head = Head.Next;
            return;
        }

        Node prev = null;
        Node current = Head;

        while (current != null)
        {
            if (current.Value == value)
            {
                prev.Next = current.Next;
                return;
            }
            prev = current;
            current = current.Next;
        }
    }

    public bool Search(int value)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Value == value)
                return true;
            current = current.Next;
        }
        return false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SinglyLinkedList list = new SinglyLinkedList();

        list.InsertAtTail(1);
        list.InsertAtTail(2);
        list.InsertAtTail(3);
        list.Traverse();  // 1 2 3

        list.InsertAtTail(4);
        list.Traverse();  // 1 2 3 4

        list.InsertAtHead(0);
        list.Traverse();  // 0 1 2 3 4

        list.Delete(2);
        list.Traverse();  // 0 1 3 4

        Console.WriteLine(list.Search(3));  // True
        Console.WriteLine(list.Search(9));  // False
    }
}

// STRUCTURE
// Node class: Value + Next pointer
// SinglyLinkedList class: Head pointer, all operations live here

// InsertAtHead  — O(1): point new node to Head, update Head
// InsertAtTail  — O(n): traverse to end, attach new node
// Traverse      — O(n): while (current != null), not current.Next
// Delete        — O(n): prev pointer tracks one step behind current
// Search        — O(n): traverse and compare each value
