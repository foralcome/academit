using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class ArrayLisMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание списка целочисленных значений");
            ArrayList<int> parts = new ArrayList<int>(10);
            parts.Add(11);
            parts.Add(12);
            parts.Add(13);
            parts.Add(14);
            parts.Add(15);
            parts.Add(16);
            parts.Add(17);
            parts.Add(18);
            parts.Add(19);
            parts.Add(20);
            Console.WriteLine("Список: {0}", parts.ToString());
            Console.WriteLine("Элементов: {0}", parts.Count);
            Console.WriteLine("Вместимость: {0}", parts.Capacity);
            Console.WriteLine();

            Console.WriteLine("1) Изменение Capacity на 20 ");
            parts.Capacity = 20;
            Console.WriteLine("Список: {0}", parts.ToString());
            Console.WriteLine("Элементов: {0}", parts.Count);
            Console.WriteLine("Вместимость: {0}", parts.Capacity);
            Console.WriteLine();

            Console.WriteLine("2) Получение значения списка по индексу 3 ");
            Console.WriteLine("Значение: {0}", parts[3]);
            Console.WriteLine();

            Console.WriteLine("3) Изменение Copacity по фактическому количеству элементов в списке");
            parts.TrimExcess();
            Console.WriteLine("Список: {0}", parts.ToString());
            Console.WriteLine("Элементов: {0}", parts.Count);
            Console.WriteLine("Вместимость: {0}", parts.Capacity);
            Console.WriteLine();

            Console.WriteLine("4) Добавление нового элемента 21 в конец списка");
            parts.Add(21);
            Console.WriteLine("Список: {0}", parts.ToString());
            Console.WriteLine("Элементов: {0}", parts.Count);
            Console.WriteLine("Вместимость: {0}", parts.Capacity);
            Console.WriteLine();

            Console.WriteLine("5) Добавление нового элемента 22 по индексу 2");
            parts.Insert(2,22);
            Console.WriteLine("Список: {0}", parts.ToString());
            Console.WriteLine("Элементов: {0}", parts.Count);
            Console.WriteLine("Вместимость: {0}", parts.Capacity);
            Console.WriteLine();

            Console.WriteLine("6) Удаление элемента по индексу 0");
            parts.RemoveAt(0);
            Console.WriteLine("Список: {0}", parts.ToString());
            Console.WriteLine("Элементов: {0}", parts.Count);
            Console.WriteLine("Вместимость: {0}", parts.Capacity);
            Console.WriteLine();

            Console.WriteLine("7) Удаление элемента по значению 16");
            parts.Remove(16);
            Console.WriteLine("Список: {0}", parts.ToString());
            Console.WriteLine("Элементов: {0}", parts.Count);
            Console.WriteLine("Вместимость: {0}", parts.Capacity);
            Console.WriteLine();

            Console.WriteLine("8) Удаление диапазона элементов с 1 по 5 индекс");
            parts.RemoveRange(1, 5);
            Console.WriteLine("Список: {0}", parts.ToString());
            Console.WriteLine("Элементов: {0}", parts.Count);
            Console.WriteLine("Вместимость: {0}", parts.Capacity);
            Console.WriteLine();

            Console.WriteLine("9) Проверка наличия элемента в списке по значению");
            Console.WriteLine("Результат проверки элемента 12: {0}", parts.Contains(12));
            Console.WriteLine("Результат проверки элемента 14: {0}", parts.Contains(14));
            Console.WriteLine();

            Console.WriteLine("10) Поиск элемента в списке и получение его индекса");
            Console.WriteLine("Результат проверки элемента 12: {0}", parts.IndexOf(12));
            Console.WriteLine("Результат проверки элемента 14: {0}", parts.IndexOf(14));
            Console.WriteLine();

            Console.WriteLine("11) Копирование списка в массив");
            Console.WriteLine("Исходный список: {0}", parts.ToString());
            int[] arrayParts = new int[parts.Count];
            parts.CopyTo(arrayParts, 1);
            Console.WriteLine("Скопированный массив: ");
            bool isFirst = true;
            Console.Write("{");
            foreach (int a in arrayParts)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    Console.Write(", ");
                }
                Console.Write(a);
            }
            Console.Write("}");
            Console.WriteLine();
        }
    }
}
