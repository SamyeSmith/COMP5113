using System;

namespace Session_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grid Game!");
            Console.WriteLine("Would you like to edit the grid before starting? (Y/N)");
            char choice = char.ToUpper(Console.ReadKey(true).KeyChar);

            const int size = 15;
            char[,] grid = InitializeGrid(size);
            int startX = size / 2;
            int startY = size / 2;
            int exitX = -1, exitY = -1;

            if (choice == 'Y')
            {
                GridEditor(grid, ref startX, ref startY, ref exitX, ref exitY);
            }
            else
            {
                PlaceRandomItems(grid, '#', 20, new Random(), startX, startY);
                PlaceRandomItems(grid, '*', 10, new Random(), startX, startY);
                PlaceExit(grid, 'E', new Random(), startX, startY);
            }

            RunGame(grid, startX, startY);
        }

        static void GridEditor(char[,] grid, ref int startX, ref int startY, ref int exitX, ref int exitY)
        {
            Console.Clear();
            Console.WriteLine("Grid Editor Mode");
            Console.WriteLine("Commands:");
            Console.WriteLine("O row col → toggle obstacle (#)");
            Console.WriteLine("S row col → set start (X)");
            Console.WriteLine("E row col → set exit (E)");
            Console.WriteLine("Q → quit editor");

            while (true)
            {
                PrintGrid(grid);
                Console.Write("Enter command: ");
                string input = Console.ReadLine();

                if (TryParseCommand(input, out string cmd, out int a, out int b))
                {
                    switch (cmd)
                    {
                        case "O":
                            if (IsInBounds(grid, a, b))
                                grid[a, b] = grid[a, b] == '#' ? '.' : '#';
                            break;
                        case "S":
                            if (IsInBounds(grid, a, b))
                            {
                                grid[startX, startY] = '.';
                                startX = a;
                                startY = b;
                                grid[startX, startY] = 'X';
                            }
                            break;
                        case "E":
                            if (IsInBounds(grid, a, b))
                            {
                                if (exitX != -1 && exitY != -1)
                                    grid[exitX, exitY] = '.';
                                exitX = a;
                                exitY = b;
                                grid[exitX, exitY] = 'E';
                            }
                            break;
                        case "Q":
                            return;
                        default:
                            Console.WriteLine("Unknown command.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command format.");
                }
            }
        }

        static void RunGame(char[,] grid, int startX, int startY)
        {
            int playerX = startX;
            int playerY = startY;
            int moveCount = 0;
            int score = 0;
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();
                PrintGrid(grid);
                Console.WriteLine("Use W A S D to move. Q to quit.");
                Console.WriteLine($"Moves: {moveCount} | Score: {score}");

                char input = char.ToUpper(Console.ReadKey(true).KeyChar);
                int newX = playerX;
                int newY = playerY;

                switch (input)
                {
                    case 'W': newX--; break;
                    case 'A': newY--; break;
                    case 'S': newX++; break;
                    case 'D': newY++; break;
                    case 'Q':
                        gameOver = true;
                        continue;
                    default:
                        continue;
                }

                if (!IsValidMove(grid, newX, newY))
                {
                    Console.WriteLine("You can't move outside the grid!");
                    continue;
                }

                char targetCell = grid[newX, newY];
                if (targetCell == '#')
                {
                    gameOver = true;
                    Console.Clear();
                    Console.WriteLine("Game Over! You hit an obstacle.");
                    break;
                }
                else if (targetCell == '*')
                {
                    score++;
                    Console.WriteLine("You collected a point! +1 score.");
                }
                else if (targetCell == 'E')
                {
                    gameOver = true;
                    Console.Clear();
                    Console.WriteLine("Congratulations! You reached the exit point.");
                    Console.WriteLine($"Final Score: {score} | Total Moves: {moveCount + 1}");
                    break;
                }

                grid[playerX, playerY] = '.';
                playerX = newX;
                playerY = newY;
                grid[playerX, playerY] = 'X';
                moveCount++;
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
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                    Console.Write(grid[i, j]);
                Console.WriteLine();
            }
        }

        static void PlaceRandomItems(char[,] grid, char symbol, int count, Random rand, int avoidX, int avoidY)
        {
            int placed = 0;
            while (placed < count)
            {
                int x = rand.Next(grid.GetLength(0));
                int y = rand.Next(grid.GetLength(1));
                if ((x == avoidX && y == avoidY) || grid[x, y] != '.')
                    continue;
                grid[x, y] = symbol;
                placed++;
            }
        }

        static void PlaceExit(char[,] grid, char symbol, Random rand, int avoidX, int avoidY)
        {
            while (true)
            {
                int x = rand.Next(grid.GetLength(0));
                int y = rand.Next(grid.GetLength(1));
                if ((x == avoidX && y == avoidY) || grid[x, y] != '.')
                    continue;
                grid[x, y] = symbol;
                break;
            }
        }

        static bool IsValidMove(char[,] grid, int x, int y)
        {
            return x >= 0 && x < grid.GetLength(0) &&
                   y >= 0 && y < grid.GetLength(1);
        }

        static bool IsInBounds(char[,] grid, int x, int y)
        {
            return x >= 0 && x < grid.GetLength(0) &&
                   y >= 0 && y < grid.GetLength(1);
        }

        /// <summary>
        /// Parses a command line input into a command and optional integer arguments.
        /// Supports commands like "O 3 4", "S 1 2", "E 5 5", or "Q".
        /// </summary>
        static bool TryParseCommand(string line, out string cmd, out int a, out int b)
        {
            cmd = "";
            a = b = 0;

            if (string.IsNullOrWhiteSpace(line))
                return false;

            var parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            cmd = parts[0].ToUpperInvariant();

            if (parts.Length == 3 &&
                int.TryParse(parts[1], out a) &&
                int.TryParse(parts[2], out b))
            {
                return true;
            }

            return parts.Length == 1; // for simple commands like Q
        }
    }
}
