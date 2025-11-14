namespace FridayWeek5Lab
    {
        class ScaryBugsForHalloween //Named class
        {
            static void Main(string[] args) //Main method
        {
                int[] numbers = { 2, 4, 6, 8, 10 };//Array pf numbers to use
                Console.WriteLine("Sum of array: " + SinfulSumArray(numbers));//Printing method using the array

                Console.WriteLine("Recursive countdown from 5:");//Printing countdown
            RevoltingRecursiveCountdown(5);//Calling countdown method

            Console.WriteLine("Reversed string: " + WrongWreverse("Hello"));//printing reversed string

            int[] data = { 5, 10, 15 };//New array
                Console.WriteLine("Largest number: " + FreakyFindMax(data));//Printing largest number from array

            Console.WriteLine("Fibonacci of 6: " + FeindishFibonacci(6));//Printing fibonacci of 6
        }

            static int SinfulSumArray(int[] arr)//Method to sum array
        {
                int total = 0;//Total variable
            for (int i = 0; i < arr.Length; i++)//Loop through array
            {
                    total += arr[i];//Add each element to total
            }
                return total;//Return total
        }

            static void RevoltingRecursiveCountdown(int n)//Recursive countdown method
        {
                Console.WriteLine(n);//Print current number
            if (n > 0)//Base case
            {
                    RevoltingRecursiveCountdown(n - 1);//Recursive call
            }
            }

            static string WrongWreverse(string s)//Method to reverse string
        {
                char[] letters = s.ToCharArray();//Convert string to char array
            for (int i = 0; i < letters.Length / 2; i++)//Loop through half of the array
            {
                    char temp = letters[i];//Temporary variable
                letters[i] = letters[letters.Length - i - 1];//Swap characters
                letters[letters.Length - i - 1] = temp;//Complete swap
            }
                return new string(letters);//Convert char array back to string
        }

        static int FreakyFindMax(int[] arr)//Method to find max in array
        {
                int max = arr[0];//Assume first element is max
            for (int i = 1; i < arr.Length; i++)//Loop through array
            {
                    if (arr[i] > max)//If current element is greater than max
                    max = arr[i];//Update max
            }
                return max;//Return max
        }

        static int FeindishFibonacci(int n)//Fibonacci method
        {
            if (n == 1)//Base case
                return 1;//Return 1
            if (n == 0)//Base case
                return 0;//Return 0
            return FeindishFibonacci(n - 1) + FeindishFibonacci(n - 2);//Recursive case
        }
    }
    }
