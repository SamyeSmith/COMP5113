namespace Priority_Queue
{
public static class Program
{
        public static void Main()
        {


            // Create a new linked list
            LinkedList list = new LinkedList();
            // Create a queue wrapper around the linked list
            Queue queue = new Queue();

            // Check if the list is initially empty
            Console.WriteLine("Initial list (should be empty):   ");
            list.PrintList(); // Expected output: null


            // Push elements to the front of the list
            list.PushFront(10);
            list.PushFront(20);
            list.PushFront(30);
            Console.WriteLine("List after pushing 30, 20, 10 to front:   ");
            list.PrintList(); // Expected output: 30 -> 20 -> 10 -> null

            // Dequeue an element from the front
            Console.WriteLine("");
            list.Enqueue(5);
            Console.WriteLine("List after enqueueing 5:    ");
            list.PrintList(); // Expected output: 30 -> 20 -> 10 -> 5 -> null


            // Dequeue an element from the front
            Console.WriteLine("");
            list.Dequeue(); // Removes 30
            Console.WriteLine("list after dequeing:    ");
            list.PrintList(); // Expected output: 20 -> 10 -> 5 -> null
            Console.WriteLine("");


            // Priority Enqueue an element
            Console.WriteLine("List after priority enqueueing 25:    ");
            list.PriorityEnqueue(25); // Inserts 25 in the correct position
            list.PrintList(); // Expected output: 25 -> 20 -> 10 -> 5 -> null


            // Using wrappers to differentiate between lists
            Console.WriteLine("");
            Console.WriteLine("Using Queue A:      "); // New linked list instance
            Queue queueA = new Queue(); // New queue instance
                queueA.Enqueue(15); // Enqueue 15
                queueA.Enqueue(25); // Enqueue 25
                Console.WriteLine("Dequeue from Queue A: " + queueA.Dequeue()); // Expected output: 15
                Console.WriteLine("");

            // Using another queue instance
            Console.WriteLine("Using Queue B:      "); // Another new linked list instance
            Queue queueB = new Queue(); // New queue instance
                queueB.Enqueue(35); // Enqueue 35
                queueB.Enqueue(45); // Enqueue 45
                Console.WriteLine("Dequeue from Queue B: " + queueB.Dequeue()); // Expected output: 35
                Console.WriteLine("");


            // Best-First Search Example
                var bfs = new BestFirstSearch();

                List<int> path = bfs.Search(
                    start: 1,
                    isGoal: state => state == 10,
                    getNeighbors: state => new List<int> { state + 1, state + 2 },
                    heuristic: state => 10 - state // closer to 10 = lower heuristic
                );

                Console.WriteLine("Path found:");
                foreach (int step in path)
                {
                    Console.Write(step + " ");
                }
            }
        }

    }
