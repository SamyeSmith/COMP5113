using System.Runtime.InteropServices;

namespace Session_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Counter class.
            Counter counter = new Counter();
            // Call the PrintAmount method to display the value of amount.
            counter.PrintAmount();
            // Call the IncrementAmount method to increment the value of amount to 10 using loops.
            for (int i= 0; i < 4;i ++)
            {
                counter.IncrementAmount();
            }
            counter.PrintAmount();
            // Call the DecrementAmount method to decrement the value of amount to 7 using loops.
            for (int i = 0; i < 3; i++)
            {
                counter.DecreaseAmount();
            }
            counter.PrintAmount();
            counter.SetAmountToTop();
            counter.ResetAmount();
            counter.PrintAmount();
            counter.PrintAndIncrease();





        }
    }
}