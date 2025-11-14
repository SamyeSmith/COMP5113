namespace Session_7
{
    internal class Program : OperationsCounter
    {
        static void Main(string[] args)
        {
            // Create a new LinkedQueue
            LinkedQueue myQueue = new LinkedQueue();
            // Start the stopwatch
            var watch = System.Diagnostics.Stopwatch.StartNew();


            // Enqueue some elements
            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.PrintList();
            Console.WriteLine("" +
            "" +
            "");
            myQueue.Enqueue(30);
            myQueue.PrintList();
            Console.WriteLine("" +
                "" +
                "");
            // Dequeue an element
            myQueue.Dequeue();
            myQueue.PrintList();
            Console.WriteLine("" +
                "" +
                "");
            // Display the operations count
            myQueue.DisplayOPSCount();
            myQueue.PrintList();
            Console.WriteLine("" +
                 "" +
                 "");
            myQueue.Dequeue();
            myQueue.PrintList();
            Console.WriteLine("" +
                "" +
                "");
            myQueue.DisplayOPSCount();


            // Stop the stopwatch
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            // Display the elapsed time
            Console.WriteLine($"Elapsed Time: {elapsedMs} ms");
        }



    }
}
