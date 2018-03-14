using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Matrix
    {
        private int CountRows
        {
            get;
        }
        private int CountCols
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

            this.CountRows = n;
            this.CountCols = m;

            this.vectors = new Vector[n];
            for (int i = 0; i < CountCols; i++)
            {
                this.vectors[i] = new Vector(m);
            }
        }

        Matrix(Matrix matrix)
        {
            this.CountRows = matrix.CountCols;
            this.CountCols = matrix.CountRows;

            this.vectors = new Vector[this.CountRows];
            for (int i = 0; i < this.CountRows; i++)
            {
                this.vectors[i] = new Vector(matrix.vectors[i].values);
            }
        }

        Matrix(double[][] values)
        {
            this.CountRows = values.GetLength(0);
            this.CountCols = values.GetLength(1);

            this.vectors = new Vector[this.CountRows];
            for (int i = 0; i < this.CountRows; i++)
            {
                this.vectors[i] = new Vector(values[i]);
            }
        }

        Matrix(Vector[] vectors)
        {
            this.CountRows = vectors.Length;
            this.vectors = new Vector[this.CountRows];

            this.CountCols = 0;
            foreach (Vector v in vectors)
            {
                if (v.GetLength() > this.CountCols)
                {
                    this.CountCols = v.GetLength();
                }
            }

            for (int i = 0; i < this.CountRows; i++)
            {
                this.vectors[i] = new Vector(this.CountCols, vectors[i].values);
            }
        }

        public int[] GetSize()
        {
            return new int[] { this.CountRows, this.CountCols };
        }

        public Vector GetVectorRowByIndex(int index)
        {
            if (index < 0 || index >= this.CountRows)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            return this.vectors[index];
        }

        public void SetVectorRowByIndex(Vector v, int index)
        {
            if (index < 0 || index >= this.CountRows)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            this.vectors[index] = v;
        }
        public Vector GetVectorColByIndex(int index)
        {
            if (index < 0 || index >= this.CountCols)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            Vector result = new Vector(this.CountRows);

            for (int i = 0; i < this.CountRows; i++)
            {
                result.values[i] = this.vectors[i].GetValueByIndex(index);
            }

            return result;
        }

        public Matrix Transposition()
        {
            int newCountRows = this.CountCols;
            int newCountCols = this.CountRows;

            Matrix newMatrix = new Matrix(newCountRows, newCountCols);

            for (int i = 0; i < this.CountRows; i++)
            {
                for (int j = 0; j < this.CountCols; j++)
                {
                    newMatrix.vectors[j].values[i] = this.vectors[i].GetValueByIndex(j);
                }
            }

            return newMatrix;
        }

        public void MultiplicationScalar(int scalar)
        {
            for (int i = 0; i < this.CountRows; i++)
            {
                this.vectors[i].MultiplicationScalar(scalar);
            }
        }

        public void MultiplicationScalar(int scalar)
        {
            for (int i = 0; i < this.CountRows; i++)
            {
                this.vectors[i].MultiplicationScalar(scalar);
            }
        }
    }
}
