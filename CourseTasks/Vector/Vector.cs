using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    public class Vector
    {
        private int Length
        {
            get;
            set;
        }

        public double[] values;

        public Vector(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("length must be > 0!");
            }
            else
            {
                this.Length = length;
                values = new double[length];
            }
        }

        public Vector(Vector v)
        {
            this.Length = v.Length;
            this.values = new double[v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                this.values[i] = v.values[i];
            }
        }

        public Vector(double[] arrayValues)
        {
            this.Length = arrayValues.Length;
            this.values = new double[this.Length];
            for (int i = 0; i < arrayValues.Length; i++)
            {
                this.values[i] = arrayValues[i];
            }
        }

        public Vector(int n, double[] arrayValues)
        {
            this.Length = n;
            this.values = new double[n];
            for (int i = 0; i < arrayValues.Length; i++)
            {
                this.values[i] = arrayValues[i];
            }
            for (int i = arrayValues.Length; i < n; i++)
            {
                this.values[i] = 0;
            }
        }

        public override string ToString()
        {
            string str = "{";
            bool isfirst = true;
            foreach (double v in this.values)
            {
                if (isfirst)
                {
                    isfirst = false;
                }
                else
                {
                    str += ", ";
                }
                str += v.ToString();
            }
            str += "}";

            return string.Format("Vector: size: {0} values: {1}", this.Length.ToString().PadLeft(3, ' '), str);
        }

        public void Addition(Vector v)
        {
            int sizeMax = Math.Max(this.Length, v.Length);

            Vector v1 = new Vector(sizeMax, this.values);
            Vector v2 = new Vector(sizeMax, v.values);

            this.Length = sizeMax;
            this.values = new double[sizeMax];
            for (int i = 0; i < sizeMax; i++)
            {
                this.values[i] = v1.values[i] + v2.values[i];
            }
        }

        public static Vector GetAddition(Vector v1, Vector v2)
        {
            int sizeMax = Math.Max(v1.Length, v2.Length);

            Vector localVector1 = new Vector(sizeMax, v1.values);
            Vector localVector2 = new Vector(sizeMax, v2.values);
            Vector result = new Vector(sizeMax);

            for (int i = 0; i < sizeMax; i++)
            {
                result.values[i] = localVector1.values[i] + localVector2.values[i];
            }

            return result;
        }

        public void Subtraction(Vector v)
        {
            int sizeMax = Math.Max(this.Length, v.Length);

            Vector v1 = new Vector(sizeMax, this.values);
            Vector v2 = new Vector(sizeMax, v.values);

            this.Length = sizeMax;
            this.values = new double[sizeMax];
            for (int i = 0; i < sizeMax; i++)
            {
                this.values[i] = v1.values[i] - v2.values[i];
            }
        }

        public static Vector GetSubtraction(Vector v1, Vector v2)
        {
            int sizeMax = Math.Max(v1.Length, v2.Length);

            Vector localVector1 = new Vector(sizeMax, v1.values);
            Vector localVector2 = new Vector(sizeMax, v2.values);
            Vector result = new Vector(sizeMax);

            for (int i = 0; i < sizeMax; i++)
            {
                result.values[i] = localVector1.values[i] - localVector2.values[i];
            }

            return result;
        }

        public static Vector GetMarge(Vector v1, Vector v2)
        {
            Vector result = new Vector(v1.Length + v2.Length);

            for (int i = 0; i < v1.Length; i++)
            {
                result.values[i] = v1.values[i];
            }
            for (int i = v1.Length, j = 0; j < v2.Length; i++, j++)
            {
                result.values[i] = v2.values[j];
            }

            return result;
        }

        public void MultiplicationScalar(int scalar)
        {
            for (int i = 0; i < this.Length; i++)
            {
                this.values[i] *= scalar;
            }
        }

        public static Vector GetMultiplication(Vector v1, Vector v2)
        {
            int sizeMax = Math.Max(v1.Length, v2.Length);

            Vector localVector1 = new Vector(sizeMax, v1.values);
            Vector localVector2 = new Vector(sizeMax, v2.values);
            Vector result = new Vector(sizeMax);

            for (int i = 0; i < sizeMax; i++)
            {
                result.values[i] = localVector1.values[i] * localVector2.values[i];
            }

            return result;
        }

        public void Rotate()
        {
            for (int i = 0, j = this.Length - 1; i < j; i++, j--)
            {
                double c = this.values[i];
                this.values[i] = values[j];
                values[j] = c;
            }
        }

        public void Inversion()
        {
            for (int i = 0; i < this.Length; i++)
            {
                this.values[i] *= -1;
            }
        }

        public int GetLength()
        {
            return this.Length;
        }

        public double GetValueByIndex(int index)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException("не корректный индекс");
            }

            return this.values[index];
        }

        public void SetValueByIndex(int index, double value)
        {
            if (index < 0 || index >= this.Length)
            {
                throw new IndexOutOfRangeException("не корректный индекс");
            }

            this.values[index] = value;
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

            Vector p = (Vector)o;
            if (this.Length != p.Length)
            {
                return false;
            }
            for (int i = 0; i < this.Length; i++)
            {
                if (!this.values[i].Equals(p.values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 15;
            int hash = 1;
            hash = prime * hash + Length;
            foreach (double v in this.values)
            {
                hash = prime * hash + (int)v;
            }

            return hash;
        }
    }
}
