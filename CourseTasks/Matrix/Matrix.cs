using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Matrix
    {
        private Vector[] vectors;

        public Matrix(int countRows, int countCols)
        {
            if (countRows <= 0 || countCols <= 0)
            {
                throw new ArgumentException("неверное значение размера матрицы");
            }

            this.vectors = new Vector[countRows];
            for (int i = 0; i < this.vectors.Length; i++)
            {
                this.vectors[i] = new Vector(countCols);
            }
        }

        public Matrix(Matrix matrix)
        {
            this.vectors = new Vector[matrix.vectors.Length];
            for (int i = 0; i < matrix.vectors.Length; i++)
            {
                this.vectors[i] = new Vector(matrix.vectors[i]);
            }
        }

        public Matrix(double[,] values)
        {
            if (values.GetLength(0) == 0)
            {
                throw new ArgumentException("передан пустой массив!");
            }

            this.vectors = new Vector[values.GetLength(0)];
            for (int i = 0; i < values.GetLength(0); i++)
            {
                double[] a = new double[values.GetLength(1)];
                for (int j = 0; j < values.GetLength(1); j++)
                {
                    a[j] = values[i, j];
                }
                this.vectors[i] = new Vector(a);
            }
        }

        public Matrix(Vector[] vectors)
        {
            //определяем максимальную длину векторов в массиве векторов
            int sizeVectorsMax = 0;
            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Size > sizeVectorsMax)
                {
                    sizeVectorsMax = vectors[i].Size;
                }
            }

            this.vectors = new Vector[vectors.Length];
            for (int i = 0; i < vectors.Length; i++)
            {
                if (vectors[i].Size < sizeVectorsMax)
                {
                    Vector v = new Vector(sizeVectorsMax);
                    v.Addition(vectors[i]);
                    this.vectors[i] = new Vector(v);
                }
                else
                {
                    this.vectors[i] = new Vector(vectors[i]);
                }
            }
        }

        public int GetCountCols()
        {
            return this.vectors[0].Size;
        }

        public int GetCountRows()
        {
            return this.vectors.Length;
        }

        public Vector GetRowByIndex(int index)
        {
            if (index < 0 || index >= this.vectors.Length)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            return new Vector(this.vectors[index]);
        }

        public void SetRowByIndex(int index, Vector v)
        {
            if (index < 0 || index >= this.vectors.Length)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            if (this.vectors[0] != null && v.Size != this.vectors[0].Size)
            {
                throw new ArgumentException("размер вектора превышает размер ширины матрицы!");
            }

            this.vectors[index] = new Vector(v);
        }

        public Vector GetColByIndex(int index)
        {
            if (this.vectors.Length == 0)
            {
                throw new Exception("произошло обращение к пустой матрице!");
            }
            if (index < 0 || index >= this.GetCountCols())
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            Vector result = new Vector(this.vectors.Length);
            for (int i = 0; i < this.vectors.Length; i++)
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

        private static double[,] GetMinor(double[,] matrix, int excludeI, int excludeJ)
        {
            int sizeMatrix = matrix.GetLength(0);

            double[,] minor = new double[sizeMatrix - 1, sizeMatrix - 1];
            for (int i = 0, ii = 0; i < sizeMatrix; i++)
            {
                if (i == excludeI)
                {
                    continue;
                }

                for (int j = 0, jj = 0; j < sizeMatrix; j++)
                {
                    if (j == excludeJ)
                    {
                        continue;
                    }

                    minor[ii, jj] = matrix[i, j];
                    jj++;
                }

                ii++;
            }
            return minor;
        }

        private static double GetDeterminant(double[,] matrix)
        {
            if (matrix.Length == 1)
            {
                return matrix[0, 0];
            }
            else if (matrix.Length == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
            }
            else
            {
                double determinant = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int matrixSign = (j % 2 == 0) ? 1 : -1;
                    determinant += matrixSign * matrix[0, j] * GetDeterminant(GetMinor(matrix, 0, j));
                }

                return determinant;
            }
        }

        public double GetDeterminant()
        {
            double[,] matrix = new double[this.vectors.Length, this.vectors[0].Size];
            for (int i = 0; i < this.vectors.Length; i++)
            {
                for (int j = 0; j < this.vectors.Length; j++)
                {
                    matrix[i, j] = this.vectors[i].GetValueByIndex(j);
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

        public void Transposition()
        {
            Matrix tmpMatrix = new Matrix(this);

            this.vectors = new Vector[tmpMatrix.vectors[0].Size];
            for (int i = 0; i < tmpMatrix.GetCountCols(); i++)
            {
                this.SetRowByIndex(i, tmpMatrix.GetColByIndex(i));
            }
        }

        public Vector MultiplicationVector(Vector v)
        {
            if (v.Size != this.vectors[0].Size)
            {
                throw new ArgumentException("вектор имеет размер отличный от ширины матрицы!");
            }

            Vector result = new Vector(v.Size);
            for (int i = 0; i < this.vectors.Length; i++)
            {
                double resultSum = 0;
                for (int j = 0; j < v.Size; j++)
                {
                    resultSum += this.vectors[i].GetValueByIndex(j) * v.GetValueByIndex(j);
                }
                result.SetValueByIndex(i, resultSum);
            }
            return result;
        }

        public void Addition(Matrix m)
        {
            if (this.vectors.Length != m.vectors.Length || this.vectors[0].Size != m.vectors[0].Size)
            {
                throw new ArgumentException("размеры матриц не совпадают. сложение матриц невозможно!");
            }

            for (int i = 0; i < this.vectors.Length; i++)
            {
                this.vectors[i].Addition(m.vectors[i]);
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
            if (this.vectors.Length != m.vectors.Length || this.vectors[0].Size != m.vectors[0].Size)
            {
                throw new ArgumentException("размеры матриц не совпадают. сложение матриц невозможно!");
            }

            for (int i = 0; i < this.vectors.Length; i++)
            {
                this.vectors[i].Subtraction(m.vectors[i]);
            }
        }

        public static Matrix GetSubtraction(Matrix m1, Matrix m2)
        {
            Matrix result = new Matrix(m1);
            result.Subtraction(m2);
            return result;
        }

        public static Matrix GetMultiplication(Matrix m1, Matrix m2)
        {
            if (m1.GetCountRows() != m2.GetCountCols() || m1.GetCountCols() != m2.GetCountRows())
            {
                throw new ArgumentException("Умножение матриц невозможно!");
            }
            int resultCountRows = m1.GetCountRows();
            int resultCountCols = m2.GetCountCols();
            Matrix result = new Matrix(resultCountRows, resultCountCols);

            for (int im1 = 0; im1 < resultCountRows; im1++)
            {
                double[] resultArrayRow = new double[resultCountRows];
                for (int im2 = 0; im2 < resultCountCols; im2++)
                {
                    for (int jm1 = 0; jm1 < m1.GetCountCols(); jm1++)
                    {
                        resultArrayRow[im2] += m1.vectors[im1].GetValueByIndex(jm1) * m2.vectors[jm1].GetValueByIndex(im2);
                    }
                }
                result.SetRowByIndex(im1, new Vector(resultArrayRow));
            }
            return result;
        }
    }
}
