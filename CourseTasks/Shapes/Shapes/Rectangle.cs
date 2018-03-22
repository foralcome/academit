﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Rectangle : IShape
    {
        public double Width
        {
            get;
        }

        public double Height
        {
            get;
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
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
            return string.Format("Rectangle: area:{0:f2}, perimeter:{1:f2}", this.GetArea(), this.GetPerimeter());
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
            return (this.Width == p.Width && this.Height == p.Height);
        }
        public override int GetHashCode()
        {
            int prime = 77;
            int hash = 1;
            hash = prime * hash + (int)Width;
            hash = prime * hash + (int)Height;
            return hash;
        }
    }
}
