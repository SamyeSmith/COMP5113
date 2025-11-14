
namespace  3_SearchAlgorithms
{
    public class Element
    {
        public object Data { get; set; }
        public Element? Next { get; set; }
        public Element(object data) { Data = data; Next = null; }
    }

    static class Ops { public static long Count; public static void Reset() => Count = 0; }

    public class LinkedList
    {
        private Element? _head, _tail; private int _count;
        public bool IsEmpty => _head == null;
        public void PushFront(object data) { Element e = new Element(data) { Next = _head }; _head = e; if (_tail == null) _tail = e; _count++; }
        public void PushBack(object data) { Element e = new Element(data); if (_tail != null) _tail.Next = e; else _head = e; _tail = e; _count++; }
        public object PopFront() { if (_head == null) throw new InvalidOperationException(); object d = _head.Data; _head = _head.Next; if (_head == null) _tail = null; _count--; return d; }
        public bool Contains(object data) { Element? c = _head; while (c != null) { if (c.Data.Equals(data)) return true; c = c.Next; } return false; }
        public void PrintList() { Element? c = _head; while (c != null) { Console.Write(c.Data + (c.Next != null ? ", " : "")); c = c.Next; } Console.WriteLine(); }

        public void DepthFirstSearch(int depthLimit = 10)
        {
            if (_head == null) return;
            LinkedList stack = new LinkedList(), closed = new LinkedList();
            stack.PushFront(new SearchNode(_head.Data));
            Console.WriteLine("DFS:");
            while (!stack.IsEmpty)
            {
                SearchNode cur = (SearchNode)stack.PopFront();
                if (closed.Contains(cur.Value)) continue;
                Console.WriteLine($"Visiting: {cur.Value}, Depth: {cur.Depth}");
                closed.PushBack(cur.Value);
                if (cur.Depth >= depthLimit) continue;
                Element? n = _head;
                while (n != null)
                {
                    if (!n.Data.Equals(cur.Value) && !closed.Contains(n.Data) && !stack.Contains(n.Data))
                        stack.PushFront(new SearchNode(n.Data, cur, cur.Depth + 1));
                    n = n.Next;
                }
            }
            Console.WriteLine("DFS complete.\n");
        }
    }

    public class SearchNode
    {
        public object Value { get; set; }
        public SearchNode? Predecessor { get; set; }
        public int Depth { get; set; }
        public SearchNode(object v, SearchNode? p = null, int d = 0) { Value = v; Predecessor = p; Depth = d; }
    }

    public class LinkedQueue
    {
        private Element? _head, _tail;
        public bool IsEmpty => _head == null;
        public void Enqueue(object d) { Element e = new Element(d); if (_tail != null) _tail.Next = e; else _head = e; _tail = e; Ops.Count++; }
        public object Dequeue() { if (_head == null) throw new InvalidOperationException(); object d = _head.Data; _head = _head.Next; if (_head == null) _tail = null; Ops.Count++; return d; }
        public bool Contains(object d) { Element? c = _head; while (c != null) { if (c.Data.Equals(d)) return true; c = c.Next; } return false; }
    }

    public static class GridSearch
    {
        private static int[,] grid = new int[5, 5]
        {
            {0,0,1,0,0},
            {0,1,0,0,0},
            {0,0,0,1,0},
            {1,0,0,0,0},
            {0,0,0,0,0}
        };
        private static (int x, int y) start = (0, 0), goal = (4, 4);
        private static (int dx, int dy)[] dirs = { (-1, 0), (1, 0), (0, 1), (0, -1) };

        public static void BreadthFirstSearch(int depthLimit = 10)
        {
            LinkedQueue open = new LinkedQueue(), closed = new LinkedQueue();
            open.Enqueue(new SearchNode(start.x * 10 + start.y, null, 0));
            Console.WriteLine("BFS:");
            while (!open.IsEmpty)
            {
                SearchNode cur = (SearchNode)open.Dequeue();
                int val = (int)cur.Value, cx = val / 10, cy = val % 10;
                if (closed.Contains(cur.Value)) continue;
                Console.WriteLine($"Visiting: ({cx},{cy}), Depth: {cur.Depth}");
                closed.Enqueue(cur.Value);
                if (cur.Depth >= depthLimit) continue;
                foreach (var (dx, dy) in dirs)
                {
                    int nx = cx + dx, ny = cy + dy, enc = nx * 10 + ny;
                    if (nx < 0 || nx >= 5 || ny < 0 || ny >= 5) continue;
                    if (grid[nx, ny] == 1) continue;
                    if (closed.Contains(enc) || open.Contains(enc)) continue;
                    open.Enqueue(new SearchNode(enc, cur, cur.Depth + 1));
                }
            }
            Console.WriteLine("BFS complete.\n");
        }

        public static void HillClimbingSearch()
        {
            int rows = grid.GetLength(0), cols = grid.GetLength(1);
            int x = start.x, y = start.y;
            Console.WriteLine("Hill Climbing:");
            while (true)
            {
                int h = Math.Abs(x - goal.x) + Math.Abs(y - goal.y);
                Console.WriteLine($"Current: ({x},{y}), h={h}");
                if (x == goal.x && y == goal.y) { Console.WriteLine("Goal reached!"); break; }
                List<(int nx, int ny, int h)> neigh = new();
                foreach (var (dx, dy) in dirs)
                {
                    int nx = x + dx, ny = y + dy;
                    if (nx < 0 || nx >= rows || ny < 0 || ny >= cols) continue;
                    if (grid[nx, ny] == 1) continue;
                    int nh = Math.Abs(nx - goal.x) + Math.Abs(ny - goal.y);
                    neigh.Add((nx, ny, nh));
                }
                var best = (x, y, h);
                foreach (var n in neigh) if (n.h < best.Item3) best = n;
                if (best.Item1 == x && best.Item2 == y) { Console.WriteLine("Stuck at local minimum!"); break; }
                x = best.Item1; y = best.Item2;
            }
            Console.WriteLine("Hill Climbing complete.\n");
        }
    }

    public static class Program
    {
        public static void Main()
        {
            LinkedList list = new LinkedList();
            list.PushBack(1); list.PushBack(2); list.PushBack(3); list.PushBack(4); list.PushBack(5);
            Console.WriteLine("Initial LinkedList:"); list.PrintList();
            list.DepthFirstSearch(3);
            GridSearch.BreadthFirstSearch(10);
            GridSearch.HillClimbingSearch();
        }
    }
}