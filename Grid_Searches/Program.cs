using System;
using System.Collections.Generic;

namespace Grid_Searches
{
    public enum PathAlgo { BFS, DFS, HillClimb }

    public class Program
    {
        public static void Main(string[] args)
        {
            const int size = 15;
            var rand = new Random(42); // fixed seed for comparable runs
            char[,] grid = InitializeGrid(size);

            int startX = size / 2, startY = size / 2;
            int exitX = size - 2, exitY = size - 2;

            // Place player and exit
            grid[startX, startY] = 'X';
            grid[exitX, exitY] = 'E';

            // Place obstacles and collectibles
            PlaceRandomItems(grid, '#', 35, rand, startX, startY, exitX, exitY);
            PlaceRandomItems(grid, '*', 20, rand, startX, startY, exitX, exitY);

            // Choose algorithm
            PathAlgo algo = PromptAlgorithm();

            // Compute and mark path
            var path = algo switch
            {
                PathAlgo.BFS => GetPathBFS(grid, (startX, startY), (exitX, exitY)),
                PathAlgo.DFS => GetPathDFS(grid, (startX, startY), (exitX, exitY)),
                PathAlgo.HillClimb => GetPathHillClimb(grid, (startX, startY), (exitX, exitY)),
                _ => new List<(int, int)>()
            };

            char pathChar = algo switch
            {
                PathAlgo.BFS => '=',
                PathAlgo.DFS => '~',
                PathAlgo.HillClimb => '+',
                _ => '-'
            };

            foreach (var (px, py) in path)
            {
                if (grid[px, py] == '.') grid[px, py] = pathChar;
            }

            Console.Clear();
            Console.WriteLine($"Suggested path by {algo}:");
            PrintGrid(grid);

            RunGame(grid, startX, startY);
        }

        static PathAlgo PromptAlgorithm()
        {
            while (true)
            {
                Console.WriteLine("Choose pathfinding algorithm:");
                Console.WriteLine("1) BFS (shortest path)");
                Console.WriteLine("2) DFS (depth-first path)");
                Console.WriteLine("3) Hill Climbing (greedy, may get stuck)");
                Console.Write("Enter 1/2/3: ");
                var key = Console.ReadKey(true).KeyChar;
                if (key == '1') return PathAlgo.BFS;
                if (key == '2') return PathAlgo.DFS;
                if (key == '3') return PathAlgo.HillClimb;
                Console.WriteLine("Invalid choice. Try again.\n");
            }
        }

