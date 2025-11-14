using System;

namespace Session_4_2
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

            if (choice == 'Y')// Grid Editor Mode
            {
                GridEditor(grid, ref startX, ref startY, ref exitX, ref exitY);// Allow user to edit grid
            }
            else
            {
                PlaceRandomItems(grid, '#', 20, new Random(), startX, startY);// Place obstacles
                PlaceRandomItems(grid, '*', 10, new Random(), startX, startY);// Place points
                PlaceExit(grid, 'E', new Random(), startX, startY);// Place exit
            }

            RunGame(grid, startX, startY);// Start the game
        }

        static void GridEditor(char[,] grid, ref int startX, ref int startY, ref int exitX, ref int exitY)// Grid Editor Mode
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

                if (TryParseCommand(input, out string cmd, out int a, out int b))// Parse command 
                {
                    switch (cmd)// Execute command
                    {
                        case "O":// Toggle obstacle
                            if (IsInBounds(grid, a, b))
                                grid[a, b] = grid[a, b] == '#' ? '.' : '#';
                            break;
                        case "S":// Set start position
                            if (IsInBounds(grid, a, b))
                            {
                                grid[startX, startY] = '.';
                                startX = a;
                                startY = b;
                                grid[startX, startY] = 'X';
                            }
                            break;
                        case "E":// Set exit position
                            if (IsInBounds(grid, a, b))
                            {
                                if (exitX != -1 && exitY != -1)
                                    grid[exitX, exitY] = '.';
                                exitX = a;
                                exitY = b;
                                grid[exitX, exitY] = 'E';
                            }
                            break;
                        case "Q":// Quit editor
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

        static void RunGame(char[,] grid, int startX, int startY)// Main Game Loop
        {
            int playerX = startX;// Player position
            int playerY = startY;// Player position
            int moveCount = 0;// Move counter
            int score = 0;// Score counter
            bool gameOver = false;// Game over flag

            while (!gameOver)// Game loop
            {
                Console.Clear();
                PrintGrid(grid);
                Console.WriteLine("Use W A S D to move. Q to quit.");// Instructions
                Console.WriteLine($"Moves: {moveCount} | Score: {score}");// Display stats
                PrintCoordinatesInList(new CoordinateList());// Print player coordinates

                char input = char.ToUpper(Console.ReadKey(true).KeyChar);// Get user input
                int newX = playerX;// New position
                int newY = playerY;// New position

                switch (input)// Process input
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

                if (!IsValidMove(grid, newX, newY))// Check bounds
                {
                    Console.WriteLine("You can't move outside the grid!");
                    continue;
                }

                char targetCell = grid[newX, newY];// Target cell content
                if (targetCell == '#')// Obstacle check
                {
                    gameOver = true;
                    Console.Clear();
                    Console.WriteLine("Game Over! You hit an obstacle.");
                    break;
                }
                else if (targetCell == '*')// Point collection
                {
                    score++;
                    Console.WriteLine("You collected a point! +1 score.");
                }
                else if (targetCell == 'E')// Exit check
                {
                    gameOver = true;
                    Console.Clear();
                    Console.WriteLine("Congratulations! You reached the exit point.");
                    Console.WriteLine($"Final Score: {score} | Total Moves: {moveCount + 1}");
                    break;
                }

                grid[playerX, playerY] = '.';// Clear old position
                playerX = newX;// Update position
                playerY = newY;// Update position
                grid[playerX, playerY] = 'X';// Set new position
                //call method to copy player coordinates to CoordinateList
                CopyPlayerCoordinatesToList(new CoordinateList(), playerX, playerY);
                moveCount++;// Increment move count
            }
        }

        static char[,] InitializeGrid(int size)// Initialize empty grid
        {
            char[,] grid = new char[size, size];// Create grid
            for (int i = 0; i < size; i++)// Fill with empty cells
                for (int j = 0; j < size; j++)// Fill with empty cells
                    grid[i, j] = '.';// Empty cell
            return grid;
        }

        static void PrintGrid(char[,] grid)// Print the grid to console
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                    Console.Write(grid[i, j]);
                Console.WriteLine();
            }
        }

        static void PlaceRandomItems(char[,] grid, char symbol, int count, Random rand, int avoidX, int avoidY)// Place random items on the grid
        {
            int placed = 0;// Items placed counter
            while (placed < count)// Place until count reached
            {
                int x = rand.Next(grid.GetLength(0));
                int y = rand.Next(grid.GetLength(1));
                if ((x == avoidX && y == avoidY) || grid[x, y] != '.')// Avoid start position and occupied cells
                    continue;
                grid[x, y] = symbol;// Place item
                placed++;// Increment placed counter
            }
        }

        static void PlaceExit(char[,] grid, char symbol, Random rand, int avoidX, int avoidY)// Place exit point on the grid
        {
            while (true)// Keep trying until placed
            {
                int x = rand.Next(grid.GetLength(0));
                int y = rand.Next(grid.GetLength(1));
                if ((x == avoidX && y == avoidY) || grid[x, y] != '.')// Avoid start position and occupied cells
                    continue;
                grid[x, y] = symbol;// Place exit
                break;// Exit placed
            }
        }

        static bool IsValidMove(char[,] grid, int x, int y)// Check if move is valid
        {
            return x >= 0 && x < grid.GetLength(0) &&// Check X bounds
                   y >= 0 && y < grid.GetLength(1);// Check Y bounds
        }

        static bool IsInBounds(char[,] grid, int x, int y)// Check if coordinates are within grid bounds
        {
            return x >= 0 && x < grid.GetLength(0) &&// Check X bounds
                   y >= 0 && y < grid.GetLength(1);// Check Y bounds
        }
        static bool TryParseCommand(string line, out string cmd, out int a, out int b)// Parse user command
        {
            cmd = "";// Initialize command
            a = b = 0;// Initialize parameters

            if (string.IsNullOrWhiteSpace(line))// Check for empty input
                return false;

            var parts = line.Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);// Split input into parts
            cmd = parts[0].ToUpperInvariant();// Get command

            if (parts.Length == 3 &&// Check for commands with two parameters
                int.TryParse(parts[1], out a) &&// Parse first parameter
                int.TryParse(parts[2], out b))// Parse second parameter
            {
                return true;
            }

            return parts.Length == 1; // for simple commands like Q
        }

        // method to copy player coordinates to CoordinateList
        static void CopyPlayerCoordinatesToList(CoordinateList list, int x, int y)
        {
            list.AddCoordinate(x, y);
        }

        //method to print coordinates
        static void PrintCoordinatesInList(CoordinateList list)
        {
            Console.WriteLine("Player Coordinates:");
            list.PrintCoordinates();
        }
    }
}
