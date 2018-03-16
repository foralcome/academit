using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Matrix
    {
        private int sizeHeight;
        private int sizeWidth;
        private Vector[] vectors;

        public Matrix(int sizeHeight, int sizeWidth)
        {
            if (sizeHeight <= 0 || sizeWidth <= 0)
            {
                throw new ArgumentException("неверное значение размера матрицы");
            }

            this.vectors = new Vector[sizeHeight];
            this.sizeHeight = sizeHeight;
            this.sizeWidth = sizeWidth;
            for (int i = 0; i < sizeHeight; i++)
            {
                this.vectors[i] = new Vector(sizeWidth);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (ReferenceEquals(matrix, null) || matrix.sizeHeight == 0)
            {
                throw new ArgumentException("передан неверный параметр");
            }

            this.sizeHeight = matrix.sizeHeight;
            this.sizeWidth = matrix.sizeWidth;
            this.vectors = new Vector[this.sizeHeight];
            for (int i = 0; i < this.sizeHeight; i++)
            {
                this.vectors[i] = new Vector(matrix.vectors[i]);
            }
        }

        public Matrix(double[][] values)
        {
            if (ReferenceEquals(values, null) || values.GetLength(0) == 0)
            {
                throw new ArgumentException("передан неверный параметр");
            }

            this.sizeHeight = values.GetLength(0);
            this.sizeWidth = values[0].Length;
            this.vectors = new Vector[this.sizeHeight];
            for (int i = 0; i < this.sizeHeight; i++)
            {
                this.vectors[i] = new Vector(values[i]);
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (ReferenceEquals(vectors, null) || vectors.Length == 0)
            {
                throw new ArgumentException("передан неверный параметр");
            }

            this.sizeHeight = vectors.Length;
            this.sizeWidth = vectors[0].Size;
            this.vectors = new Vector[this.sizeHeight];
            for (int i = 0; i < this.sizeHeight; i++)
            {
                this.vectors[i] = new Vector(vectors[i]);
            }
        }

        public int GetHeight()
        {
            return this.sizeHeight;
        }

        public int GetWidth()
        {
            return this.sizeWidth;
        }

        public Vector GetVectorRowByIndex(int index)
        {
            if (index < 0 || index >= this.sizeHeight)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            return this.vectors[index];
        }

        public void SetVectorRowByIndex(Vector v, int index)
        {
            if (index < 0 || index >= this.sizeHeight)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            if (v.Size != this.sizeWidth)
            {
                throw new ArgumentException("размер вектора превышает размер ширины матрицы!");
            }

            this.vectors[index] = v;
        }

        public Vector GetVectorColByIndex(int index)
        {
            if (index < 0 || index >= this.sizeWidth)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            Vector result = new Vector(this.sizeHeight);
            for (int i = 0; i < this.sizeHeight; i++)
            {
                result.SetValueByIndex(i, this.vectors[i].GetValueByIndex(index));
            }
            return result;
        }

        public void MultiplicationScalar(int scalar)
        {
            foreach (Vector v in this.vectors)
            {
                v.MultiplicationScalar(scalar);
            }
        }

        private static double[][] GetMinor(double[][] matrix, int excludeI, int excludeJ)
        {
            int sizeMatrix = matrix.Length;

            double[][] minor = new double[sizeMatrix - 1][];
            for (int i = 0, ii = 0; i < sizeMatrix; i++)
            {
                if (i == excludeI)
                {
                    continue;
                }

                minor[ii] = new double[sizeMatrix - 1];
                for (int j = 0, jj = 0; j < sizeMatrix; j++)
                {
                    if (j == excludeJ)
                    {
                        continue;
                    }

                    minor[ii][jj] = matrix[i][j];
                    jj++;
                }

                ii++;
            }
            return minor;
        }

        private double GetDeterminant(double[][] matrix)
        {
            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }
            else if (matrix.Length == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[1][0] * matrix[0][1];
            }
            else
            {
                double determinant = 0;
                for (int i = 0; i < matrix.Length; i++)
                {
                    int matrixSign = (i % 2 == 0) ? 1 : -1;
                    determinant += matrixSign * matrix[0][i] * GetDeterminant(GetMinor(matrix, 0, i));
                }

                return determinant;
            }
        }

        public double GetDeterminant()
        {
            double[][] matrix = new double[this.sizeHeight][];
            for (int i = 0; i < sizeHeight; i++)
            {
                matrix[i] = new double[this.sizeWidth];
                for (int j = 0; j < sizeHeight; j++)
                {
                    matrix[i][j] = this.vectors[i].GetValueByIndex(j);
                }
            }
            return GetDeterminant(matrix);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            bool isfirst = true;
            foreach (Vector v in this.vectors)
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

            return sb.ToString();
        }

        public Matrix Transposition()
        {
            Matrix newMatrix = new Matrix(this.sizeWidth, this.sizeHeight);
            for (int i = 0; i < this.sizeWidth; i++)
            {
                newMatrix.SetVectorRowByIndex(this.GetVectorColByIndex(i), i);
            }
            return newMatrix;
        }

        public void MultiplicationVector(Vector v)
        {
            if (v.Size != this.sizeWidth)
            {
                throw new ArgumentException("вектор имеет размер отличный от ширины матрицы!");
            }

            for (int i = 0; i < this.sizeHeight; i++)
            {
                for (int j = 0; j < this.sizeWidth; j++)
                {
                    this.vectors[i].SetValueByIndex(j, this.vectors[i].GetValueByIndex(j) * v.GetValueByIndex(j));
                }
            }
        }

        public void Addition(Matrix m)
        {
            if (this.sizeHeight != m.sizeHeight || this.sizeWidth != m.sizeWidth)
            {
                throw new ArgumentException("размеры матриц не совпадают. сложение матриц невозможно!");
            }

            for (int i = 0; i < this.sizeHeight; i++)
            {
                for (int j = 0; j < this.sizeWidth; j++)
                {
                    this.vectors[i].SetValueByIndex(j, this.vectors[i].GetValueByIndex(j) + m.vectors[i].GetValueByIndex(j));
                }
            }
        }

        public static Matrix GetAddition(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1);
            result.Addition(m2);
            return result;
        }

        public void Subtraction(Matrix m)
        {
            if (this.sizeHeight != m.sizeHeight || this.sizeWidth != m.sizeWidth)
            {
                throw new ArgumentException("размеры матриц не совпадают. сложение матриц невозможно!");
            }

            for (int i = 0; i < this.sizeHeight; i++)
            {
                for (int j = 0; j < this.sizeWidth; j++)
                {
                    this.vectors[i].SetValueByIndex(j, this.vectors[i].GetValueByIndex(j) - m.vectors[i].GetValueByIndex(j));
                }
            }
        }

        public static Matrix GetSubtraction(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1);
            result.Subtraction(m2);
            return result;
        }
    }
}