        static char[,] InitializeGrid(int size)
        {
            char[,] grid = new char[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    grid[i, j] = '.';
            return grid;
        }

        static void PrintGrid(char[,] grid)
        {
            int rows = grid.GetLength(0), cols = grid.GetLength(1);
            // Optional border
            Console.WriteLine(new string('=', cols));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(grid[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine(new string('=', cols));
        }

        static void PlaceRandomItems(char[,] grid, char symbol, int count, Random rand, int avoidX, int avoidY, int exitX, int exitY)
        {
            int placed = 0;
            int rows = grid.GetLength(0), cols = grid.GetLength(1);
            while (placed < count)
            {
                int x = rand.Next(rows);
                int y = rand.Next(cols);
                if ((x == avoidX && y == avoidY) || (x == exitX && y == exitY) || grid[x, y] != '.')
                    continue;
                grid[x, y] = symbol;
                placed++;
            }
        }

        // BFS: shortest path in grid with obstacles
        static List<(int, int)> GetPathBFS(char[,] grid, (int x, int y) start, (int x, int y) goal)
        {
            int rows = grid.GetLength(0), cols = grid.GetLength(1);
            var dirs = new (int dx, int dy)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var queue = new Queue<(int, int)>();
            var parent = new Dictionary<(int, int), (int, int)>();
            var visited = new HashSet<(int, int)>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();
                if (x == goal.x && y == goal.y) break;

                foreach (var (dx, dy) in dirs)
                {
                    int nx = x + dx, ny = y + dy;
                    if (nx < 0 || nx >= rows || ny < 0 || ny >= cols) continue;
                    if (grid[nx, ny] == '#') continue;
                    var np = (nx, ny);
                    if (visited.Contains(np)) continue;

                    visited.Add(np);
                    parent[np] = (x, y);
                    queue.Enqueue(np);
                }
            }

            // Reconstruct
            var path = new List<(int, int)>();
            var cur = (goal.x, goal.y);
            if (!parent.ContainsKey(cur)) return path; // no path
            while (!cur.Equals(start))
            {
                path.Add(cur);
                cur = parent[cur];
            }
            path.Reverse();
            return path;
        }

        // DFS: returns one found path (not guaranteed shortest)
        static List<(int, int)> GetPathDFS(char[,] grid, (int x, int y) start, (int x, int y) goal)
        {
            int rows = grid.GetLength(0), cols = grid.GetLength(1);
            var dirs = new (int dx, int dy)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var stack = new Stack<(int, int)>();
            var parent = new Dictionary<(int, int), (int, int)>();
            var visited = new HashSet<(int, int)>();

            stack.Push(start);
            visited.Add(start);

            while (stack.Count > 0)
            {
                var (x, y) = stack.Pop();
                if (x == goal.x && y == goal.y) break;

                foreach (var (dx, dy) in dirs)
                {
                    int nx = x + dx, ny = y + dy;
                    if (nx < 0 || nx >= rows || ny < 0 || ny >= cols) continue;
                    if (grid[nx, ny] == '#') continue;
                    var np = (nx, ny);
                    if (visited.Contains(np)) continue;

                    visited.Add(np);
                    parent[np] = (x, y);
                    stack.Push(np);
                }
            }

            // Reconstruct
            var path = new List<(int, int)>();
            var cur = (goal.x, goal.y);
            if (!parent.ContainsKey(cur)) return path; // no path
            while (!cur.Equals(start))
            {
                path.Add(cur);
                cur = parent[cur];
            }
            path.Reverse();
            return path;
        }

        // Hill Climbing: greedy to lower Manhattan distance, may get stuck
        static List<(int, int)> GetPathHillClimb(char[,] grid, (int x, int y) start, (int x, int y) goal)
        {
            int rows = grid.GetLength(0), cols = grid.GetLength(1);
            var dirs = new (int dx, int dy)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var path = new List<(int, int)>();
            var visited = new HashSet<(int, int)>();

            int x = start.x, y = start.y;
            visited.Add((x, y));

            while (true)
            {
                if (x == goal.x && y == goal.y) break;

                int h = Math.Abs(x - goal.x) + Math.Abs(y - goal.y);
                (int bx, int by, int bh) best = (x, y, h);

                foreach (var (dx, dy) in dirs)
                {
                    int nx = x + dx, ny = y + dy;
                    if (nx < 0 || nx >= rows || ny < 0 || ny >= cols) continue;
                    if (grid[nx, ny] == '#') continue;
                    int nh = Math.Abs(nx - goal.x) + Math.Abs(ny - goal.y);
                    if (nh < best.bh && !visited.Contains((nx, ny)))
                    {
                        best = (nx, ny, nh);
                    }
                }

                if (best.bx == x && best.by == y)
                {
                    // Stuck at local minimum; return what we have
                    return path;
                }

                x = best.bx; y = best.by;
                visited.Add((x, y));
                path.Add((x, y));
            }

            return path;
        }

        static void RunGame(char[,] grid, int startX, int startY)
        {
            int playerX = startX, playerY = startY;
            int moveCount = 0, score = 0;
            bool gameOver = false;

            while (!gameOver)
            {
                Console.WriteLine();
                PrintGrid(grid);
                Console.WriteLine("Use W A S D to move. Q to quit.");
                Console.WriteLine($"Moves: {moveCount} | Score: {score}");

                char input = char.ToUpper(Console.ReadKey(true).KeyChar);
                int newX = playerX, newY = playerY;

                switch (input)
                {
                    case 'W': newX--; break;
                    case 'A': newY--; break;
                    case 'S': newX++; break;
                    case 'D': newY++; break;
                    case 'Q': return;
                    default: Console.WriteLine("Invalid key."); continue;
                }

                if (newX < 0 || newX >= grid.GetLength(0) || newY < 0 || newY >= grid.GetLength(1))
                {
                    Console.WriteLine("You can't move outside the grid!");
                    continue;
                }

                char targetCell = grid[newX, newY];
                if (targetCell == '#')
                {
                    Console.WriteLine("Game Over! You hit an obstacle.");
                    Console.WriteLine($"Final Score: {score} | Total Moves: {moveCount}");
                    break;
                }
                else if (targetCell == '*')
                {
                    score++;
                    grid[newX, newY] = '.'; // clear the collectible
                    Console.WriteLine("You collected a point! +1 score.");
                }
                else if (targetCell == 'E')
                {
                    Console.WriteLine("Congratulations! You reached the exit!");
                    Console.WriteLine($"Final Score: {score} | Total Moves: {moveCount + 1}");
                    break;
                }

                grid[playerX, playerY] = '.';
                playerX = newX;
                playerY = newY;
                grid[playerX, playerY] = 'X';
                moveCount++;
            }

            Console.WriteLine("Game over.");
        }
    }
}
