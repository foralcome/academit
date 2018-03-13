using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Matrix
    {
        private int SizeN
        {
            get;
        }
        private int SizeM
        {
            get;
        }

        private Vector[] vectors;

        Matrix(int n, int m)
        {
            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("неверное значение размера матрицы");
            }

            this.SizeN = n;
            this.SizeM = m;

            this.vectors = new Vector[n];
            for (int i = 0; i < SizeM; i++)
            {
                this.vectors[i] = new Vector(m);
            }
        }

        Matrix(Matrix matrix)
        {
            this.SizeN = matrix.SizeM;
            this.SizeM = matrix.SizeN;

            this.vectors = new Vector[this.SizeN];
            for (int i = 0; i < this.SizeN; i++)
            {
                this.vectors[i] = new Vector(matrix.vectors[i].values);
            }
        }

        Matrix(double[][] values)
        {
            this.SizeN = values.GetLength(0);
            this.SizeM = values.GetLength(1);

            this.vectors = new Vector[this.SizeN];
            for (int i = 0; i < this.SizeN; i++)
            {
                this.vectors[i] = new Vector(values[i]);
            }
        }

        Matrix(Vector[] vectors)
        {
            this.SizeN = vectors.Length;
            this.vectors = new Vector[this.SizeN];

            this.SizeM = 0;
            foreach (Vector v in vectors)
            {
                if (v.GetLength() > this.SizeM)
                {
                    this.SizeM = v.GetLength();
                }
            }

            for (int i = 0; i < this.SizeN; i++)
            {
                this.vectors[i] = new Vector(this.SizeM, vectors[i].values);
            }
        }

        public int[] GetSize()
        {
            return new int[] { this.SizeN, this.SizeM };
        }

        public Vector GetVectorByIndex(int index)
        {
            if (index < 0 || index >= this.SizeN)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            return this.vectors[index];
        }

        public void SetVectorByIndex(Vector v, int index)
        {
            if (index < 0 || index >= this.SizeN)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            this.vectors[index] = v;
        }
    }
}
