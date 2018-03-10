using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class RangeMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа работы с интервалами");

            do
            {
                Console.Clear();

                Console.WriteLine("Первый диапазон:");
                Console.WriteLine("Введите начальное значение диапазона:");
                double range1Start = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите конечное значение диапазона:");
                double range1Stop = Convert.ToDouble(Console.ReadLine());
                Range r1 = new Range(range1Start, range1Stop);
                r1.PrintRange();
                Console.WriteLine();

                Console.WriteLine("Второй диапазон:");
                Console.WriteLine("Введите начальное значение диапазона:");
                double range2Start = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите конечное значение диапазона:");
                double range2Stop = Convert.ToDouble(Console.ReadLine());
                Range r2 = new Range(range2Start, range2Stop);
                r2.PrintRange();
                Console.WriteLine();

                Console.WriteLine("1) Поиск пересечения диапазонов:");
                Range o12 = Range.GetOverlap(r1, r2);
                if (o12 == null)
                {
                    Console.WriteLine("Персесечения нет!");
                }
                else
                {
                    o12.PrintRange();
                }
                Console.WriteLine();

                Console.WriteLine("2) Объединение двух интервалов в один:");
                Range[] m12 = Range.GetMarge(r1, r2);
                Console.WriteLine("Объединённый интервал состоит из {0} части(ей):", m12.Length);
                for (int i = 1; i <= m12.Length; i++)
                {
                    Console.WriteLine("Часть {0}:", i);
                    m12[i - 1].PrintRange();
                    Console.WriteLine();
                }

                Console.WriteLine("3) Разница двух интервалов:");
                Range[] d12 = Range.GetDifference(r1, r2);
                Console.WriteLine("Разница интервалов состоит из {0} части(ей):", d12.Length);
                for (int i = 1; i <= d12.Length; i++)
                {
                    Console.WriteLine("Часть {0}:", i);
                    d12[i - 1].PrintRange();
                    Console.WriteLine();
                }

                Console.WriteLine("Для продолжения нажмите на любую клавишу, для выхода нажмите ESC");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
