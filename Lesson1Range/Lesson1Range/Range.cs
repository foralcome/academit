using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1Range
{
    class Range
    {
        private double from;
        private double to;

        Range(double from, double to)
        {
            this.from = from;
            this.to = to;
        }

        public double GetLength()
        {
            return (to - from);
        }

        public bool IsInside(double value)
        {
            double epsilon = 1e-10;
            return ((value - from) >= epsilon && (to - value) >= epsilon);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите сумму вашего заказа");
            double orderSum = Convert.ToDouble(Console.ReadLine());

            Range deliveryRange1 = new Range(0, 999);
            Console.WriteLine("Длина диапазона 1 = {0}", deliveryRange1.GetLength());

            Range deliveryRange2 = new Range(1000, 1999);
            Console.WriteLine("Длина диапазона 2 = {0}", deliveryRange2.GetLength());

            if (deliveryRange1.IsInside(orderSum))
            {
                Console.WriteLine("Стоимость доставки вашего заказа составит 200 рублей");
            }
            else if (deliveryRange2.IsInside(orderSum))
            {
                Console.WriteLine("Стоимость доставки вашего заказа составит 100 рублей");
            }
            else
            {
                Console.WriteLine("У вас бесплатная доставка!");
            }
        }
    }
}
