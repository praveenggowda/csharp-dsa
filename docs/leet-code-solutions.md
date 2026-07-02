# LeetCode Solutions

## 1. Two Sum
**Difficulty:** Easy | **Pattern:** Dictionary / Hash Map

```csharp
// Brute Force O(n²)
private static int[] BruteForce(int[] nums, int target)
{
    for (var i = 0; i < nums.Length; i++)
        for (var j = i + 1; j < nums.Length; j++)
            if (nums[i] + nums[j] == target)
                return [i, j];
    return [];
}

// Optimal O(n) — Dictionary
// For each number, ask "have I already seen the complement?"
// complement = target - current number
private static int[] UsingDictionary(int[] nums, int target)
{
    var seen = new Dictionary<int, int>(); // key=number, value=index

    for (var i = 0; i < nums.Length; i++)
    {
        var complement = target - nums[i];
        if (seen.ContainsKey(complement))
            return [seen[complement], i];
        seen[nums[i]] = i;
    }

    return [];
}
```

**Key insight:** Build the dictionary AS you loop, not before. Store number and index, check for complement on every iteration.

---

## 2. Contains Duplicate
**Difficulty:** Easy | **Pattern:** HashSet

```csharp
// Brute Force O(n²)
private static bool BruteForce(int[] nums)
{
    for (var i = 0; i < nums.Length; i++)
        for (var j = i + 1; j < nums.Length; j++)
            if (nums[i] == nums[j]) return true;
    return false;
}

// Optimal O(n) — HashSet
// Add() returns false if value already exists
private static bool UsingHashSet(int[] nums)
{
    var seen = new HashSet<int>();
    foreach (var num in nums)
        if (!seen.Add(num)) return true;
    return false;
}
```

**Key insight:** HashSet.Add() returns false on duplicate. One line check.

**When to use what:**
- Need index? Dictionary
- Just seen or not seen? HashSet
- Raw data or ordering? Array

---

## 3. Valid Parentheses
**Difficulty:** Easy | **Pattern:** Stack

```csharp
// Stack O(n)
// Opening brackets park on stack, closing brackets check the top
private static bool IsValidParentheses(string parentheses)
{
    var stack = new Stack<char>();

    foreach (var c in parentheses)
    {
        if (c is '(' or '[' or '{')
            stack.Push(c);
        else
        {
            if (stack.Count == 0) return false;

            if (c == ')' && stack.Peek() == '(') stack.Pop();
            else if (c == ']' && stack.Peek() == '[') stack.Pop();
            else if (c == '}' && stack.Peek() == '{') stack.Pop();
            else return false;
        }
    }

    return stack.Count == 0;
}
```

**Key insight:** Stack is LIFO. Opening brackets wait on the stack. Each closing bracket must match the most recent unmatched opener.

**Edge cases:** Empty stack on closing bracket, wrong pair match.

---

## 4. Best Time to Buy and Sell Stock
**Difficulty:** Easy | **Pattern:** Two variables, single pass

```csharp
// O(n) — track minimum price and maximum profit separately
private static int GetProfit(int[] prices)
{
    var minPrice = prices[0];  // lowest buy price seen so far
    var maxProfit = 0;         // best profit found so far

    foreach (var price in prices)
    {
        if (price < minPrice)
            minPrice = price;          // found a cheaper buy day

        var profit = price - minPrice; // what if we sold today?

        if (profit > maxProfit)
            maxProfit = profit;        // better deal, keep it
    }

    return maxProfit;
}
```

**Key insight:** Two variables, one pass. minPrice tracks the best day to buy. maxProfit tracks the best deal found. Never return early, visit every day.

---

## 5. Reverse a String
**Difficulty:** Easy | **Pattern:** StringBuilder reverse loop

```csharp
// O(n) — loop from end to start
private static string ReverseString(string input)
{
    var reversedString = new StringBuilder();

    for (var i = input.Length - 1; i >= 0; i--)
        reversedString.Append(input[i]);

    return reversedString.ToString();
}

// Alternative — two pointer on char array
private static string TwoPointer(string input)
{
    var chars = input.ToCharArray();
    int left = 0, right = chars.Length - 1;

    while (left < right)
    {
        (chars[left], chars[right]) = (chars[right], chars[left]);
        left++;
        right--;
    }

    return new string(chars);
}
```

**Key insight:** StringBuilder over string concatenation in a loop. Two pointer is the alternative interviewers may ask about.

---

## 6. FizzBuzz
**Difficulty:** Easy | **Pattern:** Modulo operator, condition order matters

### Theory
- `%` is the modulo operator — gives you the remainder after division
- If `i % 3 == 0` the number divides evenly by 3 (no decimal, no remainder)
- **Order of conditions is critical:** FizzBuzz (both) must come FIRST, then Fizz, then Buzz
- If you check Fizz first, you will never reach FizzBuzz for multiples of 15

### Why order matters:
```
i = 15
if (i % 3 == 0)  ← this is true, returns "Fizz" immediately, never reaches FizzBuzz ❌

Correct order:
if (i % 3 == 0 && i % 5 == 0)  ← check both first ✅
else if (i % 3 == 0)
else if (i % 5 == 0)
else → print number
```

### Checking for whole numbers (no decimal point):
```csharp
// For int — no check needed, integers cannot have decimals
// For double
bool isWhole = number % 1 == 0;
// For decimal
bool isWhole = number == Math.Floor(number);
```

```csharp
// O(n) — single loop with modulo checks
private static string FizzBuzz(int input)
{
    var fizzBuzzString = new StringBuilder();

    for (var i = 1; i <= input; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
            fizzBuzzString.Append("FizzBuzz, ");
        else if (i % 3 == 0)
            fizzBuzzString.Append("Fizz, ");
        else if (i % 5 == 0)
            fizzBuzzString.Append("Buzz, ");
        else
            fizzBuzzString.Append($"{i}, ");
    }

    return fizzBuzzString.ToString().TrimEnd(',', ' ');
}
```

**Key insight:** Check FizzBuzz (divisible by both 3 and 5) first or you will never reach it. `TrimEnd(',', ' ')` removes the trailing comma and space from the last element.
