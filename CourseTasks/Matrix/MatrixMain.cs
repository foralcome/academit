using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class MatrixMain
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Конструктор 1");
                Matrix m1 = new Matrix(4, 5);
                m1.SetVectorRowByIndex(new Vector(new double[] { 12, 1, 4, 0, -2 }), 0);
                m1.SetVectorRowByIndex(new Vector(new double[] { 3, 77, -8, 9, 1 }), 1);
                m1.SetVectorRowByIndex(new Vector(new double[] { 4, -21, 13, 31, 99 }), 2);
                Console.WriteLine(m1.ToString());
                Console.WriteLine("Размер матрицы: {0} x {1}", m1.GetHeight(), m1.GetWidth());
                Console.WriteLine();

                Console.WriteLine("Конструктор 2");
                Matrix m2 = new Matrix(m1);
                Console.WriteLine(m2.ToString());
                Console.WriteLine("Размер матрицы: {0} x {1}", m2.GetHeight(), m2.GetWidth());
                Console.WriteLine();

                Console.WriteLine("Конструктор 3");
                double[][] a3 = new double[3][];
                a3[0] = new double[] { 1, 2, 3, 4 };
                a3[1] = new double[] { 5, 6, 7, 8 };
                a3[2] = new double[] { 9, 10, 0, -1 };
                Matrix m3 = new Matrix(a3);
                Console.WriteLine(m3.ToString());
                Console.WriteLine("Размер матрицы: {0} x {1}", m3.GetHeight(), m3.GetWidth());
                Console.WriteLine();

                Console.WriteLine("Конструктор 4");
                Vector[] av4 = new Vector[4];
                av4[0] = new Vector(new double[] { 4, 3, 2, 1 });
                av4[1] = new Vector(new double[] { 5, 6, 7, 8 });
                av4[2] = new Vector(new double[] { 12, 11, 10, 9 });
                av4[3] = new Vector(new double[] { 13, 14, 15, 16 });
                Matrix m4 = new Matrix(av4);
                Console.WriteLine(m4.ToString());
                Console.WriteLine("Размер матрицы: {0} x {1}", m4.GetHeight(), m4.GetWidth());
                Console.WriteLine();

                Console.WriteLine("Получение вектора-строки по индексу");
                Console.WriteLine("Матрица: {0}", m4.ToString());
                Console.WriteLine("Индекс: {0}", 1);
                Console.WriteLine(m4.GetVectorRowByIndex(1).ToString());
                Console.WriteLine();

                Console.WriteLine("Задание вектора-строки по индексу");
                Console.WriteLine("Матрица: {0}", m4.ToString());
                Console.WriteLine("Индекс: {0}", 1);
                Vector v4 = new Vector(new double[] { 12, 23, 45, 56 });
                Console.WriteLine("Строка: {0}", v4.ToString());
                m4.SetVectorRowByIndex(v4, 1);
                Console.WriteLine(m4.ToString());
                Console.WriteLine();

                Console.WriteLine("Получение вектора-столбца по индекс");
                Console.WriteLine("Индекс: {0}", 2);
                Console.WriteLine("Строка: {0}", m4.GetVectorColByIndex(2).ToString());
                Console.WriteLine();

                Console.WriteLine("Транспонирование матрицы");
                Console.WriteLine("Матрица до: {0}", m4.ToString());
                Console.WriteLine("Размер матрицы: {0} x {1}", m4.GetHeight(), m4.GetWidth());
                Matrix m4Transform = m4.Transposition();
                Console.WriteLine("Матрица после: {0}", m4Transform.ToString());
                Console.WriteLine("Размер матрицы: {0} x {1}", m4Transform.GetHeight(), m4Transform.GetWidth());
                Console.WriteLine();

                Console.WriteLine("Умножение матрицы на скаляр");
                Console.WriteLine("Матрица до: {0}", m4.ToString());
                Console.WriteLine("Скаляр: 2");
                m4.MultiplicationScalar(2);
                Console.WriteLine("Матрица после: {0}", m4.ToString());
                Console.WriteLine();

                Console.WriteLine("Вычисление определителя матрицы");
                double[][] a5 = new double[3][];
                a5[0] = new double[] { 1, -2, 3 };
                a5[1] = new double[] { 0, 7, 4 };
                a5[2] = new double[] { 5, 3, -3 };
                Matrix m5 = new Matrix(a5);
                Console.WriteLine("Матрица: {0}", m5.ToString());
                Console.WriteLine("Определитель: {0}", m5.GetDeterminant());
                Console.WriteLine();

                Console.WriteLine("Умножение матрицы на вектор");
                Console.WriteLine("Матрица: {0}", m5.ToString());
                Vector v6 = new Vector(new double[] { -1, 2, 0 });
                Console.WriteLine("Вектор: {0}", v6.ToString());
                m5.MultiplicationVector(v6);
                Console.WriteLine("Рузультат: {0}", m5.ToString());
                Console.WriteLine();

                Console.WriteLine("Сложение двух матриц");
                Console.WriteLine("Матрица 1: {0}", m5.ToString());
                double[][] a7 = new double[3][];
                a7[0] = new double[] { 3, 0, 1 };
                a7[1] = new double[] { 2, -4, 1 };
                a7[2] = new double[] { -1, -3, -5 };
                Matrix m7 = new Matrix(a7);
                Console.WriteLine("Матрица 2: {0}", m7.ToString());
                m7.Addition(m5);
                Console.WriteLine("Рузультат: {0}", m7.ToString());
                Console.WriteLine();

                Console.WriteLine("Вычитание двух матриц");
                Console.WriteLine("Матрица 1: {0}", m7.ToString());
                Console.WriteLine("Матрица 2: {0}", m5.ToString());
                m7.Subtraction(m5);
                Console.WriteLine("Рузультат: {0}", m7.ToString());
                Console.WriteLine();

                Console.WriteLine("Сложение двух матриц с возвратом результата");
                Console.WriteLine("Матрица 1: {0}", m5.ToString());
                Console.WriteLine("Матрица 2: {0}", m7.ToString());
                Matrix r8 = Matrix.GetAddition(m5, m7);
                Console.WriteLine("Рузультат: {0}", r8.ToString());
                Console.WriteLine();

                Console.WriteLine("Вычитание двух матриц с возвратом результата");
                Console.WriteLine("Матрица 1: {0}", m5.ToString());
                Console.WriteLine("Матрица 2: {0}", m7.ToString());
                Matrix r9 = Matrix.GetSubtraction(m5, m7);
                Console.WriteLine("Рузультат: {0}", r9.ToString());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
