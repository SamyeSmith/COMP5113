namespace Session_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Task 1: Print numbers from 1 to 10
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
            Task7();
            Task8();
            Task9();
            Task10();


        }
        static void Task1()
        {
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void Task2()
        {


            // Task 2: Print two numbers added together from the user input
            Console.WriteLine("Enter first number:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int sum = num1 + num2;
            Console.WriteLine("The sum is: " + sum);
        }

        static void Task3()
        {
            // Task 3: Currency converter from Sterling to American Dollars
            Console.WriteLine("Enter amount in Sterling:");
            double sterling = Convert.ToDouble(Console.ReadLine());
            double exchangeRate = 1.5; // Example exchange rate
            double dollars = sterling * exchangeRate;
            Console.WriteLine("Amount in American Dollars: " + dollars);
        }

        static void Task4()
        {
            // Task 4: Temperature converter from Celsius to Fahrenheit
            Console.WriteLine("Enter temperature in Celsius:");
            double celsius = Convert.ToDouble(Console.ReadLine());
            double fahrenheit = (celsius * 9 / 5) + 32;
            Console.WriteLine("Temperature in Fahrenheit: " + fahrenheit);
        }

        static void Task5()
        {
            // Task 5: Cube a number
            Console.WriteLine("Enter a number to cube:");
            double number = Convert.ToDouble(Console.ReadLine());
            double cube = Math.Pow(number, 3);
            Console.WriteLine("The cube of the number is: " + cube);
        }

        struct Student
        {

            public string Name { get; set; }
            public float Mark { get; set; }
        }
        static void Task6()
        {
            // Task 6: Declare a struct to store the name and mark of a student. The mark should be a floating point

            // Initialize the struct with values
            var student1 = new Student
            {
                Name = "John Doe",
                Mark = 85.5f
            };
            Console.WriteLine("Student Name: " + student1.Name);
            Console.WriteLine("Student Mark: " + student1.Mark);

            // Store the name and mark of 1 student and print them to the console.
            Student student = new Student();
            Console.WriteLine("Enter student name:");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter student mark:");
            student.Mark = float.Parse(Console.ReadLine());
            Console.WriteLine("Student Name: " + student.Name);
            Console.WriteLine("Student Mark: " + student.Mark);


        }
        static void Task7()
        {
            // Tasl 7: create 2 arrays, each 3 integers long, that add together to make a third array
            int[] array1 = new int[3];
            int[] array2 = new int[3];
            int[] array3 = new int[3];
            // Get user input for the first two arrays
            Console.WriteLine("Enter 3 integers for the first array:");
            for (int i = 0; i < 3; i++)
            {
                array1[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Enter 3 integers for the second array:");
            for (int i = 0; i < 3; i++)
            {
                array2[i] = Convert.ToInt32(Console.ReadLine());
            }
            // Add the two arrays together to make the third array
            for (int i = 0; i < 3; i++)
            {
                array3[i] = array1[i] + array2[i];
            }
            // Print the third array to the console
            Console.WriteLine("The third array is:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(array3[i]);
            }
        }
        static void Task8()
        {
            // Task 8: Create a 4 element array of multiples of 3 and print them to the console
            int[] multiplesOf3 = new int[4];
            // Populate the array with multiples of 3
            for (int i = 0; i < 4; i++)
            {
                multiplesOf3[i] = (i + 1) * 3;
            }
            // Print the array to the console
            Console.WriteLine("Multiples of 3:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(multiplesOf3[i]);
            }

        }
        struct Car
        {
            public string colour;
            public string make;
            public double mileage;
            public int doors;
        }
        static void Task9()
        {
            // Task 9: Retreve the values of the struct car and print them to the console 

            // Each new car should be in a new array
            Car[] cars = new Car[4];

            // Initialize the struct with values
            var car1 = new Car
            {
                colour = "Red",
                make = "Toyota",
                mileage = 15000.5,
                doors = 4
            };
            // Store the struct in the array
            cars[0] = car1;
            // get user input for the previous car struct
            var car2 = new Car();
            Console.WriteLine("Enter car colour:");
            car2.colour = Console.ReadLine();
            Console.WriteLine("Enter car make:");
            car2.make = Console.ReadLine();
            Console.WriteLine("Enter car mileage:");
            car2.mileage = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter number of doors:");
            car2.doors = Convert.ToInt32(Console.ReadLine());
            // Store the struct in the array
            cars[1] = car2;
            // get user input for 3 more car structs
            for (int i = 2; i < 4; i++)
            {
                var car = new Car();
                Console.WriteLine("Enter car colour:");
                car.colour = Console.ReadLine();
                Console.WriteLine("Enter car make:");
                car.make = Console.ReadLine();
                Console.WriteLine("Enter car mileage:");
                car.mileage = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter number of doors:");
                car.doors = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("-------------------------");
                // Store the struct in the array
                cars[i] = car;
            }
            // Print the array to the console
            Console.WriteLine("Cars:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Car " + (i + 1) + ":");
                Console.WriteLine("Colour: " + cars[i].colour);
                Console.WriteLine("Make: " + cars[i].make);
                Console.WriteLine("Mileage: " + cars[i].mileage);
                Console.WriteLine("Doors: " + cars[i].doors);
                Console.WriteLine("-------------------------");
            }
        }
        static void Task10()
        {
            Console.WriteLine(
                "-------------------------");
            //Write a program that adds the corresponding elements of two two-dimensional integer arrays, each of size 2x3 and outputs the results to screen
            int[,] array1 = new int[2, 3];
            int[,] array2 = new int[2, 3];
            int[,] sumArray = new int[2, 3];
            // Get user input for the first two arrays
            Console.WriteLine("Enter 6 integers for the first 2x3 array:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array1[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Enter 6 integers for the second 2x3 array:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array2[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            // Add the two arrays together to make the third array
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sumArray[i, j] = array1[i, j] + array2[i, j];
                }
            }
            // Print the third array to the console
            Console.WriteLine("The sum of the two arrays is:");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(sumArray[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(
                "-------------------------");

        }

    }
}
