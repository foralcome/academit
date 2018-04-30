using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class HashTable<T> : ICollection<T>
    {
        private List<T>[] table;
        private int modCount = 0;

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Передан неверный размер Hash-таблицы");
            }
            this.table = new List<T>[size];
        }

        public int Size
        {
            get
            {
                return this.table.Length;
            }
        }

        public int Count
        {
            get;
        }

        private int GetHashCode(T item)
        {
            if (ReferenceEquals(item, null))
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % this.Size);
        }

        public void Add(T item)
        {
            int hashCodeItem = this.GetHashCode(item);
            if (this.table[hashCodeItem] == null)
            {
                this.table[hashCodeItem] = new List<T>(10);
            }
            this.table[hashCodeItem].Add(item);
            //this.Count++;
            this.modCount++;
        }

        public bool Contains(T item)
        {
            int hashCodeItem = this.GetHashCode(item);
            if (ReferenceEquals(this.table[hashCodeItem], null))
            {
                return false;
            }
            return this.table[hashCodeItem].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            bool isFull = false;
            int insertIndex = arrayIndex;
            foreach (List<T> list in this.table)
            {
                if (ReferenceEquals(list, null))
                {
                    continue;
                }

                foreach (T item in list)
                {
                    if (insertIndex < array.Length)
                    {
                        array[insertIndex] = item;
                        insertIndex++;
                    }
                    else
                    {
                        isFull = true;
                    }
                }

                if (isFull == true)
                {
                    break;
                }
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            int hashCodeItem = this.GetHashCode(item);
            if (ReferenceEquals(this.table[hashCodeItem], null))
            {
                return false;
            }
            if (this.table[hashCodeItem].Remove(item))
            {
                //this.count--;
                this.modCount++;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int lastModCount = this.modCount;

            foreach (List<T> l in table)
            {
                if (this.modCount != lastModCount)
                {
                    throw (new InvalidOperationException("При обходе итератора обнаружжено изменение коллекции!"));
                }

                if (l == null)
                {
                    continue;
                }
                foreach (T v in l)
                {
                    yield return v;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return table.GetEnumerator();
        }

        public void Clear()
        {
            foreach (List<T> list in this.table)
            {
                list.Clear();
            }
        }
    }
}
