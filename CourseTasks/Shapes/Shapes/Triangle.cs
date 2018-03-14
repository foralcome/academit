using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Triangle : IShape
    {
        private double X1
        {
            get;
        }
        private double Y1
        {
            get;
        }
        private double X2
        {
            get;
        }
        private double Y2
        {
            get;
        }
        private double X3
        {
            get;
        }
        private double Y3
        {
            get;
        }
        private double Area
        {
            get;
        }
        private double Perimeter
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

            this.Perimeter = this.GetPerimeter();
            this.Area = this.GetArea();
        }

        public double GetWidth()
        {
            return 0.0;
        }

        public double GetHeight()
        {
            return 0.0;
        }

        public double GetArea()
        {
            double triangleLength12 = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
            double triangleLength23 = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            double triangleLength31 = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));

            double semiperimeter = (triangleLength12 + triangleLength23 + triangleLength31) / 2;

            return Math.Sqrt(semiperimeter * (semiperimeter - triangleLength12) * (semiperimeter - triangleLength23) * (semiperimeter - triangleLength31));
        }

        public double GetPerimeter()
        {
            double triangleLength12 = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
            double triangleLength23 = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            double triangleLength31 = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));

            return triangleLength12 + triangleLength23 + triangleLength31;
        }

        public override string ToString()
        {
            return string.Format("area:{0:f2}, perimeter:{1:f2}", Area, Perimeter);
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
