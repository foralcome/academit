using System;
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
        private double Lenght
        {
            get;
            set;
        }

        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
            this.Lenght = from - to;
        }

        public bool IsInside(double value)
        {
            return (value >= this.From && this.To >= value);
        }

        public void PrintRange()
        {
            Console.WriteLine("Интервал от {0} до {1}", this.From, this.To);
        }

        //Получение пересечения двух интервалов.
        public static Range GetOverlap(Range r1, Range r2)
        {
            //проверка на попадание хотябы одного края
            if (!r1.IsInside(r2.From) && !r1.IsInside(r2.To) && !r2.IsInside(r1.From) && !r2.IsInside(r1.To))
            {
                return null;
            }

            double rangeOverlapStart = 0;
            if (r1.IsInside(r2.From))
            {
                rangeOverlapStart = r2.From;
            }
            else
            {
                rangeOverlapStart = r1.From;
            }

            double rangeOverlapStop = 0;
            if (r1.IsInside(r2.To))
            {
                rangeOverlapStop = r2.To;
            }
            else
            {
                rangeOverlapStop = r1.To;
            }

            return new Range(rangeOverlapStart, rangeOverlapStop);
        }

        //Получение объединения двух интервалов. Может получиться 1 или 2 отдельных куска
        public static Range[] GetMarge(Range r1, Range r2)
        {
            Range[] arrayRange;

            //если есть хотя бы одно пересечение, то это 1 кусок
            if (r1.IsInside(r2.From) || r1.IsInside(r2.To) || r2.IsInside(r1.From) || r2.IsInside(r1.To))
            {
                arrayRange = new Range[1];
                arrayRange[0] = new Range(Math.Min(r1.From, r2.From), Math.Max(r1.To, r2.To));
                return arrayRange;
            }
            else
            {
                arrayRange = new Range[2];
                if (r1.From > r2.From)
                {
                    arrayRange[0] = r2;
                    arrayRange[1] = r1;
                }
                else
                {
                    arrayRange[0] = r1;
                    arrayRange[1] = r2;
                }
                return arrayRange;
            }
        }

        //Разность(отличие): то, что входит в R1 и не входит в R2
        public static Range[] GetDifference(Range r1, Range r2)
        {
            Range[] arrayRange;

            //если нет ни одного пересечения
            if (!r1.IsInside(r2.From) && !r1.IsInside(r2.To) && !r2.IsInside(r1.From) && !r2.IsInside(r1.To))
            {
                arrayRange = new Range[1];
                arrayRange[0] = r1;
                return arrayRange;
            }
            //одно множество полностью входит в другое, то в результате два множества
            else if ((r1.IsInside(r2.From) && r1.IsInside(r2.To)) || (r2.IsInside(r1.From) && r2.IsInside(r1.To)))
            {
                //второе множество входит в первое
                if (r1.IsInside(r2.From))
                {
                    arrayRange = new Range[2];

                    if (r1.From > r2.From)
                    {
                        arrayRange[0] = new Range(r2.From, r1.From);
                        arrayRange[1] = new Range(r1.To, r2.To);
                    }
                    else
                    {
                        arrayRange[0] = new Range(r1.From, r2.From);
                        arrayRange[1] = new Range(r2.To, r1.To);
                    }
                }
                //первое множество полностью перекрывается вторым
                //после вычитания от первого ничего не остаётся
                else
                {
                    arrayRange = new Range[1];
                    arrayRange[0] = new Range(0, 0);
                }

                return arrayRange;
            }
            //частичное пересечение множеств, в результате одно множество
            else
            {
                arrayRange = new Range[1];

                //определение границы r2, попадающей в r1
                if (r1.IsInside(r2.From))
                {
                    arrayRange[0] = new Range(r1.From, r2.From);
                }
                else
                {
                    arrayRange[0] = new Range(r2.To, r1.To);
                }

                //arrayRange[0] = new RangeStar(Math.Min(r1.f));
                return arrayRange;
            }
        }
    }
}
