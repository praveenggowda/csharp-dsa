using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        LRUCache cache = new LRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        Console.WriteLine(cache.Get(1));  // 1  — moves 1 to front
        cache.Put(3, 3);                  // evicts 2 (LRU)
        Console.WriteLine(cache.Get(2));  // -1 — evicted
        Console.WriteLine(cache.Get(3));  // 3
    }
}

public class Node
{
    public Node Prev;
    public int Key;
    public int Value;
    public Node Next;

    public Node(int key, int value)
    {
        Key = key;
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
        Head = new Node(0, 0);
        Tail = new Node(0, 0);
        Head.Next = Tail;
        Tail.Prev = Head;
    }

    public void InsertAfterHead(Node node)
    {
        node.Next = Head.Next;
        node.Prev = Head;
        Head.Next.Prev = node;
        Head.Next = node;
    }

    public void Remove(Node node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
}

public class LRUCache
{
    private int _capacity;
    private Dictionary<int, Node> _cache;
    private DoublyLinkedList _dll;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, Node>();
        _dll = new DoublyLinkedList();
    }

    public int Get(int key)
    {
        if (_cache.TryGetValue(key, out Node node))
        {
            _dll.Remove(node);
            _dll.InsertAfterHead(node);
            return node.Value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out Node node))
        {
            _dll.Remove(node);
            node.Value = value;
            _dll.InsertAfterHead(node);
        }
        else
        {
            Node newNode = new Node(key, value);
            _dll.InsertAfterHead(newNode);
            _cache.Add(newNode.Key, newNode);

            if (_cache.Count > _capacity)
            {
                Node lru = _dll.Tail.Prev;
                _dll.Remove(lru);
                _cache.Remove(lru.Key);
            }
        }
    }
}

// STRUCTURE
// HashMap: key → Node  (O(1) lookup)
// DLL: most recent after Head, least recent before Tail
// Dummy Head and Tail — no null checks needed

// Get(key)
//   → not in cache → return -1
//   → found → Remove from DLL, InsertAfterHead, return value

// Put(key, value)
//   → key exists → update value, Remove, InsertAfterHead
//   → key new → create node, InsertAfterHead, add to cache
//              → if over capacity: evict Tail.Prev from DLL and cache

// Time Complexity: O(1) for both Get and Put
// Space Complexity: O(n)
