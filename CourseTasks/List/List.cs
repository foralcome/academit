using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class List<T>
    {
        private ListNode<T> first;

        public List()
        {
            this.Length = 0;
            this.first = null;
        }
        public List(T[] array)
        {
            foreach (T v in array)
            {
                ListNode<T> n = new ListNode<T>(v);
                this.InsertNodeToEnd(n);
            }
        }

        private int Length
        {
            get;
            set;
        }

        public int GetLength()
        {
            int l = 0;
            ListNode<T> n = this.first;
            while (n != null)
            {
                l++;
                n = n.Next;
            }
            return l;
        }

        private ListNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            //начинаем обход с начала списка
            ListNode<T> n = this.first;
            for (int i = 0; i < this.Length; i++, n = n.Next)
            {
                if (i == index)
                {
                    break;
                }
            }
            return n;
        }

        public T GetValueByIndex(int index)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            //начинаем обход с начала списка
            ListNode<T> n = this.first;
            for (int i = 0; i < this.Length; i++, n = n.Next)
            {
                if (i == index)
                {
                    break;
                }
            }
            return n.Value;
        }

        public T SetValueByIndex(int index, T value)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            ListNode<T> n = GetNodeByIndex(index);

            T oldValue = n.Value;
            n.Value = value;
            return oldValue;
        }

        public T DeleteNodeFromBegin()
        {
            if (this.Length == 0)
            {
                throw new Exception("список пуст. удаление невозможно!");
            }

            T returnValue = this.first.Value;
            this.first = this.first.Next;
            return returnValue;
        }

        public T DeleteNodeByIndex(int index)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            ListNode<T> n = GetNodeByIndex(index);

            //это первый элемент в списке
            if (n == this.first)
            {
                this.first = n.Next;
            }
            //это последний элемент в списке
            else if (n.Next == null)
            {
                ListNode<T> nPrev = GetNodeByIndex(index - 1);
                nPrev.Next = null;
            }
            //элемент где-то в середине списка
            else
            {
                ListNode<T> nPrev = GetNodeByIndex(index - 1);
                nPrev.Next = n.Next;
            }

            this.Length--;
            return n.Value;
        }

        public bool DeleteNodeByValue(T value)
        {
            if (this.Length == 0)
            {
                return false;
            }

            ListNode<T> nPrev = null;
            ListNode<T> n = this.first;
            bool isFound = false;

            //начинаем обход с начала списка
            while (n != null)
            {
                if (n.Value.Equals(value))
                {
                    isFound = true;
                    break;
                }

                nPrev = n;
                n = n.Next;
            }

            if (!isFound)
            {
                return false;
            }

            //это первый элемент в списке
            if (n == this.first)
            {
                this.first = n.Next;
            }
            //это последний элемент в списке
            else if (n.Next == null)
            {
                nPrev.Next = null;
            }
            //элемент где-то в середине списка
            else
            {
                nPrev.Next = n.Next;
            }

            this.Length--;
            return true;
        }

        public void InsertToBegin(T value)
        {
            ListNode<T> n = new ListNode<T>(value);

            n.Next = this.first;
            this.first = n;
            this.Length++;
        }

        public void InsertByIndex(int index, T value)
        {
            ListNode<T> n = new ListNode<T>(value);

            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            ListNode<T> s = GetNodeByIndex(index);

            //это первый элемент в списке
            if (s == this.first)
            {
                n.Next = s;
                this.first = n;
            }
            else
            {
                ListNode<T> sPrev = GetNodeByIndex(index - 1);
                n.Next = s;
                sPrev.Next = n;
            }

            this.Length++;
        }

        public void InsertNodeToEnd(ListNode<T> n)
        {
            if (this.first == null)
            {
                this.first = new ListNode<T>(n.Value);
            }
            else
            {
                ListNode<T> s = this.first;
                while (s.Next != null)
                {
                    s = s.Next;
                }

                s.Next = new ListNode<T>(n.Value);
            }

            this.Length++;
        }

        public void Rotate()
        {
            ListNode<T> newFirst = null;

            //начинаем обход с начала списка
            for (ListNode<T> current = this.first; current != null;)
            {
                ListNode<T> currentNext = current.Next;
                current.Next = newFirst;
                newFirst = current;
                current = currentNext;
            }

            this.first = newFirst;
        }

        public List<T> Copy()
        {
            List<T> copyList = new List<T>();
            for (ListNode<T> current = this.first; current != null; current = current.Next)
            {
                ListNode<T> copyNode = new ListNode<T>(current.Value);
                copyList.InsertNodeToEnd(copyNode);
            }
            return copyList;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            ListNode<T> n = this.first;
            while (n != null)
            {
                sb.Append(n.Value);
                if (n.Next != null)
                {
                    sb.Append(", ");
                }
                n = n.Next;
            }
            sb.Append("}");
            return sb.ToString();
        }

        public override bool Equals(Object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }
            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
            {
                return false;
            }

            List<T> p = (List<T>)o;
            if (this.Length != p.Length)
            {
                return false;
            }
            ListNode<T> thisNode = this.first;
            ListNode<T> objectNode = p.first;
            for (; thisNode != null; thisNode = thisNode.Next, objectNode = objectNode.Next)
            {
                if (!thisNode.Equals(objectNode))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 11;
            int hash = 1;

            for (ListNode<T> n = this.first; n != null; n = n.Next)
            {
                hash = prime * hash + n.Value.GetHashCode();
            }

            return hash;
        }
    }
}
