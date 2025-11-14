using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_1
{
    public class Element<T>
    {
        public T Data { get; set; }
        public Element<T> Next { get; set; }
        public Element(T data)
        {
            Data = data;
            Next = null;
        }
    }
    public class CoordinateList
    {
        //make linked list to store coordinates using type parameters
        private LinkedList<(double X, double Y)> coordinates;
        public CoordinateList()
        {
            coordinates = new LinkedList<(double X, double Y)>();
        }

        //method to add coordinate to the list at the end
        public void AddCoordinate(double x, double y)
        {
            coordinates.AddLast((x, y));
        }

        //method to print all coordinates in the list
        public void PrintCoordinates()
        {
            foreach (var coord in coordinates)
            {
                Console.WriteLine($"({coord.X}, {coord.Y})");
            }
        }

        //method to get the last coordinate added
        public (double X, double Y)? GetLastCoordinate()
        {
            if (coordinates.Count == 0)
                return null;
            return coordinates.Last.Value;
        }

        //method to clear all coordinates from the list
        public void ClearCoordinates()
        {
            coordinates.Clear();
        }

        //method to delete last coordinate from the list
        public void DeleteLastCoordinate()
        {
            if (coordinates.Count > 0)
                coordinates.RemoveLast();

        }


    }
}
