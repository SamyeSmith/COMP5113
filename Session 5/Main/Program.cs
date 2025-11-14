using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COM4115_Data_Structures___Algorithms
{
    public class Element
    {
        private int _data;
        private Element? _next;

        public Element(int data) { _data = data; }
        public int Data { get { return _data; } }

        public Element? Next
        {
            get { return _next; }
            set { _next = value; }
        }

    }

    public class LinkedList
    {
        private Element? _head;
        public LinkedList() { _head = null; }

        // PushFront - add a new element at the head of the list
        public void PushFront(int data)
        {
            Element newElement = new Element(data);
            newElement.Next = _head;
            _head = newElement;
        }

        // PopFront - remove an element from the front of the list
        public void PopFront()
        {
            if (_head != null)
            {
                _head = _head.Next;
            }
        }

        // GetFront - return the data stored in the first element
        public bool getFront(ref int data)
        {
            if (!isEmpty())
            {
                data = _head.Data;
            }
            return !isEmpty();
        }

        // PrintList - display list contents on the console
        public void PrintList()
        {
            Element? currentElement = _head;
            while (currentElement != null)
            {
                Console.Write(currentElement.Data + ", ");
                currentElement = currentElement.Next;
            }
            Console.WriteLine();
        }

        // IsEmpty - return true when the list is empty
        public bool isEmpty()
        {
            return _head == null;
        }

        // contains - return true if a specified value exists in the list
        public bool Contains(int value)
        {
            Element? current = _head;

            while (current != null)
            {
                if (current.Data == value)
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        // count - return the number of elements in the list
        public int Count()
        {
            int count = 0;
            Element? current = _head; // start from the head
            while (current != null) // follow the list
            {
                count++; // increment the count
                current = current.Next; // move to the next element
            }
            // display the count
            Console.WriteLine("Count: " + count);
            return count; // return the count
        }

        // RemoveValue - remove the first occurrence of a specific element in the list
        public bool RemoveValue(int value) // return true if the value was found and removed
        {
            if (_head == null) return false; // list is empty
            if (_head.Data == value)  // value is at the head
            {
                _head = _head.Next; // remove head
                return true;
            }
            Element? current = _head; // start from the head
            while (current.Next != null) // follow the list
            {
                if (current.Next.Data == value) // value found
                {
                    current.Next = current.Next.Next; // remove the element
                    return true; // value found and removed
                }
                current = current.Next; // move to the next element
            }
            return false; // value not found
        }

        // copy contents - copy the contents of this list to another list
        public void CopyContents(LinkedList targetList)
        {
            targetList._head = null; // clear the target list
            if (targetList._head == null) // if the target list is empty
            {
                targetList._head = _head; // copy old head to new head
                return; // source list is empty
            }
            Element? current = _head; // start from the head
            Element? lastCopied = null; // keep track of the last copied element
            while (current != null) // follow the list
            {
                if (lastCopied == null) // if this is the first element
                {

                    
                }
            }
        }





    }

    internal class MonLectureW3S1
    {
        static void Main(string[] args)
        {
            LinkedList MyList = new LinkedList();
            MyList.PushFront(5);
            MyList.PushFront(2);
            MyList.PushFront(3);
            MyList.PrintList();
            MyList.PopFront();
            MyList.Contains(5);
            MyList.PrintList();
            if (MyList.Contains(3))
            {
                Console.WriteLine("3 is in the list");
            }
            else
            { 
                Console.WriteLine("3 is not in the list");
            }
            MyList.Count();
            MyList.RemoveValue(5);


        }
    }
}