using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class ShapesMain
    {
        public static Shapes GetShapeWithMaxArea(Array shapes)
        {
            Shapes shapeMaxArea = null;

            foreach (Shapes s in shapes)
            {
                if (shapeMaxArea == null)
                {
                    shapeMaxArea = s;
                    continue;
                }

                if (shapeMaxArea.CompareTo(s) < 0)
                {
                    shapeMaxArea = s;
                }
            }

            return shapeMaxArea;
        }

        static void Main(string[] args)
        {
            List<Shapes> shapes = new List<Shapes>();
            shapes.Add(new Square(10));
            shapes.Add(new Triangle(0, 0, 10, 10, 10, 0));
            shapes.Add(new Rectangle(10, 6));
            shapes.Add(new Circle(12));
            shapes.Add(new Square(5));
            shapes.Add(new Triangle(3, 3, 0, 0, 3, 0));
            shapes.Add(new Rectangle(7, 8));
            shapes.Add(new Circle(6));
            shapes.Add(new Square(6));
            shapes.Add(new Triangle(0, 5, 5, 5, 5, 0));
            shapes.Add(new Rectangle(10, 2));
            shapes.Add(new Circle(14));
            shapes.Add(new Square(7));
            shapes.Add(new Triangle(6, 6, 0, 0, 6, 0));
            shapes.Add(new Rectangle(3, 15));
            shapes.Add(new Circle(5));

            Console.WriteLine("Исходный список фигур:");
            foreach (Shapes shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("Отсортированный список фигур:");
            Array shapesSort = shapes.ToArray();
            Array.Sort(shapesSort);
            foreach (Shapes shape in shapesSort)
            {
                Console.WriteLine(shape.ToString());
            }
            Console.WriteLine();

            Shapes s1 = null;
            if (shapesSort.Length >= 1)
            {
                s1 = (Shapes)shapesSort.GetValue(shapesSort.Length - 1);
                Console.WriteLine("Фигура на 1 месте по размеру площади: {0}", s1.ToString());
            }
            Shapes s2 = null;
            if (shapesSort.Length >= 2)
            {
                s2 = (Shapes)shapesSort.GetValue(shapesSort.Length - 2);
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
