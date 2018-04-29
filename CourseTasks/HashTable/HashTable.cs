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
        private ArrayList<T>[] table;
        private int count;

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Передан неверный размер Hash-таблицы");
            }
            this.table = new ArrayList<T>[size];
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
            get
            {
                return count;
            }
        }

        public int GetHashCode(T item)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException("переданное значение не должно быть null!");
            }

            return Math.Abs(item.GetHashCode() % this.Size);
        }

        public void Add(T item)
        {
            int hashCodeItem = this.GetHashCode(item);
            if (this.table[hashCodeItem] == null)
            {
                this.table[hashCodeItem] = new ArrayList<T>(10);
            }
            this.table[hashCodeItem].Add(item);
            this.count++;
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

        public int IndexOf(T item)
        {
            int hashCodeItem = this.GetHashCode(item);
            if (ReferenceEquals(this.table[hashCodeItem], null))
            {
                return -1;
            }
            return this.table[hashCodeItem].IndexOf(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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
                this.count--;
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (ArrayList<T> l in table)
            {
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
            throw new NotImplementedException();
        }
    }
}
