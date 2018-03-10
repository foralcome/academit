using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Shapes : IComparable
    {
        protected string Name
        {
            get;
            set;
        }
        protected double Width
        {
            get;
            set;
        }
        protected double Height
        {
            get;
            set;
        }
        protected double Area
        {
            get;
            set;
        }
        protected double Perimeter
        {
            get;
            set;
        }

        public Shapes()
        {
        }

        public virtual double getWidth()
        {
            return 0;
        }
        public virtual double getHeight()
        {
            return 0;
        }
        public virtual double getArea()
        {
            return 0;
        }
        public virtual double getPerimeter()
        {
            return 0;
        }

        public int CompareTo(Object o)
        {
            Shapes p = o as Shapes;
            if (p != null)
                return this.Area.CompareTo(p.Area);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override bool Equals(Object o)
        {
            Shapes p = o as Shapes;
            if (p != null)
                return (this.Name == p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + (Name != null ? Name.GetHashCode() : 0);
            hash = prime * hash + (int)Width;
            hash = prime * hash + (int)Height;
            hash = prime * hash + (int)Area;
            hash = prime * hash + (int)Perimeter;
            return hash;
        }
    }

    class Square : Shapes
    {
        private double Length
        {
            get;
            set;
        }

        public Square(double length)
        {
            this.Name = "Square";

            this.Length = length;

            this.Perimeter = this.getPerimeter();
            this.Area = this.getArea();
        }
        public override double getArea()
        {
            return Length * Length;
        }
        public override double getPerimeter()
        {
            return 4 * Length;
        }

        public override string ToString()
        {
            return string.Format("{0}: area:{1:f2}, perimeter:{2:f2}", this.Name, this.Area, this.Perimeter);
        }
    }

    class Triangle : Shapes
    {
        private double X1
        {
            get;
            set;
        }

        private double Y1
        {
            get;
            set;
        }
        private double X2
        {
            get;
            set;
        }
        private double Y2
        {
            get;
            set;
        }
        private double X3
        {
            get;
            set;
        }
        private double Y3
        {
            get;
            set;
        }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.Name = "Triangle";

            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.X3 = x3;
            this.Y3 = y3;

            this.Perimeter = this.getPerimeter();
            this.Area = this.getArea();
        }

        public override double getArea()
        {
            double triangleLength12 = Math.Sqrt(Math.Pow(this.X1 - this.X2, 2) + Math.Pow(this.Y1 - this.Y2, 2));
            double triangleLength23 = Math.Sqrt(Math.Pow(this.X3 - this.X2, 2) + Math.Pow(this.Y3 - this.Y2, 2));
            double triangleLength31 = Math.Sqrt(Math.Pow(this.X3 - this.X1, 2) + Math.Pow(this.Y3 - this.Y1, 2));

            double semiperimeter = (triangleLength12 + triangleLength23 + triangleLength31) / 2;

            return Math.Sqrt(semiperimeter * (semiperimeter - triangleLength12) * (semiperimeter - triangleLength23) * (semiperimeter - triangleLength31));
        }

        public override double getPerimeter()
        {
            double triangleLength12 = Math.Sqrt(Math.Pow(this.X1 - this.X2, 2) + Math.Pow(this.Y1 - this.Y2, 2));
            double triangleLength23 = Math.Sqrt(Math.Pow(this.X3 - this.X2, 2) + Math.Pow(this.Y3 - this.Y2, 2));
            double triangleLength31 = Math.Sqrt(Math.Pow(this.X3 - this.X1, 2) + Math.Pow(this.Y3 - this.Y1, 2));

            return triangleLength12 + triangleLength23 + triangleLength31;
        }

        public override string ToString()
        {
            return string.Format("{0}: area:{1:f2}, perimeter:{2:f2}", this.Name, this.Area, this.Perimeter);
        }
    }

    class Rectangle : Shapes
    {
        public Rectangle(double width, double height)
        {
            this.Name = "Rectangle";

            this.Width = width;
            this.Height = height;
            this.Perimeter = this.getPerimeter();
            this.Area = this.getArea();
        }

        public override double getWidth()
        {
            return this.Width;
        }

        public override double getHeight()
        {
            return this.Height;
        }

        public override double getArea()
        {
            return this.Width * this.Height;
        }

        public override double getPerimeter()
        {
            return 2 * this.Width + 2 * this.Height;
        }

        public override string ToString()
        {
            return string.Format("{0}: area:{1:f2}, perimeter:{2:f2}", this.Name, this.Area, this.Perimeter);
        }
    }

    class Circle : Shapes
    {
        private double Radius
        {
            get;
            set;
        }

        public Circle(double radius)
        {
            this.Name = "Circle";

            this.Radius = radius;

            this.Perimeter = this.getPerimeter();
            this.Area = this.getArea();
        }

        public override double getArea()
        {
            return 2 * Math.PI * Math.Pow(this.Radius, 2);
        }

        public override double getPerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override string ToString()
        {
            return string.Format("{0}: area:{1:f2}, perimeter:{2:f2}", this.Name, this.Area, this.Perimeter);
        }
    }
}
