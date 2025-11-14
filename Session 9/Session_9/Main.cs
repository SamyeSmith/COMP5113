using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Session_9
{
    public class Program
    {
        private static Element _head;

        // Change the static Main method to create an instance of Program and call PrintList() on that instance.
        static void Main(string[] args)
        {
            Element Elm = new Element(10);
            LinkedList list = new LinkedList();
            Program Program = new Program();
            list.Add(5);
            list.Add(10);
            list.Add(15);
            list.PrintList();
            Console.WriteLine("Removing 10:");
            list.Remove(10);
            list.PrintList();
            Console.WriteLine("Using routines:");
            Elm.CallRoutineB(10);
            list.PrintList();
            Elm.CallRoutineC(15);
            list.PrintList();
            Elm.CallRoutineA(12);
            Program.PrintListA();
            Program.PrintListInverse();

        }
        private void PrintA(Element list)
        {
            if (list != null)
            {
                Console.Write(list.Data + ", ");
                PrintA(list.Next);
            }
        }
        private void PrintB(Element list)//Print list in inverse order
        {
            if (list != null)
            {
                PrintB(list.Next);
                Console.Write(list.Data + ", ");
            }
        }
        public void PrintListA()
        {
            PrintA(_head);
            Console.Write("\b\b \b"); // get rid of the trailing comma
        }

        public void PrintListInverse()
        {
            PrintB(_head);
            Console.Write("\b\b \b"); // get rid of the trailing comma
        }


    }
}
