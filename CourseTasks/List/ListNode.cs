using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public T Value
        {
            get;
            set;
        }

        public ListNode<T> Next
        {
            get;
            set;
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

            ListNode<T> p = (ListNode<T>)o;
            return this.Value.Equals(p.Value);
        }

        public override int GetHashCode()
        {
            int prime = 11;
            int hash = 1;
            hash = prime * hash + this.Value.GetHashCode();
            return hash;
        }
    }
}
