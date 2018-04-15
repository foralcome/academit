﻿using System;
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
            if (args.Length != 2)
            {
                Console.WriteLine("В программу должно быть передано 2 аргумента через пробел:");
                Console.WriteLine("1) путь к CSV-файлу");
                Console.WriteLine("2) путь к HTML-файлу для сохранения");

            }
            else
            {
                CsvParser p = new CsvParser(args[0], ',', Encoding.UTF8);
                if (!File.Exists(args[1]))
                {
                    Console.WriteLine("Файл не найден! Путь {0}", args[1]);
                    Console.WriteLine("Выполнение программы было прервано!");
                }
                else
                {
                    if (p.ParseInHtmlFile(args[1]))
                    {
                        Console.WriteLine("Операция чтения файла CSV выполнена успешно!");
                        System.Diagnostics.Process.Start(args[1]);
                    }
                    else
                    {
                        Console.WriteLine("Во время выполнения разбора файла произошла ошибка!");
                    }
                }
            }
        }
    }
}