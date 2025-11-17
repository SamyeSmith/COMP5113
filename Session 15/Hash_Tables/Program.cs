using System.Collections;

namespace Hash_Tables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable hashTable = new Hashtable(12);
            hashTable.Store("fred", 34);
            hashTable.Store("john", 83);
            hashTable.Store("paul", 98);
            hashTable.Store("susan", 19);
            hashTable.Store("jane", 94);
            hashTable.Store("lucy", 74);


            Console.WriteLine("Open Address hash table");
        }
    }
}

