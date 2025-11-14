namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Task1();
            Task2();
        }
        static void Task1()
        {
            //Exercise 1: Initialising a 10x10 char array
            char[,] grid = new char[10, 10];
            //Set all elements to '.'
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = '.';
                }
            }
        }

        static void Task2()
        {
            //Print the array
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
