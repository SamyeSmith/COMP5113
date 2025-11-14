using System;
using System.Collections.Generic;

public class Node : IComparable<Node>
{
    public int State { get; set; }
    public Node? Parent { get; set; }
    public int Heuristic { get; set; }

    public Node(int state, Node? parent, int heuristic)
    {
        State = state;
        Parent = parent;
        Heuristic = heuristic;
    }

    public int CompareTo(Node? other)
    {
        if (other == null) return 1;
        int compare = Heuristic.CompareTo(other.Heuristic);
        return compare == 0 ? State.CompareTo(other.State) : compare;
    }
}

public class BestFirstSearch
{
    public List<int> Search(
        int start,
        Func<int, bool> isGoal,
        Func<int, List<int>> getNeighbors,
        Func<int, int> heuristic)
    {
        var openList = new SortedSet<Node>();
        var closedList = new HashSet<int>();

        var startNode = new Node(start, null, heuristic(start));
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node current = openList.Min;
            openList.Remove(current);

            if (isGoal(current.State))
                return ConstructPath(current);

            closedList.Add(current.State);

            foreach (int neighbor in getNeighbors(current.State))
            {
                if (!closedList.Contains(neighbor))
                {
                    var neighborNode = new Node(neighbor, current, heuristic(neighbor));
                    openList.Add(neighborNode);
                }
            }
        }

        return new List<int>(); // Failure
    }

    private List<int> ConstructPath(Node node)
    {
        var path = new List<int>();
        while (node != null)
        {
            path.Add(node.State);
            node = node.Parent;
        }
        path.Reverse();
        return path;
    }
}
