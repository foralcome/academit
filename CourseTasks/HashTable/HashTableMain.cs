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
            Console.WriteLine("0) Create new hashtable object size 5");
            HashTable<int> hashTable = new HashTable<int>(5);

            Console.WriteLine("1) Add to hashtable new items");
            Console.WriteLine(">> Add 11");
            hashTable.Add(11);
            Console.WriteLine(">> Add 12");
            hashTable.Add(12);
            Console.WriteLine(">> Add 13");
            hashTable.Add(13);
            Console.WriteLine(">> Add 11");
            hashTable.Add(11);
            Console.WriteLine(">> Add 16");
            hashTable.Add(16);
            Console.WriteLine(">> Add 13");
            hashTable.Add(13);
            Console.WriteLine(">> Add 21");
            hashTable.Add(21);
            Console.WriteLine(">> Add 22");
            hashTable.Add(22);
            Console.WriteLine(">> Add 11");
            hashTable.Add(11);
            Console.WriteLine(">> After insert hashtable conteins {0} items", hashTable.Count);

            Console.WriteLine("2) Print on screen all items hashtable");
            foreach (int v in hashTable)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("3) Chech exists item 13 in the hasttable");
            if (hashTable.Contains(13))
            {
                Console.WriteLine(">> Item 13 is exists in the hashtable");
            }
            else
            {
                Console.WriteLine(">> Item 13 is't exists in the hashtable");
            }

            Console.WriteLine("4) Remove item 13");
            if (hashTable.Remove(13))
            {
                foreach (int v in hashTable)
                {
                    Console.WriteLine(v);
                }

                Console.WriteLine(">> After insert hashtable conteins {0} items", hashTable.Count);
            }
            else
            {
                Console.WriteLine(">> Item 13 is't exists in the hashtable");
            }

            Console.WriteLine("5) CopyTo Array");
            int[] array = new int[5];
            hashTable.CopyTo(array, 1);
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}
