using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Range
    {
        private double from;
        public double From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
                length = from - to;
            }
        }

        private double to;
        public double To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
                length = from - to;
            }
        }

        private double length;
        public double Length
        {
            get
            {
                return length;
            }
        }

        public Range(double from, double to)
        {
            this.from = from;
            this.to = to;
            this.length = from - to;
        }

        public bool IsInside(double value)
        {
            return (value >= this.From && this.To >= value);
        }

        public void Print()
        {
            Console.WriteLine("Интервал от {0} до {1}", this.From, this.To);
        }

        //Получение пересечения двух интервалов (r1-this)
        public Range GetIntersection(Range range)
        {
            //отсутствие пересечения
            if ((this.To < range.From) || (this.From > range.To))
            {
                return null;
            }
            else
            {
                //первое полностью входит во второе
                if (this.From >= range.From && this.To <= range.To)
                {
                    return new Range(this.From, this.To);
                }
                //второе полностью входит в первое
                else if (range.From >= this.From && range.To <= this.To)
                {
                    return new Range(range.From, range.To);
                }
                //пересечение первого справа
                else if (range.From >= this.From)
                {
                    return new Range(range.From, this.To);
                }
                //пересечение первого слева
                else
                {
                    return new Range(this.From, range.To);
                }
            }
        }

        //Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска
        public Range[] GetUnion(Range range)
        {
            //отсутствие пересечения
            if ((this.To < range.From) || (this.From > range.To))
            {
                if (this.From > range.From)
                {
                    Range[] arrayRange2 = { new Range(range.From, range.To), new Range(this.From, this.To) };
                    return arrayRange2;
                }
                else
                {
                    Range[] arrayRange2 = { new Range(this.From, this.To), new Range(range.From, range.To) };
                    return arrayRange2;
                }
            }
            //есть пересечение
            else
            {
                Range[] arrayRange1 = { new Range(Math.Min(this.From, range.From), Math.Max(this.To, range.To)) };
                return arrayRange1;
            }
        }

        //Разность(отличие): то, что входит в this и не входит в R2
        public Range[] GetDifference(Range range)
        {
            //отсутствие пересечения
            if ((this.To < range.From) || (this.From > range.To))
            {
                Range[] arrayRange1 = { new Range(this.From, this.To) };
                return arrayRange1;
            }
            //есть пересечение
            else
            {
                //первое полностью входит во второе
                if (this.From >= range.From && this.To <= range.To)
                {
                    Range[] arrayRange1 = { };
                    return arrayRange1;
                }
                //второе полностью входит в первое
                else if (range.From >= this.From && range.To <= this.To)
                {
                    Range[] arrayRange2 = { new Range(this.From, range.From), new Range(range.To, this.To) };
                    return arrayRange2;
                }
                //пересечение первого справа
                else if (range.From >= this.From)
                {
                    Range[] arrayRange1 = { new Range(this.From, range.From) };
                    return arrayRange1;
                }
                //пересечение первого слева
                else
                {
                    Range[] arrayRange1 = { new Range(range.To, this.To) };
                    return arrayRange1;
                }
            }
        }
    }
}
