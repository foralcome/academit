using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Rectangle : IShape
    {
        private string Name
        {
            get;
        }

        private double Width
        {
            get;
        }

        private double Height
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

        public Rectangle(double width, double height)
        {
            this.Name = "Rectangle";

            this.Width = width;
            this.Height = height;
            this.Perimeter = this.GetPerimeter();
            this.Area = this.GetArea();
        }

        public double GetWidth()
        {
            return this.Width;
        }

        public double GetHeight()
        {
            return this.Height;
        }

        public double GetArea()
        {
            return this.Width * this.Height;
        }

        public double GetPerimeter()
        {
            return 2 * this.Width + 2 * this.Height;
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

            Rectangle p = (Rectangle)o;
            return (this.Name == p.Name && this.Area == p.Area && this.Width == p.Width && this.Height == p.Height);
        }
        public override int GetHashCode()
        {
            int prime = 77;
            int hash = 1;
            hash = prime * hash + (Name != null ? Name.GetHashCode() : 0);
            hash = prime * hash + (int)Width;
            hash = prime * hash + (int)Height;
            hash = prime * hash + (int)Area;
            hash = prime * hash + (int)Perimeter;
            return hash;
        }
    }
}
