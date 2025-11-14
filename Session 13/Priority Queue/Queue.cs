using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queue
{
    public class Queue
    {
            private Element? _head;

            // Constructor - initialises an empty list
            public Queue()
            {
                _head = null;
            }

            // IsEmpty - returns true only when the list is empty
            public bool IsEmpty()
            {
                return _head == null;
            }


            // PrintList - display the list contents on the console
            public void PrintList()
            {
                Element? currentElement = _head; // an element reference to "walk" along the list

                while (currentElement != null)
                {
                    Console.Write(currentElement.Data + ", ");
                    currentElement = currentElement.Next;
                }

                Console.Write("\b\b \b"); // over-write the comma after the last element with a space, then back the cursor up.
            }
           
            // Enqueue - add a new element at the end of the list
            public void Enqueue(int data)
            {
                Element newElement = new Element(data);
                if (_head == null)
                {
                    _head = newElement;
                }
                else
                {
                    Element? currentElement = _head;
                    while (currentElement.Next != null)
                    {
                        currentElement = currentElement.Next;
                    }
                    currentElement.Next = newElement;
                }
            }
            // Dequeue - remove an element from the front of the list and return its data
            public int? Dequeue()
            {
                if (_head == null)
                {
                    return null; // List is empty
                }
                else
                {
                    int data = _head.Data;
                    _head = _head.Next;
                    return data;
                }
            }
            // PriorityEnqueue - add a new elemet at the correct position based on priority (higher value = higher priority)
            public void PriorityEnqueue(int data)
            {
                Element newElement = new Element(data);
                if (_head == null || _head.Data < data)
                {
                    newElement.Next = _head;
                    _head = newElement;
                }
                else
                {
                    Element? currentElement = _head;
                    while (currentElement.Next != null && currentElement.Next.Data >= data)
                    {
                        currentElement = currentElement.Next;
                    }
                    newElement.Next = currentElement.Next;
                    currentElement.Next = newElement;
                }
            }
        }
    }