using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_6
{
    internal class GenericList
    {
        private Element? _head;
        public GenericList()
        {
            _head = null;
        }
        // use type parameter T
        // method to add coordinates to the list at the end
        public void Add<T>(T data) // generic method uing type parameter T
        {
            Element newElement = new Element(data.GetHashCode());// using GetHashCode to convert T to int
            if (_head == null)// if list is empty
            {
                _head = newElement;// set head to new element
            }
            else// if list is not empty
            {
                Element current = _head;// start at head
                while (current.Next != null)// traverse to the end of the list
                {
                    current = current.Next;// move to next element
                }
                current.Next = newElement;// add new element at the end
            }
        }

    }
}
