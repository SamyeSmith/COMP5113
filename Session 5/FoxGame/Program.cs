namespace FoxGame
{
    // Enum representing the items involved in the puzzle
    public enum Item
    {
        Fox,
        Chicken,
        Grain
    }

    // Enum representing the two sides of the river
    public enum RiverBank
    {
        North,
        South
    }

    // Node class for the custom linked list
    public class Node
    {
        public Item Data;     // Stores the item
        public Node Next;     // Pointer to the next node

        public Node(Item data)
        {
            Data = data;
            Next = null;
        }
    }

    // Custom singly linked list to hold items on each bank
    public class LinkedList
    {
        private Node head;    // Head of the list

        // Adds a new item to the front of the list
        public void Add(Item item)
        {
            Node newNode = new Node(item);
            newNode.Next = head;
            head = newNode;
        }

        // Removes an item from the list
        public bool Remove(Item item)
        {
            Node current = head, prev = null;
            while (current != null)
            {
                if (current.Data == item)
                {
                    if (prev == null)
                        head = current.Next;
                    else
                        prev.Next = current.Next;
                    return true;
                }
                prev = current;
                current = current.Next;
            }
            return false;
        }

        // Checks if the list contains a specific item
        public bool Contains(Item item)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == item)
                    return true;
                current = current.Next;
            }
            return false;
        }

        // Clears the list
        public void Clear()
        {
            head = null;
        }

        // Returns the number of items in the list
        public int Count()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        // Prints the items in the list
        public void PrintList()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        // Checks if both items are present in the list
        public bool Has(Item a, Item b)
        {
            return Contains(a) && Contains(b);
        }
    }

    // Main game class
    public class CGame
    {
        private LinkedList _northItems = new LinkedList(); // Items on the north bank
        private LinkedList _southItems = new LinkedList(); // Items on the south bank
        private RiverBank _farmerLocation;                 // Farmer's current location

        public CGame()
        {
            Reset(); // Initialize game state
        }

        // Displays game instructions
        public void DisplayInstructions()
        {
            Console.WriteLine("=== Fox, Chicken, and Grain Game ===");
            Console.WriteLine("Help the farmer get all items to the north bank.");
            Console.WriteLine("Rules:");
            Console.WriteLine("- Only one item can be taken at a time.");
            Console.WriteLine("- Fox eats chicken if left alone.");
            Console.WriteLine("- Chicken eats grain if left alone.");
            Console.WriteLine("Type: fox, chicken, grain or nothing to move.");
            Console.WriteLine("=====================================");
        }

        // Displays the current state of both banks and the farmer's location
        public void DisplayBanks()
        {
            Console.WriteLine($"\nFarmer is on the {_farmerLocation} bank.");
            Console.Write("North bank: ");
            _northItems.PrintList();
            Console.Write("South bank: ");
            _southItems.PrintList();
            Console.WriteLine();
        }

        // Checks if the game is won
        public bool IsWon()
        {
            if (_northItems.Count() == 3)
            {
                Console.WriteLine("You won! All items are safe on the north bank.");
                return true;
            }
            return false;
        }

        // Checks if the game is lost due to unsafe item combinations
        public bool IsLost(LinkedList withoutFarmer)
        {
            if (withoutFarmer.Has(Item.Fox, Item.Chicken))
            {
                Console.WriteLine("The fox ate the chicken! Game over.");
                return true;
            }
            if (withoutFarmer.Has(Item.Chicken, Item.Grain))
            {
                Console.WriteLine("The chicken ate the grain! Game over.");
                return true;
            }
            return false;
        }

        // Determines if the game is still ongoing
        public bool IsPlaying()
        {
            bool lost = _farmerLocation == RiverBank.South
                ? IsLost(_northItems)
                : IsLost(_southItems);
            bool won = IsWon();
            return !lost && !won;
        }

        // Handles transporting an item across the river
        public void TransportItem(LinkedList fromBank, LinkedList toBank)
        {
            Console.Write("What will the farmer take (fox/chicken/grain/nothing)? ");
            string input = Console.ReadLine().Trim().ToLower();

            // Try to parse input and move item if valid
            if (Enum.TryParse(typeof(Item), input, true, out object result) && fromBank.Contains((Item)result))
            {
                fromBank.Remove((Item)result);
                toBank.Add((Item)result);
                Console.WriteLine($"Farmer took {result} across the river.");
            }
            else
            {
                Console.WriteLine("Farmer crosses alone.");
            }

            // Toggle farmer's location
            _farmerLocation = _farmerLocation == RiverBank.South ? RiverBank.North : RiverBank.South;
        }

        // Resets the game to its initial state
        public void Reset()
        {
            _northItems.Clear();
            _southItems.Clear();
            _southItems.Add(Item.Fox);
            _southItems.Add(Item.Chicken);
            _southItems.Add(Item.Grain);
            _farmerLocation = RiverBank.South;
        }

        // Main game loop
        public void Play()
        {
            Reset();
            DisplayBanks();

            while (IsPlaying())
            {
                if (_farmerLocation == RiverBank.South)
                    TransportItem(_southItems, _northItems);
                else
                    TransportItem(_northItems, _southItems);

                DisplayBanks();
            }
        }
    }

    // Entry point of the program
    class Program
    {
        static void Main(string[] args)
        {
            CGame game = new CGame();
            game.DisplayInstructions();

            // Loop to allow replaying the game
            do
            {
                game.Play();
                Console.Write("Play again? (y/n): ");
            } while (Console.ReadLine().Trim().ToLower() == "y");

            Console.WriteLine("Thanks for playing!");
        }
    }
}
