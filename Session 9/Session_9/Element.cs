using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_9
{


    public class Element
    {
        private int _data;
        private Element? _next;
        private Element _head;

        public Element(int data) { _data = data; }
        public int Data { get { return _data; } }

        public Element? Next
        {
            get { return _next; }
            set { _next = value; }
        }


        private Element RoutineA(int val, Element list)
        {
            if (list == null)
            {
                return new Element(val);
            }
            else if (list.Data >= val)
            {
                Element newElem = new Element(val);
                newElem.Next = list;
                return newElem;
            }
            else
            {
                list.Next = RoutineA(val, list.Next);
                return list;
            }
        }
        private Element RoutineB(int val, Element list)
        {
            if (list == null)
            {
                return null;
            }
            else if (list.Data == val)
            {
                return list.Next;
            }
            else
            {
                list.Next = RoutineB(val, list.Next);
                return list;
            }
        }
        private Element RoutineC(int val, Element list)
        {
            if (list == null)
            {
                return null;
            }
            else if (list.Data == val)
            {
                return RoutineC(val, list.Next);
            }
            else
            {
                list.Next = RoutineC(val, list.Next);
                return list;
            }
        }
        // Wrapper methods to call the routines from outside the class
        public void CallRoutineA(int val)
        {
            _head = RoutineA(val, _head);
        }
        public void CallRoutineB(int val)
        {
            _head = RoutineB(val, _head);
        }
        public void CallRoutineC(int val)
        {
            _head = RoutineC(val, _head);
        }
    }
}
