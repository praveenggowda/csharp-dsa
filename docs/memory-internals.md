# Memory Internals — Stack, Heap, and RAM

## The Two Memory Regions

```
┌─────────────────┐     ┌──────────────────────────────┐
│      STACK      │     │             HEAP             │
│                 │     │                              │
│  Fast           │     │  Large                       │
│  Small (1-8MB)  │     │  Limited only by RAM         │
│  Auto cleanup   │     │  Garbage Collected           │
│  Per thread     │     │  Shared across threads       │
└─────────────────┘     └──────────────────────────────┘
```

---

## Rule 1 — Value Types go on Stack

Value types hold the actual data directly on Stack.

```csharp
int x = 5;
bool isActive = true;
double price = 9.99;
```

```
STACK
┌─────────────┐
│ x = 5       │
│ isActive = 1│
│ price = 9.99│
└─────────────┘
```

Value types in C#: int, double, float, bool, char, struct, enum

---

## Rule 2 — Reference Types split across Stack and Heap

The reference (memory address) goes on Stack. The actual object data goes on Heap.

```csharp
string name = "Praveen";
```

```
STACK                    HEAP
┌──────────────┐         ┌──────────────┐
│ name → 2000  │────────▶│ "Praveen"    │
└──────────────┘         └──────────────┘
  4-8 bytes               actual data
```

Reference types in C#: string, class, array, List<T>, Dictionary, any object created with new

---

## Rule 3 — Arrays

```csharp
int[] arr = new int[] {10, 20, 30};
```

```
STACK                    HEAP
┌──────────────┐         ┌──────────────────────┐
│ arr → 3000   │────────▶│ [10] [20] [30]       │
└──────────────┘         │  3000 3004 3008       │
  reference               contiguous block
```

Array variable on Stack holds address. Actual data on Heap in contiguous memory.
Contiguous layout is why index access is O(1) — address = base + (index × element_size).

---

## Rule 4 — Objects (Classes)

```csharp
Node node = new Node(5);
```

```
STACK                    HEAP
┌──────────────┐         ┌──────────────────┐
│ node → 4000  │────────▶│ Value = 5        │
└──────────────┘         │ Next → null      │
                         └──────────────────┘
```

---

## Rule 5 — Linked List nodes scattered in Heap

```
STACK              HEAP
┌──────────┐       ┌────────────────┐      ┌────────────────┐
│node1→5000│──────▶│ Value = 1      │      │ Value = 2      │
│node2→6000│──┐    │ Next → 6000    │─────▶│ Next → null    │
└──────────┘  │    └────────────────┘      └────────────────┘
              └────────────────────────────────────────────▶
```

Nodes are NOT contiguous. Scattered across Heap. This is why Linked List index access is O(n) — must follow Next pointer chain.

---

## Rule 6 — Method Stack Frames

Each method call pushes a new frame onto Stack. When method returns, frame is popped and gone.

```csharp
void Main() {
    int a = 5;
    Add(a, 3);
}
int Add(int x, int y) {
    int result = x + y;
    return result;
}
```

```
STACK
┌──────────────┐   ← Add() frame (popped when Add returns)
│ x = 5        │
│ y = 3        │
│ result = 8   │
├──────────────┤   ← Main() frame
│ a = 5        │
└──────────────┘
```

---

## Why References are on Stack not Heap

Reference is just 4-8 bytes (a memory address). Tiny, fixed size, short-lived — Stack is perfect.

Object data must survive beyond the method that created it. If it was on Stack it would be wiped when the method returns. Heap data survives as long as something references it.

```
CreateNode() returns — stack frame wiped:
STACK                    HEAP
┌──────────┐             ┌────────────┐
│ (gone)   │             │ Value = 5  │ ← still alive
└──────────┘             │ Next = null│
                         └────────────┘
```

---

## Inside Your .NET Process in RAM

```
Your .NET App Memory
┌───────────────────────────────────────┐
│  Code Segment — compiled instructions │
│  read only, lives for app lifetime    │
├───────────────────────────────────────┤
│  Static Segment — static variables    │
│  lives for entire app lifetime        │
├───────────────────────────────────────┤
│  Stack          ↓ grows downward      │
│  ┌────────────────────┐               │
│  │ Main() frame       │               │
│  │ Add() frame        │               │
│  └────────────────────┘               │
│         (free space)                  │
│  Heap           ↑ grows upward        │
│  ┌──────────────────────────────────┐ │
│  │ objects, arrays, strings         │ │
│  │ scattered, GC managed            │ │
│  └──────────────────────────────────┘ │
└───────────────────────────────────────┘
```

---

## Physical RAM

Stack and Heap are NOT different hardware. They are different regions in the same RAM chips.

```
RAM (16GB)
┌─────────────────────────────┐
│  OS kernel                  │
│  Chrome — stack + heap      │
│  VS Code — stack + heap     │
│  Your .NET app — stack+heap │
└─────────────────────────────┘
```

The OS gives each process a virtual address space. The process thinks it owns a large address range. OS maps this to actual physical RAM. This is called virtual memory.

Each thread gets its own Stack. All threads in a process share the same Heap.

---

## Golden Rules Summary

| What | Where | Why |
|---|---|---|
| int, bool, double, struct | Stack | Small, fixed size, short-lived |
| string, class, array, List | Reference on Stack, data on Heap | Large, must survive method returns |
| new keyword | Always Heap | Creates object on Heap |
| Method local variables | Stack | Cleaned up when method returns |
| Static variables | Static segment | Lives for app lifetime |
| When method ends | Stack frame gone | Heap cleaned by GC later |

---

## Collections Under the Hood

| Collection | Under the Hood |
|---|---|
| List<T> | Dynamic array — doubles in size when full |
| Dictionary<K,V> | Array of buckets + linked list (HashMap) |
| HashSet<T> | Array of buckets (HashMap without values) |
| Stack<T> | Array |
| Queue<T> | Circular array |
| LinkedList<T> | Actual linked list with Prev and Next nodes |
