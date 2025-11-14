using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_3
{
    internal class Student
    {
        // This class represents a student with properties for name and grade.
        public string Name { get; set; }
        public int Grade { get; set; }

        // Constructor to initialize a student with a name and grade.
        public Student(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }

        // Method to initalize student details from user input.
        public void initializeFromInput()
        {
            Console.Write("Enter student name: ");
            Name = Console.ReadLine();
            Console.Write("Enter student grade: ");
            Grade = int.Parse(Console.ReadLine());
        }

        // Method to update student grade.
        public void UpdateGrade(int newGrade)
        {
            Grade = newGrade;
        }

        // Method to assign random grade to student.
        public void AssignRandomGrade()
        {
            Random rand = new Random();
            Grade = rand.Next(25, 85); // Assign a random grade between 25 and 85.
        }

        // Method to display student information.
        public void DisplayInfo()
        {
            Console.WriteLine($"Student Name: {Name}, Grade: {Grade}");
        }

    }
}
