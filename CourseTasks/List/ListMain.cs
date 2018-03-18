using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class ListMain
    {
        static void Main(string[] args)
        {
            double[] a1 = { 1, -2, 5, 2, 72, 42, 38, 3, 23, 90, 8, 45, 243 };
            List l1 = new List(a1);
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine("Размер списка: {0}", l1.GetLength());
            Console.WriteLine();

            Console.WriteLine("Получение значения по индексу 2: {0}", l1.GetValueByIndex(2));
            Console.WriteLine();

            Console.WriteLine("Изменение значения по индексу 2 значения {0} на 555", l1.SetValueByIndex(2, 555));
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine();

            Console.WriteLine("Удаление элемента по индексу 2 со значением {0}", l1.DeleteNodeByIndex(2));
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine("Размер списка: {0}", l1.GetLength());
            Console.WriteLine();

            Console.WriteLine("Вставка элемента 111 в начало");
            l1.InsertNodeToBegin(new ListNode(111));
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine("Размер списка: {0}", l1.GetLength());
            Console.WriteLine();

            Console.WriteLine("Вставка элемента по индексу 2");
            l1.InsertNodeByIndex(2, new ListNode(222));
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine("Размер списка: {0}", l1.GetLength());
            Console.WriteLine();

            Console.WriteLine("Удаление узла по значению 22");
            if (l1.DeleteNodeByValue(22) == false)
            {
                Console.WriteLine("Узел со значением 22 не найден!");
            }
            else
            {
                Console.WriteLine("Узел удалён!");
            }
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine("Размер списка: {0}", l1.GetLength());
            Console.WriteLine();

            Console.WriteLine("Удаление узла по значению 222");
            if (l1.DeleteNodeByValue(222) == false)
            {
                Console.WriteLine("Узел со значением 222 не найден!");
            }
            else
            {
                Console.WriteLine("Узел удалён!");
            }
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine("Размер списка: {0}", l1.GetLength());
            Console.WriteLine();

            Console.WriteLine("Удаление первого элемента со значением {0}", l1.DeleteNodeFromBegin());
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine("Размер списка: {0}", l1.GetLength());
            Console.WriteLine();

            Console.WriteLine("Разворот списка за линейное время");
            l1.Rotate();
            Console.WriteLine("Список: {0}", l1.ToString());
            Console.WriteLine("Размер списка: {0}", l1.GetLength());
            Console.WriteLine();

            Console.WriteLine("копирование списка");
            List copyList = l1.Copy();
            Console.WriteLine("Скопированный список: {0}", copyList.ToString());
            Console.WriteLine("Размер списка: {0}", copyList.GetLength());
            Console.WriteLine();
        }
    }
}
