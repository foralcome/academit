using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Range
    {
        public double From
        {
            get;
            set;
        }

        public double To
        {
            get;
            set;
        }

        public double Length
        {
            get
            {
                return To - From;
            }
        }

        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
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
            if ((this.To <= range.From) || (this.From >= range.To))
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
                    return new Range[] { new Range(range.From, range.To), new Range(this.From, this.To) };
                }
                else
                {
                    return new Range[] { new Range(this.From, this.To), new Range(range.From, range.To) };
                }
            }
            //есть пересечение
            else
            {
                return new Range[] { new Range(Math.Min(this.From, range.From), Math.Max(this.To, range.To)) };
            }
        }

        //Разность(отличие): то, что входит в this и не входит в R2
        public Range[] GetDifference(Range range)
        {
            //отсутствие пересечения
            if ((this.To <= range.From) || (this.From >= range.To))
            {
                return new Range[] { new Range(this.From, this.To) };
            }
            //есть пересечение
            else
            {
                //первое полностью входит во второе
                if (this.From >= range.From && this.To <= range.To)
                {
                    return new Range[] { };
                }
                //второе полностью входит в первое
                else if (range.From >= this.From && range.To <= this.To)
                {
                    if (this.From == range.From)
                    {
                        return new Range[] { new Range(range.To, this.To) };
                    }
                    else if (this.To == range.To)
                    {
                        return new Range[] { new Range(this.From, range.From) };
                    }
                    else
                    {
                        return new Range[] { new Range(this.From, range.From), new Range(range.To, this.To) };
                    }
                }
                //пересечение первого справа
                else if (range.From >= this.From)
                {
                    return new Range[] { new Range(this.From, range.From) };
                }
                //пересечение первого слева
                else
                {
                    return new Range[] { new Range(range.To, this.To) };
                }
            }
        }
    }
}
