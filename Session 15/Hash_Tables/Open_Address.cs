using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Tables
{

    internal class Hashtable
    {
        private struct Data
        {
            public string name;
            public int grade;

            public Data(string name, int grade)
            {
                this.name = name;
                this.grade = grade;
            }
        }

        private Data[] theTable;

        private int size = 12;

        public Hashtable(int newSize)
        {
           this.size = newSize;
            theTable = new Data[size];
            for (int i = 0; i < size; i++)
            {
                theTable[i] = new Data();
            }
        }

        private int getHash(String key)
        {
            int hash = 0;
            for (int i = 0; i < key.Length; i++)
            {
                int c = char.ToUpper(key[i]) - 'A';
                hash += c;
            }
            hash = hash % size;
            return hash;
        }

        private int getIndex(String key)
        { 
            int index = getHash(key);

            while(isOccupied(index))
            {
                //probe
                index++;
                if (index == size) index = 0;
                // if table is full, will loop forever
            }
            return index;

        }

        private bool isOccupied(int index)
        {
            //not checking if index is in bounds
            return (theTable[index].name == null);
        }

        public void Store(String key, int value)
        {
            int index = getHash(key) % size;
            theTable[index] = new Data(key, value);
        }

        public int Retrieve(string key)
        {
            int index = getHash(key);
            return theTable[index].grade;

        }

    }
}