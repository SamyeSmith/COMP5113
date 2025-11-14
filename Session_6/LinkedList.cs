using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_6
{
    public class LinkedList
    {
        private Element? _head;
        public LinkedList()
        {
            _head = null;
        }
        public void Add(int data)
        {
            Element newElement = new Element(data);
            if (_head == null)
            {
                _head = newElement;
            }
            else
            {
                Element current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newElement;
            }
        }
        public void PrintList()
        {
            Element? current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        //remove value
        public void Remove(int data)
        {
            if (_head == null) return;
            if (_head.Data == data)
            {
                _head = _head.Next;
                return;
            }
            Element? current = _head;
            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }
        }

        //Counting method
        public int Count()
        {
            int count = 0;
            Element? current = _head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        //get element at index
        public Element? GetElementAt(int index)
        {
            if (index < 0) return null;
            Element? current = _head;
            int currentIndex = 0;
            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current;
                }
                currentIndex++;
                current = current.Next;
            }
            return null;

        }

        //pop front
        public void PopFront()
        {
            if (_head == null) return;
            _head = _head.Next;
        }
    }
}
