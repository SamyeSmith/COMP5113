using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadth_Search
{
    //public class Element
    //{
    //    private int _data;
    //    private Element? _next;

    //    public Element(int data) { _data = data; }
    //    public int Data { get { return _data; } }

    //    public Element? Next
    //    {
    //        get { return _next; }
    //        set { _next = value; }
    //    }
    //}
    public class Element<T>
    {
        private int _data;
        private Element<T>? _next;

        public Element(int data) { _data = data; }
        public int Data { get { return _data; } }

        public Element<T>? Next
        {
            get { return _next; }
            set { _next = value; }
        }
    }

}
