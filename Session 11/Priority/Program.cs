using System;
namespace Session_11
{
    // ---------------------------
    // Element node
    // ---------------------------
    public class Element
    {
        public object Data { get; set; }
        public Element? Next { get; set; }
        public Element(object data)
        {
            Data = data;
            Next = null;
        }
    }
    // ---------------------------
    // Operation Counter
    // ---------------------------
    static class Ops
    {
        public static long Count;
        public static void Reset() => Count = 0;
    }
    // ---------------------------
    // Linked List
    // ---------------------------
    public class LinkedList
    {
        private Element? _head;
        private Element? _tail;
        private int _count;
        public int Count => _count;
        public bool IsEmpty => _head == null;
        public void PushFront(object data)
        {
            Element newElem = new Element(data) { Next = _head };
            _head = newElem;
            if (_tail == null) _tail = newElem;
            _count++;
        }
        public void PushBack(object data)
        {
            Element newElem = new Element(data);
            if (_tail != null) _tail.Next = newElem;
            else _head = newElem;
            _tail = newElem;
            _count++;
        }
        public object PopFront()
        {
            if (_head == null) throw new InvalidOperationException("List is empty");
            object data = _head.Data;
            _head = _head.Next;
            if (_head == null) _tail = null;
            _count--;
            return data;
        }
        public bool Contains(object data)
        {
            Element? current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }
        public void Clear() { _head = _tail = null; _count = 0; }
        public void PrintList()
        {
            Element? current = _head;
            while (current != null)
            {
                Console.Write(current.Data + (current.Next != null ? ", " : ""));
                current = current.Next;
            }
            Console.WriteLine();
        }
        // ---------------------------
        // DFS with depth limit and predecessor tracking
        // ---------------------------
        public void DepthFirstSearch(int depthLimit = 10)
        {
            if (_head == null)
            {
                Console.WriteLine("DFS: LinkedList is empty.");
                return;
            }
            LinkedList stack = new LinkedList(); // Open list
            LinkedList closed = new LinkedList(); // Closed list
            SearchNode startNode = new SearchNode(_head.Data);
            stack.PushFront(startNode);
            Console.WriteLine("DFS Traversal with Depth Limit:");
            while (!stack.IsEmpty)
            {
                SearchNode currentNode = (SearchNode)stack.PopFront();
                if (closed.Contains(currentNode.Value)) continue;
                Console.WriteLine($"Visiting: {currentNode.Value}, Depth: {currentNode.Depth}");
                closed.PushBack(currentNode.Value);
                if (currentNode.Depth >= depthLimit) continue;
                // Push neighbors (other linked list nodes)
                Element? node = _head;
                while (node != null)
                {
                    if (!node.Data.Equals(currentNode.Value) &&
                      !closed.Contains(node.Data) &&
                      !stack.Contains(node.Data))
                    {
                        stack.PushFront(new SearchNode(node.Data, currentNode, currentNode.Depth + 1));
                    }
                    node = node.Next;
                }
            }
            Console.WriteLine("DFS complete.\n");
        }
    }
    // ---------------------------
    // BFS Grid Search Node
    // ---------------------------
    public class SearchNode
    {
        public object Value { get; set; }
        public SearchNode? Predecessor { get; set; }
        public int Depth { get; set; }
        public SearchNode(object value, SearchNode? predecessor = null, int depth = 0)
        {
            Value = value;
            Predecessor = predecessor;
            Depth = depth;
        }
    }
    // ---------------------------
    // Linked Queue
    // ---------------------------
    public class LinkedQueue
    {
        private Element? _head;
        private Element? _tail;
        public bool IsEmpty => _head == null;
        public void Enqueue(object data)
        {
            Element newElem = new Element(data);
            if (_tail != null) _tail.Next = newElem;
            else _head = newElem;
            _tail = newElem;
            Ops.Count++;
        }
        public object Dequeue()
        {
            if (_head == null) throw new InvalidOperationException("Queue is empty");
            object data = _head.Data;
            _head = _head.Next;
            if (_head == null) _tail = null;
            Ops.Count++;
            return data;
        }
        public bool Contains(object data)
        {
            Element? current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data)) return true;
                current = current.Next;
            }
            return false;
        }
    }
    // ---------------------------
    // BFS Grid Search
    // ---------------------------
    public static class GridSearch
    {
        private static int[,] grid = new int[5, 5]
        {
      {0, 0, 1, 0, 0},
      {0, 1, 0, 0, 0},
      {0, 0, 0, 1, 0},
      {1, 0, 0, 0, 0},
      {0, 0, 0, 0, 0}
        };
        private static (int x, int y) start = (0, 0);
        private static (int x, int y) goal = (4, 4);
        private static (int dx, int dy)[] directions = new (int, int)[]
        {
      (-1,0), (1,0), (0,1), (0,-1)
        };
        public static void BreadthFirstSearch(int depthLimit = 10)
        {
            LinkedQueue openList = new LinkedQueue();
            LinkedQueue closedList = new LinkedQueue();
            SearchNode startNode = new SearchNode(start.x * 10 + start.y, null, 0);
            openList.Enqueue(startNode);
            Console.WriteLine("BFS Traversal with Depth Limit:");
            while (!openList.IsEmpty)
            {
                SearchNode currentNode = (SearchNode)openList.Dequeue();
                int currentVal = (int)currentNode.Value;
                int cx = currentVal / 10;
                int cy = currentVal % 10;
                if (closedList.Contains(currentNode.Value)) continue;
                Console.WriteLine($"Visiting: ({cx},{cy}), Depth: {currentNode.Depth}");
                closedList.Enqueue(currentNode.Value);
                if (currentNode.Depth >= depthLimit) continue;
                foreach (var (dx, dy) in directions)
                {
                    int nx = cx + dx;
                    int ny = cy + dy;
                    int encoded = nx * 10 + ny;
                    if (nx < 0 || nx >= 5 || ny < 0 || ny >= 5) continue;
                    if (grid[nx, ny] == 1) continue;
                    if (closedList.Contains(encoded) || openList.Contains(encoded)) continue;
                    openList.Enqueue(new SearchNode(encoded, currentNode, currentNode.Depth + 1));
                }
            }
            Console.WriteLine("BFS complete.\n");
        }
    }
    // ---------------------------
    // Main Program
    // ---------------------------
    public static class Program
    {
        public static void Main()
        {
            // ---------------------------
            // DFS on linked list
            // ---------------------------
            LinkedList list = new LinkedList();
            list.PushBack(1);
            list.PushBack(2);
            list.PushBack(3);
            list.PushBack(4);
            list.PushBack(5);
            Console.WriteLine("Initial LinkedList:");
            list.PrintList();
            list.DepthFirstSearch(depthLimit: 3); // example depth limit
            // ---------------------------
            // BFS on grid
            // ---------------------------
            GridSearch.BreadthFirstSearch(depthLimit: 10); // example depth limit
        }
    }
}