using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadth_Search
{
    //public class Element<T>
    //{
    //    private int _data;
    //    private Element<T>? _next;

    //    public Element(int data) { _data = data; }
    //    public int Data { get { return _data; } }

    //    public Element<T>? Next
    //    {
    //        get { return _next; }
    //        set { _next = value; }
    //    }
    //}
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

        //method to get last coordinate without removing it
        public void PeekLastCoordinate()
        {
            if (coordinates.Count > 0)
            {
                var last = coordinates.Last.Value;
                Console.WriteLine($"Last Coordinate: ({last.X}, {last.Y})");
            }
            else
            {
                Console.WriteLine("No coordinates in the list.");
            }
        }
    }


    public interface ICoordinateList<T>
    {
        void AddCoordinate(double x, double y);
        void PrintCoordinates();
        (double X, double Y)? GetLastCoordinate();
        void ClearCoordinates();
        void DeleteLastCoordinate();
    }

    public class CoordinateListImplementation : ICoordinateList<(double X, double Y)>
    {
        private readonly LinkedList<(double X, double Y)> _list = new LinkedList<(double X, double Y)>();
        public bool Dequeue(ref T value)
        {
            bool result = _list.PeekLastCoordinate(value);
            _list.PopFront();
            return result;
        }
        private CoordinateList coordinateList;
        public CoordinateListImplementation()
        {
            coordinateList = new CoordinateList();
        }
        public void AddCoordinate(double x, double y)
        {
            coordinateList.AddCoordinate(x, y);
        }
        public void PrintCoordinates()
        {
            coordinateList.PrintCoordinates();
        }
        public (double X, double Y)? GetLastCoordinate()
        {
            return coordinateList.GetLastCoordinate();
        }
        public void ClearCoordinates()
        {
            coordinateList.ClearCoordinates();
        }
        public void DeleteLastCoordinate()
        {
            coordinateList.DeleteLastCoordinate();
        }
    }