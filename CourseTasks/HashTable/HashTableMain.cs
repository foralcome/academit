using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class HashTableMain
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>(5);
            hashTable.Add(11);
            hashTable.Add(12);
            hashTable.Add(13);
            hashTable.Add(11);
            hashTable.Add(16);
            hashTable.Add(13);
            hashTable.Add(21);
            hashTable.Add(22);
            hashTable.Add(11);

            foreach (int v in hashTable)
            {
                Console.WriteLine(v);
            }
        }
    }
}
