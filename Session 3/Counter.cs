using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_3
{
    internal class Counter
    {
        // Create a public integer field named amount.
        public int amount;

        // make a property called Amount with a getter and setter for the amount field.
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        // Create a constructor for the Counter class that initializes the amount field and set its value to 49 by default.
        public Counter()
        {
            amount = 6;
        }

        // Make new data type called top with a value of 100.
        public int top ;

        // Create a public method named PrintAmount that prints the value of amount to the console.
        public void PrintAmount()
        {
            Console.WriteLine(amount);
            Console.WriteLine(top);
        }

        // Create a method that sets top as the value of amount.
        public void SetAmountToTop()
        {
            top = amount;

        }

        // Create a method to print a sentence and increase amount by 1.
        public void PrintAndIncrease()
        {
            Console.WriteLine("The amount is: " + amount);
            amount++;
            Console.WriteLine("An Object is an Instance of a Class");
        }


        // Create a method that resets the amount to 0.
        public void ResetAmount()
        {
            amount = 0;
        }

        // crate a public method that calls the constructor and prints the value of amount to the console.
        public void CallConstructorAndPrint()
        {
            Counter counter = new Counter();
            counter.PrintAmount();
        }
        // Create a public method named IncrementAmount that increments the value of amount by 1.
        public void IncrementAmount()
        {
            amount++;
        }

        // Create a public method named DecrementAmount that decrements the value of amount by 1.
        public void DecreaseAmount()
        {
            amount--;
        }
    }
}