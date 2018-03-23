using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Triangle : IShape
    {
        public double X1
        {
            get;
        }
        public double Y1
        {
            get;
        }
        public double X2
        {
            get;
        }
        public double Y2
        {
            get;
        }
        public double X3
        {
            get;
        }
        public double Y3
        {
            get;
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.X3 = x3;
            this.Y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(this.X1, this.X2), this.X3) - Math.Min(Math.Min(this.X1, this.X2), this.X3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(this.Y1, this.Y2), this.Y3) - Math.Min(Math.Min(this.Y1, this.Y2), this.Y3);
        }

        private double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
        public double GetArea()
        {
            double a = GetSideLength(X1, Y1, X2, Y2);
            double b = GetSideLength(X3, Y3, X2, Y2);
            double c = GetSideLength(X3, Y3, X1, Y1);

            double semiperimeter = (a + b + c) / 2;

            return Math.Sqrt(semiperimeter * (semiperimeter - a) * (semiperimeter - b) * (semiperimeter - c));
        }

        public double GetPerimeter()
        {
            double a = GetSideLength(X1, Y1, X2, Y2);
            double b = GetSideLength(X3, Y3, X2, Y2);
            double c = GetSideLength(X3, Y3, X1, Y1);

            return a + b + c;
        }

        public override string ToString()
        {
            return string.Format("Triangle: [1]({0:f2},{1:f2}) [2]({2:f2},{3:f2}) [3]({4:f2},{5:f2})", this.X1, this.Y1, this.X2, this.X2, this.X3, this.Y3);
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

            Triangle p = (Triangle)o;
            return (this.X1 == p.X1 && this.Y1 == p.Y1 && this.X2 == p.X2 && this.Y2 == p.Y2 && this.X3 == p.X3 && this.Y3 == p.Y3);
        }

        public override int GetHashCode()
        {
            int prime = 51;
            int hash = 1;
            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();
            return hash;
        }
    }
}
