using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        char[][] grid1 = new char[][]
        {
            new char[] {'1','1','0','0','0'},
            new char[] {'1','1','0','0','0'},
            new char[] {'0','0','1','0','0'},
            new char[] {'0','0','0','1','1'}
        };

        char[][] grid2 = new char[][]
        {
            new char[] {'1','1','1'},
            new char[] {'0','1','0'},
            new char[] {'1','1','1'}
        };

        Console.WriteLine(NumberOfIslands(grid1));  // 3
        Console.WriteLine(NumberOfIslands(grid2));  // 1
    }

    private static int NumberOfIslands(char[][] grid)
    {
        int count = 0;

        for (int row = 0; row < grid.Length; row++)
        {
            for (int col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == '1')
                {
                    count++;
                    BFS(grid, row, col);
                }
            }
        }

        return count;
    }

    private static void BFS(char[][] grid, int row, int col)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((row, col));

        while (queue.Count != 0)
        {
            var (r, c) = queue.Dequeue();
            grid[r][c] = '0';

            int[][] directions = { new[]{-1,0}, new[]{1,0}, new[]{0,-1}, new[]{0,1} };

            foreach (var direction in directions)
            {
                int newRow = r + direction[0];
                int newCol = c + direction[1];

                if (newRow >= 0 && newRow < grid.Length
                    && newCol >= 0 && newCol < grid[newRow].Length
                    && grid[newRow][newCol] == '1')
                {
                    grid[newRow][newCol] = '0';
                    queue.Enqueue((newRow, newCol));
                }
            }
        }
    }
}

// PATTERN — BFS on a 2D Grid
// Outer loop: scan every cell
// When '1' found: increment count, BFS to mark entire island as visited
// BFS: Queue of (row,col) tuples, check 4 directions, mark '0' before enqueuing
// Marking '0' prevents revisiting the same cell

// Directions array: up(-1,0), down(1,0), left(0,-1), right(0,1)
// Boundary check: newRow and newCol must be within grid dimensions

// Time Complexity: O(m x n) — visit every cell once
// Space Complexity: O(min(m,n)) — queue size at most the smaller dimension
