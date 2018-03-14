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
        }

        private double[] values;

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
            if (v.Length == 0)
            {
                throw new ArgumentException("length vector must be > 0!");
            }
            else
            {
                this.Length = v.Length;
                this.values = new double[v.Length];
                v.values.CopyTo(this.values, 0);
            }
        }

        public Vector(double[] arrayValues)
        {
            if (arrayValues.Length == 0)
            {
                throw new ArgumentException("length array must be > 0!");
            }
            else
            {
                this.Length = arrayValues.Length;
                this.values = new double[this.Length];
                arrayValues.CopyTo(this.values, 0);
            }
        }

        public Vector(int n, double[] arrayValues)
        {
            if (arrayValues.Length == 0)
            {
                throw new ArgumentException("length array must be > 0!");
            }
            else
            {
                this.Length = n;
                this.values = new double[n];
                arrayValues.CopyTo(this.values, 0);

                for (int i = arrayValues.Length; i < n; i++)
                {
                    this.values[i] = 0;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            bool isfirst = true;
            sb.Append('{');
            foreach (double v in this.values)
            {
                if (isfirst)
                {
                    isfirst = false;
                }
                else
                {
                    sb.Append(',');
                }

                sb.Append(v.ToString());
            }
            sb.Append('}');

            return string.Format("Vector: size: {0} values: {1}", this.Length.ToString().PadLeft(3, ' '), sb.ToString());
        }

        public void Addition(Vector v)
        {
            int indexLimit = (v.values.Length < this.Length) ? v.values.Length : this.Length;
            for (int i = 0; i < indexLimit; i++)
            {
                this.values[i] = this.values[i] + v.values[i];
            }
        }

        public static Vector GetAddition(Vector v1, Vector v2)
        {
            int sizeMax = Math.Max(v1.Length, v2.Length);

            if (v1.values.Length < v2.values.Length)
            {
                Vector result = new Vector(v2);
                result.Addition(v1);
                return result;
            }
            else
            {
                Vector result = new Vector(v1);
                result.Addition(v2);
                return result;
            }
        }

        public void Subtraction(Vector v)
        {
            int indexLimit = (v.values.Length < this.Length) ? v.values.Length : this.Length;
            for (int i = 0; i < indexLimit; i++)
            {
                this.values[i] = this.values[i] - v.values[i];
            }
        }

        public static Vector GetSubtraction(Vector v1, Vector v2)
        {
            int sizeMax = Math.Max(v1.Length, v2.Length);

            if (v1.values.Length < v2.values.Length)
            {
                Vector result = new Vector(v2);
                result.Subtraction(v1);
                return result;
            }
            else
            {
                Vector result = new Vector(v1);
                result.Subtraction(v2);
                return result;
            }
        }

        public static Vector GetMarge(Vector v1, Vector v2)
        {
            Vector result = new Vector(v1.Length + v2.Length);

            v1.values.CopyTo(result.values, 0);
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
        public void Multiplication(Vector v)
        {
            int indexLimit = (v.values.Length < this.Length) ? v.values.Length : this.Length;
            for (int i = 0; i < indexLimit; i++)
            {
                this.values[i] = this.values[i] * v.values[i];
            }
        }

        public static Vector GetMultiplication(Vector v1, Vector v2)
        {
            int sizeMax = Math.Max(v1.Length, v2.Length);

            if (v1.values.Length < v2.values.Length)
            {
                Vector result = new Vector(v2);
                result.Multiplication(v1);
                return result;
            }
            else
            {
                Vector result = new Vector(v1);
                result.Multiplication(v2);
                return result;
            }
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
            MultiplicationScalar(-1);
        }

        public double GetLength()
        {
            if (this.Length == 0)
            {
                return 0;
            }

            double lengthV = 0.0;
            foreach (double v in this.values)
            {
                lengthV += Math.Pow(v, 2);
            }
            return Math.Sqrt(lengthV);
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
