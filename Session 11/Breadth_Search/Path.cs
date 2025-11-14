using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadth_Search
{
    internal class PathList
    {
        List<int> Path = new List<int>() { 1, 2, 3 };

        //method to print the path
        public void PrintPath()
        {
            Console.WriteLine("Path: ");
            foreach (int step in Path)
            {
                Console.Write(step + " ");
            }
            Console.WriteLine();
        }

        //method to add a step to the path
        public void AddStep(int step)
        {
            Path.Add(step);
        }
        public void RemoveStep(int step)
        {
            Path.Remove(step);
        }
        public void Clear()
        {
            Path.Clear();

        }
    }
}
