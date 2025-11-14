using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_7
{
    public class OperationsCounter
    {
        private int _Count;

        public OperationsCounter()
        { 
            _Count = 0; 
        }

        public void IncrementOPS()
        {
            _Count++;
        }

        public int GetOPSCount()
        {
            return _Count;
        }

        public void SetOPSCount(int count) 
        {
                        _Count = count;
        }

        public void ResetOPSCount()
        {
            _Count = 0;
        }

        public void DisplayOPSCount()
        {
            Console.WriteLine($"Operations Count: {_Count}");
        }

       


    }
}
