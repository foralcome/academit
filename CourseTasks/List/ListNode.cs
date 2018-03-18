using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    public class ListNode
    {
        public ListNode(double value)
        {
            this.Value = value;
        }

        public ListNode(ListNode n)
        {
            this.Value = n.Value;
        }

        public double Value
        {
            get;
            set;
        }

        public ListNode Next
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

            ListNode p = (ListNode)o;
            return this.Value.Equals(p.Value);
        }

        public override int GetHashCode()
        {
            int prime = 11;
            int hash = 1;
            hash = prime * hash + (int)this.Value;
            return hash;
        }
    }
}
