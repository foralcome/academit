using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class CsvMain
    {
        static void Main(string[] args)
        {
            CsvParser p = new CsvParser(args[0], 3, ',', Encoding.UTF8);
            if (p.ParseInHtmlFile(args[1]))
            {
                Console.WriteLine("Операция чтения файла CSV выполнена успешно! Обработано {0} строк(и).", p.GetCountRecords());
                System.Diagnostics.Process.Start(args[1]);
            }
        }
    }
}