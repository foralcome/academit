using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class List
    {
        private int length;
        private ListNode first;
        private ListNode last;

        public List()
        {
            this.length = 0;
            this.first = this.last = null;
        }
        public List(double[] array)
        {
            foreach (double v in array)
            {
                ListNode n = new ListNode(v);
                this.InsertNodeToEnd(n);
            }
        }

        public int GetLength()
        {
            return length;
        }

        public ListNode GetNodeByIndex(int index)
        {
            if (index < 0 || index >= this.length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            //начинаем обход с начала списка
            ListNode n = this.first;
            for (int i = 0; i < this.length; i++, n = n.Next)
            {
                if (i == index)
                {
                    break;
                }
            }
            return n;
        }

        public double GetValueByIndex(int index)
        {
            if (index < 0 || index >= this.length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            //начинаем обход с начала списка
            ListNode n = this.first;
            for (int i = 0; i < this.length; i++, n = n.Next)
            {
                if (i == index)
                {
                    break;
                }
            }
            return n.Value;
        }

        public double SetValueByIndex(int index, double value)
        {
            if (index < 0 || index >= this.length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            //начинаем обход с начала списка
            ListNode n = this.first;
            for (int i = 0; i < this.length; i++, n = n.Next)
            {
                if (i == index)
                {
                    break;
                }
            }

            double oldValue = n.Value;
            n.Value = value;
            return oldValue;
        }

        public double DeleteNodeFromBegin()
        {
            if (this.length == 0)
            {
                throw new Exception("список пуст. удаление невозможно!");
            }

            double returnValue = this.first.Value;
            this.first = this.first.Next;
            this.length--;
            return returnValue;
        }

        public double DeleteNodeByIndex(int index)
        {
            if (index < 0 || index >= this.length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            ListNode n = this.first;

            //это единственный элемент в 
            if (this.length == 1)
            {
                this.first = null;
                this.last = null;
                this.length = 0;
                return n.Value;
            }
            else
            {
                ListNode nPrev = null;
                //начинаем обход с начала списка
                for (int i = 0; i < this.length; i++)
                {
                    if (i == index)
                    {
                        break;
                    }
                    nPrev = n;
                    n = n.Next;
                }

                //это первый элемент в списке
                if (n == this.first)
                {
                    this.first = n.Next;
                }
                //это последний элемент в списке
                else if (n.Next == null)
                {
                    this.last = nPrev;
                    this.last.Next = null;
                }
                //элемент где-то в середине списка
                else
                {
                    nPrev.Next = n.Next;
                }

                this.length--;
                return n.Value;
            }
        }

        public bool DeleteNodeByValue(int value)
        {
            if (this.length == 0)
            {
                return false;
            }

            ListNode nPrev = null;
            ListNode n = this.first;
            bool isFound = false;

            //начинаем обход с начала списка
            while (n != null)
            {
                if (n.Value == value)
                {
                    isFound = true;
                    break;
                }

                nPrev = n;
                n = n.Next;
            }

            if (isFound == false)
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
                this.last = nPrev;
                this.last.Next = null;
            }
            //элемент где-то в середине списка
            else
            {
                nPrev.Next = n.Next;
            }

            this.length--;
            return true;
        }

        public void InsertNodeToBegin(ListNode n)
        {
            n.Next = this.first;
            this.first = n;
            this.length++;
        }

        public void InsertNodeByIndex(int index, ListNode n)
        {
            if (index < 0 || index >= this.length)
            {
                throw new IndexOutOfRangeException("индекс имеет недопустимое значение!");
            }

            ListNode s = this.first;
            ListNode sPrev = null;
            //начинаем обход с начала списка
            for (int i = 0; i < this.length; i++)
            {
                if (i == index)
                {
                    break;
                }
                sPrev = s;
                s = s.Next;
            }

            //это первый элемент в списке
            if (s == this.first)
            {
                n.Next = s;
                this.first = n;
            }
            else
            {
                n.Next = s;
                sPrev.Next = n;
            }

            this.length++;
        }

        public void InsertNodeToEnd(ListNode n)
        {
            if (this.last == null)
            {
                this.first = n;
                this.last = n;
            }
            else
            {
                this.last.Next = n;
                this.last = n;
            }

            this.length++;
        }

        public void Rotate()
        {
            ListNode newFirst = null;

            //начинаем обход с начала списка
            for (ListNode current = this.first; current != null;)
            {
                ListNode currentNext = current.Next;
                current.Next = newFirst;
                newFirst = current;
                current = currentNext;
            }

            this.first = newFirst;
        }

        public List Copy()
        {
            List copyList = new List();
            for (ListNode current = this.first; current != null; current = current.Next)
            {
                ListNode copyNode = new ListNode(current);
                copyList.InsertNodeToEnd(copyNode);
            }
            return copyList;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            ListNode n = this.first;
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

            List p = (List)o;
            if (this.length != p.length)
            {
                return false;
            }
            ListNode thisNode = this.first;
            ListNode objectNode = p.first;
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

            for (ListNode n = this.first; n != null; n = n.Next)
            {
                hash = prime * hash + (int)n.Value;
            }

            return hash;
        }
    }
}
