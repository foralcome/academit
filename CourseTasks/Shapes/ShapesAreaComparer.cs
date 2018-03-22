using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    public class ShapesAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape x, IShape y)
        {
            return x.GetArea().CompareTo(y.GetArea());
        }
    }
}
