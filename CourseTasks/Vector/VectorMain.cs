using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class VectorMain
    {
        static void Main(string[] args)
        {
            try
            {
                double[] array1 = { 1, -2, 5, 2, 72, 42, 38, 3, 23, 90, 8, 45, 243 };
                Vector vector1 = new Vector(array1);
                Console.WriteLine(vector1.ToString());
                Console.WriteLine();

                double[] array2 = { 13, 4, 51, 6, -10 };
                Vector vector2 = new Vector(array2);
                Console.WriteLine(vector2.ToString());
                Console.WriteLine();

                Console.WriteLine("Прибавление одного вектора к другому");
                vector1.Addition(vector2);
                Console.WriteLine(vector1.ToString());
                Console.WriteLine();

                Console.WriteLine("Вычитание одного вектора из другого");
                vector1.Subtraction(vector2);
                Console.WriteLine(vector1.ToString());
                Console.WriteLine();

                Console.WriteLine("Умножение вектора на скаляр -2");
                vector1.MultiplicationScalar(-2);
                Console.WriteLine(vector1.ToString());
                Console.WriteLine();

                Console.WriteLine("Разворот вектора (умножение на -1)");
                vector1.Inversion();
                Console.WriteLine(vector1.ToString());
                Console.WriteLine();

                Console.WriteLine("Получение длины вектора");
                Console.WriteLine(vector1.Length());
                Console.WriteLine();

                Console.WriteLine("Получение компонента вектора по индексу 5");
                Console.WriteLine(vector1.GetValueByIndex(5));
                Console.WriteLine();

                Console.WriteLine("Установка компонента вектора по индексу 5 значения 111");
                vector1.SetValueByIndex(5, 111);
                Console.WriteLine(vector1.ToString());
                Console.WriteLine();

                Console.WriteLine("Проверка на Equals двух векторов");
                if (vector1.Equals(vector2))
                {
                    Console.WriteLine("Вектора совпали!");
                }
                else
                {
                    Console.WriteLine("Вектора НЕ совпали!");
                }
                Console.WriteLine();

                Console.WriteLine("Получение HashCode векторов");
                Console.WriteLine("Вектор 1: " + vector1.GetHashCode());
                Console.WriteLine("Вектор 2: " + vector2.GetHashCode());
                Console.WriteLine();

                Console.WriteLine("Прибавление одного вектора к другому с возвратом результата");
                Vector r1 = Vector.GetAddition(vector1, vector2);
                Console.WriteLine(vector1.ToString());
                Console.WriteLine(vector2.ToString());
                Console.WriteLine(r1.ToString());
                Console.WriteLine();

                Console.WriteLine("Вычитание одного вектора из другого с возвратом результата");
                Vector r2 = Vector.GetSubtraction(vector1, vector2);
                Console.WriteLine(vector1.ToString());
                Console.WriteLine(vector2.ToString());
                Console.WriteLine(r2.ToString());
                Console.WriteLine();

                Console.WriteLine("Произведение одного вектора из другой с возвратом результата");
                Console.WriteLine(vector1.ToString());
                Console.WriteLine(vector2.ToString());
                double scalarSum = Vector.GetMultiplication(vector1, vector2);
                Console.WriteLine("Скалярное произведение векторов: {0:f2}", scalarSum);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
