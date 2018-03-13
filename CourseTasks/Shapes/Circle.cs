using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Circle : IShape
    {
        private string Name
        {
            get;
        }

        private double Radius
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

        public Circle(double radius)
        {
            this.Name = "Circle";

            this.Radius = radius;

            this.Perimeter = this.GetPerimeter();
            this.Area = this.GetArea();
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
            return string.Format("{0}: area:{1:f2}, perimeter:{2:f2}", Name, Area, Perimeter);
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
            return (this.Name == p.Name && this.Area == p.Area && this.Radius == p.Radius);
        }
        public override int GetHashCode()
        {
            int prime = 13;
            int hash = 1;
            hash = prime * hash + (Name != null ? Name.GetHashCode() : 0);
            hash = prime * hash + (int)Radius;
            hash = prime * hash + (int)Area;
            hash = prime * hash + (int)Perimeter;
            return hash;
        }
    }
}
