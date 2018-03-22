using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Circle : IShape
    {
        public double Radius
        {
            get;
        }

         public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double GetWidth()
        {
            return 2 * Radius;
        }

        public double GetHeight()
        {
            return 2 * Radius;
        }

        public double GetArea()
        {
            return 2 * Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string ToString()
        {
            return string.Format("Circle: area:{0:f2}, perimeter:{1:f2}", this.GetArea(), this.GetPerimeter());
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

            Circle p = (Circle)o;
            return (this.Radius == p.Radius);
        }
        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;
            hash = prime * hash + (int)Radius;
            return hash;
        }
    }
}
