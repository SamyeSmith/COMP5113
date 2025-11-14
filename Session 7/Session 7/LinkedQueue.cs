namespace Session_7
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
        public class LinkedQueue : OperationsCounter
        {
            private Element? _head;

        // Constructor - initialises an empty list
        public LinkedQueue()
            {
                _head = null;
            }

            // IsEmpty - returns true only when the list is empty
            public bool IsEmpty()
            {
            IncrementOPS();
            return _head == null;
            }

            // PushFront - add a new element at the head of the list
            public void PushFront(int data)
            {
            IncrementOPS();
            // create the new element from the data supplied
            Element newElement = new Element(data);

                // make new element's next the current head
                newElement.Next = _head;

                // make the new element the head of the list
                _head = newElement;
            }

            // PushBack - add a new element at the end of the list
            public void Enqueue(int data)
            {
            IncrementOPS();
            // create the new element from the data supplied
            Element newElement = new Element(data);
                if (_head == null) // list is empty
                {
                    _head = newElement; // new element is now the head
                }
                else // list is not empty
                {
                    Element currentElement = _head; // start at the head
                                                    // walk to the end of the list
                    while (currentElement.Next != null)
                    {
                        currentElement = currentElement.Next;
                    }
                    // link the new element at the end of the list
                    currentElement.Next = newElement;
                }
            }

            // PopFront - remove an element from the front of the list
            public void Dequeue()
            {
            IncrementOPS();
            // popping from an empty list is not illegal, it just has no effect
            if (_head != null)
                {
                    _head = _head.Next;
                }
            }

            // GetFront - provide the data stored in the front element, if the list is not empty
            //            note that data is "returned" through the reference parameter
            //            the bool returned indicates success or otherwise
            public bool Peek(ref int data)
            {
            IncrementOPS();
            if (!IsEmpty())
                {
                    data = _head.Data;
                }
                return !IsEmpty();
            }

            // PrintList - display the list contents on the console
            public void PrintList()
            {
            IncrementOPS();
            Element? currentElement = _head; // an element reference to "walk" along the list

                while (currentElement != null)
                {
                    Console.Write(currentElement.Data + ", ");
                    currentElement = currentElement.Next;
                }

                Console.Write("\b\b \b"); // over-write the comma after the last element with a space, then back the cursor up.
            }


            // Contains - returns true when data is contained in the list
            public bool Contains(int data)
            {
            IncrementOPS();
            Element? currentElement = _head;
                bool found = false;

                while (currentElement != null && !found) // stop when we have either reached the end, or found what we're looking for
                {
                    if (currentElement.Data == data)
                    {
                        found = true; // flag when we gave found the element
                    }
                    currentElement = currentElement.Next;
                }

                return found;
            }

            // RemoveFirst - removes the first occurrance of data from the list
            public void RemoveFirst(int data)
            {
            IncrementOPS();
            if (_head != null && _head.Data == data) // data is the first element in the list
                {
                    _head = _head.Next; // the same as PopFront
                }
                else
                {
                    Element? currentElement = _head;
                    Element? previousElement = _head;

                    bool found = false;
                    // find element to remove if it exists
                    while (currentElement != null && !found)
                    {
                        if (currentElement.Data == data)
                        {
                            found = true;
                        }
                        else
                        {
                            // move the references along...
                            previousElement = currentElement;
                            currentElement = currentElement.Next;
                        }
                    }

                    // If the data is found, we know current is pointing to it.
                    // Also, it is not the first element, so we know previous must be
                    // pointing to the element before.

                    // remove the data if we found it
                    if (found)
                    {
                        previousElement.Next = currentElement.Next;
                    }
                }
            }
            // Length - returns the number of elements in the list
            public int Length()
            {
            IncrementOPS();
            int count = 0;
                Element? currentElement = _head;
                while (currentElement != null)
                {
                    count++;
                    currentElement = currentElement.Next;
                }
            return count;

            }







        }

    }

