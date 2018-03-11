﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class Range
    {
        private double From
        {
            get;
            set;
        }

        private double To
        {
            get;
            set;
        }
        private double Length
        {
            get;
        }

        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
            this.Length = from - to;
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
        public Range GetOverlap(Range range)
        {
            //отсутствие пересечения
            if ((this.From <= range.From && this.To < range.From) || (range.From <= this.From && range.To < this.From))
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
        public Range[] GetMarge(Range range)
        {
            Range[] arrayRange;

            //отсутствие пересечения
            if ((this.From <= range.From && this.To < range.From) || (range.From <= this.From && range.To < this.From))
            {
                arrayRange = new Range[2];
                if (this.From > range.From)
                {
                    arrayRange[0] = new Range(range.From, range.To);
                    arrayRange[1] = new Range(this.From, this.To);
                }
                else
                {
                    arrayRange[0] = new Range(this.From, this.To);
                    arrayRange[1] = new Range(range.From, range.To);
                }
            }
            //есть пересечение
            else
            {
                arrayRange = new Range[1];
                arrayRange[0] = new Range(Math.Min(this.From, range.From), Math.Max(this.To, range.To));
            }
            return arrayRange;
        }

        //Разность(отличие): то, что входит в this и не входит в R2
        public Range[] GetDifference(Range range)
        {
            Range[] arrayRange;

            //отсутствие пересечения
            if ((this.From <= range.From && this.To < range.From) || (range.From <= this.From && range.To < this.From))
            {
                arrayRange = new Range[1];
                arrayRange[0] = new Range(this.From, this.To);
            }
            //есть пересечение
            else
            {
                //первое полностью входит во второе
                if (this.From >= range.From && this.To <= range.To)
                {
                    return (new Range[0]);
                }
                //второе полностью входит в первое
                else if (range.From >= this.From && range.To <= this.To)
                {
                    arrayRange = new Range[2];

                    arrayRange[0] = new Range(this.From, range.From);
                    arrayRange[1] = new Range(range.To, this.To);
                }
                //пересечение первого справа
                else if (range.From >= this.From)
                {
                    arrayRange = new Range[1];
                    arrayRange[0] = new Range(this.From, range.From);
                }
                //пересечение первого слева
                else
                {
                    arrayRange = new Range[1];
                    arrayRange[0] = new Range(range.To, this.To);
                }
            }

            return arrayRange;
        }
    }
}
