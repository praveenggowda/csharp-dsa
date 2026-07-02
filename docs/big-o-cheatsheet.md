# Big O Cheat Sheet

## The Rules

| Rule | What it means | Example |
|---|---|---|
| Drop constants | O(2n) → O(n) | Loop running n/2 times is still O(n) |
| Drop non-dominant terms | O(n² + n) → O(n²) | The smaller term doesn't matter |
| Different inputs = different variables | Two arrays a and b → O(a × b) not O(n²) | Never call it O(n²) if inputs are different |
| Fixed iterations = constant | Loop running 10000 times → drop it | Only matters if tied to input size |

---

## Pattern Table

| Pattern | Code Shape | Big O |
|---|---|---|
| Single loop | `for i in n` | O(n) |
| Two nested loops same input | `for i` → `for j` | O(n²) |
| Three nested loops same input | `for i` → `for j` → `for k` | O(n³) |
| Two nested loops different inputs | `for i in a` → `for j in b` | O(a × b) |
| Fixed iterations inside loop | `for i in n` → `for k < 10000` | O(n) |
| Halving each step | `while n > 0: n = n/2` | O(log n) |
| Loop + halving | `for i in n` + binary search inside | O(n log n) |
| Sorting | any comparison sort | O(n log n) |
| Loop stops at √n | `x * x <= n` | O(√n) |
| Recursive — 1 call, input halved | binary search recursive | O(log n) |
| Recursive — 2 calls, input halved | merge sort | O(n log n) |
| Recursive — 2 calls, input NOT halved | Fibonacci | O(2ⁿ) |
| Recursive — n calls (loop inside) | permutations | O(n!) |
| Memoized recursion | Fibonacci with cache | O(n) |

---

## Speed Order (fastest to slowest)

```
O(1) → O(log n) → O(√n) → O(n) → O(n log n) → O(n²) → O(2ⁿ) → O(n!)
```

---

## Recursion — The Confusing Part

This is where most people get lost. Use these questions:

**Q1: How many recursive calls does each function make?**
- 1 call → likely O(log n) if input halves
- 2 calls → O(2ⁿ) if input does NOT halve, O(n log n) if it does
- n calls (loop inside) → O(n!)

**Q2: Does the input get smaller each call? By how much?**
- Halved → log n levels in the call tree
- Reduced by 1 → n levels in the call tree

**Q3: Is there a cache (memoization)?**
- Yes → each value computed once → O(n)
- No → repeated work → O(2ⁿ) for Fibonacci style

---

## Worked Examples

### isPrime — O(√n)
```java
for (int x = 2; x * x <= n; x++)
```
Loop stops at x = √n because x*x <= n. Not O(n) — loop never reaches n.

---

### printUnorderedPairs same array — O(n²)
```java
for (int i = 0; i < arr.length; i++)
    for (int j = i + 1; j < arr.length; j++)
```
Runs n(n-1)/2 times. Drop the constant /2 → O(n²).

---

### printUnorderedPairs different arrays — O(a × b)
```java
for (int i = 0; i < arrayA.length; i++)
    for (int j = 0; j < arrayB.length; j++)
```
Two different inputs. Never call this O(n²). Use two variables.

---

### With fixed inner loop — still O(a × b)
```java
for (int i = 0; i < arrayA.length; i++)
    for (int j = 0; j < arrayB.length; j++)
        for (int k = 0; k < 10000; k++)
```
10000 is a constant. Drop it → O(a × b).

---

### Reverse array — O(n)
```java
for (int i = 0; i < array.length / 2; i++)
```
Runs n/2 times. Drop the /2 → O(n).

---

### Sort array of strings — O(n·s(log s + log n))
Let s = length of longest string, n = number of strings.
- Sorting each string: O(s log s) per string × n strings = O(n·s log s)
- Sorting the array: O(n log n) comparisons × O(s) per comparison = O(s·n log n)
- Total: O(n·s(log s + log n))
- NOT O(n log n) — that ignores the cost of comparing strings

---

### Fibonacci nth value — O(2ⁿ)
```java
int fib(int n) {
    return fib(n-1) + fib(n-2);  // 2 calls, input NOT halved
}
```
Each call makes 2 calls. Tree depth = n. Total nodes = 2ⁿ.

---

### Fibonacci 0 through n — still O(2ⁿ)
```java
void allFib(int n) {
    for (int i = 0; i < n; i++)
        System.out.println(fib(i));  // fib itself is recursive
}
```
fib(1)=2¹, fib(2)=2², ..., fib(n)=2ⁿ. Sum of geometric series = O(2ⁿ).

---

### Fibonacci with cache — O(n)
```java
if (memo[n] > 0) return memo[n];  // already computed
```
Each value computed exactly once. n values → O(n).
This technique is called **memoization** — foundation of Dynamic Programming.

---

### Permutations — O(n × n!)
```java
for (int i = 0; i < str.length(); i++) {
    permutation(rem, prefix + str.charAt(i));  // n calls at each level
}
```
n × (n-1) × (n-2) × ... × 1 = n! calls. Each call does O(n) work (substring). Total = O(n × n!).

---

## The Decision Tree

```
Is the loop / recursion tied to input size?
  No  → constant, drop it → O(1)
  Yes →
    Does it halve the input each step?
      Yes → O(log n)
    Is it a loop?
      Single loop → O(n)
      Nested same input → O(n²)
      Nested different inputs → O(a × b)
    Is it recursive?
      2 calls + input halved → O(n log n)
      2 calls + input NOT halved → O(2ⁿ)
      n calls (loop inside) → O(n!)
      Has cache → O(n)
```
