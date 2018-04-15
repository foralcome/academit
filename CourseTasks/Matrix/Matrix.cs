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

        public Matrix(int rowsCount, int colsCount)
        {
            if (rowsCount <= 0 || colsCount <= 0)
            {
                throw new ArgumentException("размер матрицы должен быть > 0!");
            }

            this.vectors = new Vector[rowsCount];
            for (int i = 0; i < this.vectors.Length; i++)
            {
                this.vectors[i] = new Vector(colsCount);
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
            if (values.GetLength(0) == 0 || values.GetLength(1) == 0)
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
            if (vectors.Length == 0)
            {
                throw new ArgumentException("передан пустой массив!");
            }

            //определяем максимальную длину векторов в массиве векторов
            int sizeVectorsMax = 0;
            foreach (Vector v in vectors)
            {
                if (v.Size > sizeVectorsMax)
                {
                    sizeVectorsMax = v.Size;
                }
            }

            if (sizeVectorsMax == 0)
            {
                throw new ArgumentException("полученные вектора являются пустыми!");
            }

            this.vectors = new Vector[vectors.Length];
            for (int i = 0; i < vectors.Length; i++)
            {
                Vector v = new Vector(sizeVectorsMax);
                v.Addition(vectors[i]);
                this.vectors[i] = v;
            }
        }

        public int ColsCount
        {
            get
            {
                return this.vectors[0].Size;
            }
        }

        public int RowsCount
        {
            get
            {
                return this.vectors.Length;
            }
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

            if (v.Size != this.ColsCount)
            {
                throw new ArgumentException("не верный размер вектора!");
            }

            this.vectors[index] = new Vector(v);
        }

        public Vector GetColByIndex(int index)
        {
            if (index < 0 || index >= this.ColsCount)
            {
                throw new IndexOutOfRangeException("передан не верный индекс!");
            }

            Vector result = new Vector(this.RowsCount);
            for (int i = 0; i < this.RowsCount; i++)
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
            if (this.vectors.Length != this.ColsCount)
            {
                throw new Exception("для расчёта детерминанта необходима квадратная матрица!");
            }

            double[,] matrix = new double[this.vectors.Length, this.ColsCount];
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
            int countRows = this.ColsCount;
            int countCols = this.RowsCount;

            Vector[] oldVectors = this.vectors;
            this.vectors = new Vector[countRows];

            for (int i = 0; i < countRows; i++)
            {
                this.vectors[i] = new Vector(countCols);
                for (int j = 0; j < countCols; j++)
                {
                    this.vectors[i].SetValueByIndex(j, oldVectors[j].GetValueByIndex(i));
                }
            }
        }

        public Vector MultiplicationVector(Vector v)
        {
            if (v.Size != this.ColsCount)
            {
                throw new ArgumentException("число столбцов в матрице должно совпадать с числом строк в векторе-столбце!");
            }

            Vector result = new Vector(this.RowsCount);
            for (int i = 0; i < this.RowsCount; i++)
            {
                result.SetValueByIndex(i, Vector.GetMultiplication(this.vectors[i], v));
            }
            return result;
        }

        public void Addition(Matrix m)
        {
            if (this.vectors.Length != m.vectors.Length || this.ColsCount != m.ColsCount)
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
            if (m1.vectors.Length != m2.vectors.Length || m1.ColsCount != m2.ColsCount)
            {
                throw new ArgumentException("размеры матриц не совпадают. сложение матриц невозможно!");
            }

            Matrix result = new Matrix(m1);
            result.Addition(m2);
            return result;
        }

        public void Subtraction(Matrix m)
        {
            if (this.vectors.Length != m.vectors.Length || this.ColsCount != m.ColsCount)
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
            if (m1.vectors.Length != m2.vectors.Length || m1.ColsCount != m2.ColsCount)
            {
                throw new ArgumentException("размеры матриц не совпадают. сложение матриц невозможно!");
            }

            Matrix result = new Matrix(m1);
            result.Subtraction(m2);
            return result;
        }

        public static Matrix GetMultiplication(Matrix m1, Matrix m2)
        {
            if (m1.RowsCount != m2.ColsCount || m1.ColsCount != m2.RowsCount)
            {
                throw new ArgumentException("Умножение матриц невозможно!");
            }
            int resultCountRows = m1.RowsCount;
            int resultCountCols = m2.ColsCount;
            Matrix result = new Matrix(resultCountRows, resultCountCols);

            for (int im1 = 0; im1 < resultCountRows; im1++)
            {
                Vector resultVector = new Vector(resultCountCols);
                for (int im2 = 0; im2 < resultCountCols; im2++)
                {
                    resultVector.SetValueByIndex( im2, Vector.GetMultiplication(m1.vectors[im1], m2.GetColByIndex(im2)));
                }
                result.vectors[im1] = resultVector;
            }
            return result;
        }
    }
}
