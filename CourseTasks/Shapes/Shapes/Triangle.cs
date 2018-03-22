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
            double a = GetSideLength(X1, Y1, X2, Y2);
            double b = GetSideLength(X3, Y3, X2, Y2);
            double c = GetSideLength(X3, Y3, X1, Y1);

            return Math.Max(Math.Max(a, b), c);
        }

        public double GetHeight()
        {
            double a = GetSideLength(X1, Y1, X2, Y2);
            double b = GetSideLength(X3, Y3, X2, Y2);
            double c = GetSideLength(X3, Y3, X1, Y1);

            double p = (a + b + c) / 2;

            return 2 * Math.Sqrt(p * (p - a) * (p - b) * p - c) / a;
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
            return string.Format("Triangle: area:{0:f2}, perimeter:{1:f2}", this.GetArea(), this.GetPerimeter());
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

            Triangle p = (Triangle)o;
            return (this.X1 == p.X1 && this.Y1 == p.Y1 && this.X2 == p.X2 && this.Y2 == p.Y2 && this.X3 == p.X3 && this.Y3 == p.Y3);
        }

        public override int GetHashCode()
        {
            int prime = 51;
            int hash = 1;
            hash = prime * hash + (int)X1;
            hash = prime * hash + (int)Y1;
            hash = prime * hash + (int)X2;
            hash = prime * hash + (int)Y2;
            hash = prime * hash + (int)X3;
            hash = prime * hash + (int)Y3;
            return hash;
        }
    }
}
