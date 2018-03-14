using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class ShapeMain
    {
        static void Main(string[] args)
        {
            List<IShape> ListShapes = new List<IShape>();
            ListShapes.Add(new Square(10));
            ListShapes.Add(new Triangle(0, 0, 10, 10, 10, 0));
            ListShapes.Add(new Rectangle(10, 6));
            ListShapes.Add(new Circle(12));
            ListShapes.Add(new Square(5));
            ListShapes.Add(new Triangle(3, 3, 0, 0, 3, 0));
            ListShapes.Add(new Rectangle(7, 8));
            ListShapes.Add(new Circle(6));
            ListShapes.Add(new Square(6));
            ListShapes.Add(new Triangle(0, 5, 5, 5, 5, 0));
            ListShapes.Add(new Rectangle(10, 2));
            ListShapes.Add(new Circle(14));
            ListShapes.Add(new Square(7));
            ListShapes.Add(new Triangle(6, 6, 0, 0, 6, 0));
            ListShapes.Add(new Rectangle(3, 15));
            ListShapes.Add(new Circle(5));

            Console.WriteLine("Исходный список фигур:");
            foreach (IShape shape in ListShapes)
            {
                Console.WriteLine(shape.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Отсортированный список фигур:");
            IShape[] ArrayShapes = ListShapes.ToArray();
            Array.Sort(ArrayShapes, new ShapesCompareArea());
            foreach (IShape shape in ArrayShapes)
            {
                Console.WriteLine(shape.ToString());
            }
            Console.WriteLine();

            IShape s1 = null;
            if (ArrayShapes.Length >= 1)
            {
                s1 = (IShape)ArrayShapes.GetValue(ArrayShapes.Length - 1);
                Console.WriteLine("Фигура на 1 месте по размеру площади: {0}", s1.ToString());
            }
            IShape s2 = null;
            if (ArrayShapes.Length >= 2)
            {
                s2 = (IShape)ArrayShapes.GetValue(ArrayShapes.Length - 2);
                Console.WriteLine("Фигура на 2 месте по размеру площади: {0}", s2.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Проверка на идентичность (Equals):");
            if (s1.Equals(s2))
            {
                Console.WriteLine("Фигуры идентичны");
            }
            else
            {
                Console.WriteLine("Фигуры НЕ идентичны");
            }
            Console.WriteLine();

            Console.WriteLine("Хэш код и сравнение:");
            int hashShape1 = s1.GetHashCode();
            int hashShape2 = s2.GetHashCode();
            if (hashShape1 != hashShape2)
            {
                Console.WriteLine("Фигуры не одинаковые (хэш-коды фигур отличаются {0}!={1})", hashShape1, hashShape2);
            }
            else
            {
                Console.WriteLine("Фигуры возможно одинаковые (хэш-коды фигур совпадают {0}=={1})", hashShape1, hashShape2);
            }

        }
    }
}
