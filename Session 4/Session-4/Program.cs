namespace Session_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Task();
        }

        ////Read command promt input
        //static bool TryParseCommand(string line, out string cmd, out int a, out int b) // out parameters from cmd, a , b
        //{
        //    cmd = “”; // basic command
        //    a = b = 0; // parameters 
        //    if (string.IsNullOrWhiteSpace(line)) // if the line is empty or null
        //        return false; 
        //    var parts = line.Trim().Split(new[] {‘ ‘,’\t’}, StringSplitOptions.RemoveEmptyEntries); //
        //    cmd = parts[0].ToUpperInvariant();
        //    if (parts.Length == 3 && int.TryParse(parts[1], out a) && int.TryParse(parts[2], out b))
        //        return true;
        //    return parts.Length == 1; // for simple commands like SAVE/LOAD/Q
        //}

        static void Task()
        {
            //Initialising a 10x10 char array
            char[,] grid = new char[15, 15];
            //Set all elements to '.'
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    grid[i, j] = '.';
                }
            }

            //Print the array
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
            // find center of the array
            int centerX = grid.GetLength(0) / 2;
            int centerY = grid.GetLength(1) / 2;

            // add character to center of the array
            grid[centerX, centerY] = 'X';
            Console.WriteLine();
            //Print the array again
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }
            // add obstitacles to the array at random positions shown ny "#"
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int x = rand.Next(0, 15);
                int y = rand.Next(0, 15);
                // make sure the obstacle is not placed on the character
                if (x == centerX && y == centerY)
                {
                    i--;
                    continue;
                }
                grid[x, y] = '#';
            }
            // add points to the array at random positions shown by "*"
            for (int i = 0; i < 10; i++)
            {
                int x = rand.Next(0, 15);
                int y = rand.Next(0, 15);
                // make sure the point is not placed on the character or an obstacle
                if ((x == centerX && y == centerY) || grid[x, y] == '#')
                {
                    i--;
                    continue;
                }
                grid[x, y] = '*';
            }
            // add an exit point to the array at a random position shown by "E"
            int exitX, exitY;
            while (true)
            {
                exitX = rand.Next(0, 15);
                exitY = rand.Next(0, 15);
                // make sure the exit point is not placed on the character, an obstacle or a point
                if ((exitX == centerX && exitY == centerY) || grid[exitX, exitY] == '#' || grid[exitX, exitY] == '*')
                {
                    continue;
                }
                grid[exitX, exitY] = 'E';
                break;
            }
            Console.WriteLine();
            //Game over flag
            bool gameOver = false;

            // Initialize number of moves
            int moveCount = 0;

            // Initialize score
            int score = 0;

            //Game loop
            while (!gameOver)
            {
                //Console clear
                Console.Clear();
                //Print the saved array
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        Console.Write(grid[i, j]);
                    }
                    Console.WriteLine();
                }


                //print instructions
                Console.WriteLine("Use W A S D to move the character. Press Q to quit.");
                //count number of moves
                moveCount++;
                Console.WriteLine($"Number of moves: {moveCount}");
                ////print score
                //Console.WriteLine($"Score: {score}");
                //Check if user quits
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'q' || input == 'Q')
                {
                    gameOver = true;
                    continue;
                }
                //Move character based on input
                int newX = centerX;
                int newY = centerY;
                switch (input)
                {
                    case 'w':
                    case 'W':
                        newX--;
                        if (grid[centerX, centerY] == '#')
                        {
                            gameOver = true;
                            Console.Clear();
                            Console.WriteLine("Game Over! You hit an obstacle.");
                        }
                        else if (grid[centerX, centerY] == '*')
                        {
                            score++;
                            Console.WriteLine("You collected a point! +1 score.");
                            Console.WriteLine($"Score: {score}");
                        }
                        else if (grid[centerX, centerY] == 'E')
                        {
                            gameOver = true;
                            Console.Clear();
                            Console.WriteLine("Congratulations! You reached the exit point.");
                            Console.WriteLine($"Final Score: {score}");
                        }
                        break;
                    case 'a':
                    case 'A':
                        newY--;
                        if (grid[centerX, centerY] == '#')
                        {
                            gameOver = true;
                            Console.Clear();
                            Console.WriteLine("Game Over! You hit an obstacle.");
                        }
                        else if (grid[centerX, centerY] == '*')
                        {
                            score++;
                            Console.WriteLine("You collected a point! +1 score.");
                            Console.WriteLine($"Score: {score}");
                        }
                        else if (grid[centerX, centerY] == 'E')
                        {
                            gameOver = true;
                            Console.Clear();
                            Console.WriteLine("Congratulations! You reached the exit point.");
                            Console.WriteLine($"Final Score: {score}");
                        }
                        break;
                    case 's':
                    case 'S':
                        newX++;
                        if (grid[centerX, centerY] == '#')
                        {
                            gameOver = true;
                            Console.Clear();
                            Console.WriteLine("Game Over! You hit an obstacle.");
                        }
                        else if (grid[centerX, centerY] == '*')
                        {
                            score++;
                            Console.WriteLine("You collected a point! +1 score.");
                            Console.WriteLine($"Score: {score}");
                        }
                        else if (grid[centerX, centerY] == 'E')
                        {
                            gameOver = true;
                            Console.Clear();
                            Console.WriteLine("Congratulations! You reached the exit point.");
                            Console.WriteLine($"Final Score: {score}");
                        }
                        break;
                    case 'd':
                    case 'D':
                        newY++;
                        if (grid[centerX, centerY] == '#')
                        {
                            gameOver = true;
                            Console.Clear();
                            Console.WriteLine("Game Over! You hit an obstacle.");
                        }
                        else if (grid[centerX, centerY] == '*')
                        {
                            score++;
                            Console.WriteLine("You collected a point! +1 score.");
                            Console.WriteLine($"Score: {score}");
                        }
                        else if (grid[centerX, centerY] == 'E')
                        {
                            gameOver = true;
                            Console.Clear();
                            Console.WriteLine("Congratulations! You reached the exit point.");
                            Console.WriteLine($"Final Score: {score}");
                        }
                        break;
                    default:
                        continue; //Invalid input, skip the rest of the loop
                }
                ////Check if new position is within bounds
                //if (newX < 0 || newX >= 15 || newY < 0 || newY >= 15)
                //{
                //    //Check if character hits an obstacle
                //    if (grid[centerX, centerY] == '#')
                //    {
                //        gameOver = true;
                //        Console.Clear();
                //        Console.WriteLine("Game Over! You hit an obstacle.");
                //    }
                //    //Check if character hits a point
                //    else if (grid[centerX, centerY] == '*')
                //    {
                //        score++;
                //        Console.WriteLine("You collected a point! +1 score.");
                //        Console.WriteLine($"Score: {score}");
                //    }
                //    //Check if character reaches exit point
                //    if (grid[centerX, centerY] == 'E')
                //    {
                //        gameOver = true;
                //        Console.Clear();
                //        Console.WriteLine("Congratulations! You reached the exit point.");
                //        Console.WriteLine($"Final Score: {score}");



                //        continue; //Out of bounds, skip the rest of the loop
                //}
                
               
                Console.WriteLine($"Total Moves: {moveCount}");
                }
                //Update character position
                grid[centerX, centerY] = '.'; //Set old position to '.'
                centerX = newX;
                centerY = newY;
                grid[centerX, centerY] = 'X'; //Set new position to 'X'








            }


        }
    }
