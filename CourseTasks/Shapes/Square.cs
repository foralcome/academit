using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    public class Square : IShape
    {
        private string Name
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

        private double Length
        {
            get;
        }

        public Square(double length)
        {
            this.Name = "Square";

            this.Length = length;

            this.Perimeter = GetPerimeter();
            this.Area = GetArea();
        }

        public double GetArea()
        {
            return this.Length * this.Length;
        }

        public double GetPerimeter()
        {
            return 4 * this.Length;
        }

        public double GetWidth()
        {
            return Length;
        }

        public double GetHeight()
        {
            return Length;
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

            Square p = (Square)o;
            return (this.Name == p.Name && this.Area == p.Area && this.Perimeter == p.Perimeter);
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;
            hash = prime * hash + (Name != null ? Name.GetHashCode() : 0);
            hash = prime * hash + (int)Length;
            hash = prime * hash + (int)Area;
            hash = prime * hash + (int)Perimeter;
            return hash;
        }
    }
}
