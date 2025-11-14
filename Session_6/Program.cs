namespace Session_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
           LinkedList list = new LinkedList();
              list.Add(10);
              list.Add(20);
              list.Add(30);
              Console.WriteLine("Linked List contents:");
              list.PrintList();
              Console.WriteLine("Removing 20 from the list.");
              list.Remove(20);
              Console.WriteLine("Linked List contents after removal:");
              list.PrintList();
            Console.WriteLine(
                "Press any key to exit...");
            Console.ReadKey();
        }
    }
}
