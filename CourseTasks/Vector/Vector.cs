using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    public class Vector
    {
        private int Size
        {
            get
            {
                return values.Length;
            }
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
                values = new double[length];
            }
        }

        public Vector(Vector v)
        {
            this.values = new double[v.Size];
            v.values.CopyTo(this.values, 0);
        }

        public Vector(double[] arrayValues)
        {
            if (arrayValues.Length == 0)
            {
                throw new ArgumentException("length array must be > 0!");
            }
            else
            {
                this.values = new double[arrayValues.Length];
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
                if (n < arrayValues.Length)
                {
                    n = arrayValues.Length;
                }
                this.values = new double[n];
                arrayValues.CopyTo(this.values, 0);
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
                    sb.Append(", ");
                }

                sb.Append(v.ToString());
            }
            sb.Append('}');

            return string.Format("Vector: size: {0} values: {1}", this.Size.ToString().PadLeft(3, ' '), sb.ToString());
        }

        public void Addition(Vector v)
        {
            if (this.values.Length < v.values.Length)
            {
                Array.Resize(ref this.values, v.values.Length);
            }

            int indexLimit = (v.values.Length < this.Size) ? v.values.Length : this.Size;
            for (int i = 0; i < indexLimit; i++)
            {
                this.values[i] = this.values[i] + v.values[i];
            }
        }

        public static Vector GetAddition(Vector v1, Vector v2)
        {
            Vector result = new Vector(v1);
            v1.Addition(v2);
            return result;
        }

        public void Subtraction(Vector v)
        {
            if (this.values.Length < v.values.Length)
            {
                Array.Resize(ref this.values, v.values.Length);
            }

            int indexLimit = (v.values.Length < this.Size) ? v.values.Length : this.Size;
            for (int i = 0; i < indexLimit; i++)
            {
                this.values[i] = this.values[i] - v.values[i];
            }
        }

        public static Vector GetSubtraction(Vector v1, Vector v2)
        {
            Vector result = new Vector(v1);
            result.Subtraction(v2);
            return result;
        }

        public double Multiplication(Vector v)
        {
            if (this.values.Length < v.values.Length)
            {
                Array.Resize(ref this.values, v.values.Length);
            }

            double scalarSum = 0.0;

            int indexLimit = (v.values.Length < this.Size) ? v.values.Length : this.Size;
            for (int i = 0; i < indexLimit; i++)
            {
                scalarSum += this.values[i] * v.values[i];
            }

            return scalarSum;
        }

        public static double GetMultiplication(Vector v1, Vector v2)
        {
            double scalarSum = 0.0;
            scalarSum = v1.Multiplication(v2);
            return scalarSum;
        }

        public static Vector GetMarge(Vector v1, Vector v2)
        {
            Vector result = new Vector(v1.Size + v2.Size);

            v1.values.CopyTo(result.values, 0);
            for (int i = v1.Size, j = 0; j < v2.Size; i++, j++)
            {
                result.values[i] = v2.values[j];
            }

            return result;
        }

        public void MultiplicationScalar(int scalar)
        {
            for (int i = 0; i < this.Size; i++)
            {
                this.values[i] *= scalar;
            }
        }


        public void Rotate()
        {
            for (int i = 0, j = this.Size - 1; i < j; i++, j--)
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

        public double Length()
        {
            double lengthV = 0.0;
            foreach (double v in this.values)
            {
                lengthV += Math.Pow(v, 2);
            }
            return Math.Sqrt(lengthV);
        }

        public double GetValueByIndex(int index)
        {
            if (index < 0 || index >= this.Size)
            {
                throw new IndexOutOfRangeException("не корректный индекс");
            }

            return this.values[index];
        }

        public void SetValueByIndex(int index, double value)
        {
            if (index < 0 || index >= this.Size)
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
            if (this.Size != p.Size)
            {
                return false;
            }
            for (int i = 0; i < this.Size; i++)
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
            hash = prime * hash + Size;
            foreach (double v in this.values)
            {
                hash = prime * hash + (int)v;
            }

            return hash;
        }
    }
}
