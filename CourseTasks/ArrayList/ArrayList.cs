using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int length;

        public ArrayList(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException("размер нового списка должен больше количества элементов находящихся в нём!");
            }

            this.items = new T[capacity];
        }

        public int Count
        {
            get { return length; }
        }

        //Размер этого массива
        public int Capacity
        {
            get { return items.Length; }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("размер нового списка должен не меньше количества элементов в нём!");
                }
                else
                {
                    SetCapacity(value);
                }
            }
        }

        bool ICollection<T>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        private void IncreaseCapacity()
        {
            T[] old = items;
            items = new T[old.Length * 2];
            Array.Copy(old, 0, items, 0, old.Length);
        }

        private void SetCapacity(int capacity)
        {
            if (capacity < this.Count)
            {
                throw new ArgumentOutOfRangeException("новый размер списка должен быть больше количества элементов находящихся в нём!");
            }

            if (capacity > this.Capacity)
            {
                T[] old = items;
                items = new T[capacity];
                Array.Copy(old, 0, items, 0, this.Count);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("индекс вышел за пределы списка");
                }
                else
                {
                    return items[index];
                }
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("индекс вышел за пределы списка");
                }
                else
                {
                    items[index] = value;
                }
            }
        }

        public void TrimExcess()
        {
            if (this.Count != this.Capacity)
            {
                Array.Resize(ref this.items, this.Count);
            }
        }

        public void Add(T obj)
        {
            if (this.Count + 1 >= this.Capacity)
            {
                IncreaseCapacity();
            }
            items[this.Count] = obj;
            ++length;
        }

        public void Insert(int index, T obj)
        {
            if (index < 0 || index > this.Count)
            {
                throw new IndexOutOfRangeException("индекс вышел за пределы списка");
            }

            if (this.Count + 1 >= this.Capacity)
            {
                IncreaseCapacity();
            }

            if (index < this.Count)
            {
                Array.Copy(items, index, items, index + 1, this.Count - index);
            }
            items[index] = obj;
            ++length;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("индекс вышел за пределы списка");
            }

            Array.Copy(items, index + 1, items, index, this.Count - index - 1);
            --length;
        }

        public bool Remove(T value)
        {
            int indexSearch = -1;
            for (int index = 0; index < this.Count; index++)
            {
                if (items[index].Equals(value))
                {
                    indexSearch = index;
                    break;
                }
            }
            if (indexSearch == -1)
            {
                return false;
            }

            RemoveAt(indexSearch);
            return true;
        }

        public void RemoveRange(int indexStart, int indexStop)
        {
            if (indexStart >= indexStop)
            {
                throw new IndexOutOfRangeException("начальный индекс должен быть меньше конечного!");
            }

            if (indexStart < 0 || indexStop >= this.Count)
            {
                throw new IndexOutOfRangeException("индекс вышел за пределы списка");
            }

            T[] old = items;
            this.length -= (indexStop - indexStart + 1);
            items = new T[this.Capacity];
            Array.Copy(old, 0, items, 0, indexStart);
            Array.Copy(old, indexStop + 1, items, indexStart, old.Length - indexStop - 1);
            Array.Clear(items, length, old.Length - length);
        }

        public void Clear()
        {
            Array.Clear(items, 0, items.Length);
            length = 0;
        }

        public bool Contains(T value)
        {
            if (IndexOf(value) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int IndexOf(T value)
        {
            for (int index = 0; index < this.Count; index++)
            {
                if (items[index].Equals(value))
                {
                    return index;
                }
            }
            return -1;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("свойство array имеет значение null");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("индекс вышел за пределы списка");
            }

            if (array.Length < this.Count + index + 1)
            {
                throw new ArgumentException("длина результирующего массива недостаточна");
            }

            Array.Copy(items, 0, array, index, this.Count);
        }

        public override string ToString()
        {
            StringBuilder r = new StringBuilder();
            bool isFirst = true;
            r.Append("{");
            foreach (T a in items)
            {
                if (!isFirst)
                {
                    r.Append(", ");
                }
                r.Append(a);
                isFirst = false;
            }
            r.Append("}");
            return r.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == null || i >= this.Count)
                {
                    throw new Exception("итератор вышел за пределы списка!");
                }

                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }
            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
            {
                return false;
            }

            ArrayList<T> p = (ArrayList<T>)o;
            if (this.Capacity != p.Capacity || this.Count != p.Count)
            {
                return false;
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (!this.items[i].Equals(p.items[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 151;
            int hash = 1;
            hash = prime * hash + Count;
            foreach (T v in this.items)
            {
                hash = prime * hash + v.GetHashCode();
            }

            return hash;
        }
    }
}
