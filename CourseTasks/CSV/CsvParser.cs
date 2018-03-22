using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.Barsukov
{
    class CsvParser
    {
        private int countColsInCsv;
        private string fileName;
        private string filePath;
        private bool isFileOpen;

        public CsvParser(string filePath, int countCols, char separator, Encoding encoding)
        {
            if (File.Exists(filePath) == false)
            {
                this.isFileOpen = false;
                throw new FileNotFoundException("файл не найден!");
            }

            this.filePath = filePath;
            this.fileName = Path.GetFileName(filePath);
            this.fileEncoding = encoding;
            this.countColsInCsv = countCols;
            this.Separator = separator;

            this.isFileOpen = true;
        }

        public char Separator
        {
            get;
        }

        private int CountRecords
        {
            get;
            set;
        }

        private Encoding fileEncoding
        {
            get;
        }

        public int GetCountRecords()
        {
            return this.CountRecords;
        }

        private string ReplaceToHTMLCode(string source)
        {
            string destination = source;
            source.Replace("&", "&amp");
            source.Replace("<", "&lt");
            source.Replace(">", "&gt");
            source.Replace(Environment.NewLine, "<br>");
            return destination;
        }

        private static int GetCountQuoteInString(string source)
        {
            int countQuote = 0;
            for (int j = 0; j < source.Length; j++)
            {
                if (source[j] == '"')
                {
                    countQuote++;
                }
            }
            return countQuote;
        }

        public bool ParseInFile(string fileWrite)
        {
            if (this.isFileOpen == false)
            {
                throw new FileNotFoundException("файл не найден!!");
            }

            this.CountRecords = 0;
            int countFoundCols = 0;
            string[] stringsCsv = new string[this.countColsInCsv];
            int indexStart = 0;
            bool isQuote = false;

            try
            {
                using (StreamReader sr = new StreamReader(this.filePath, this.fileEncoding))
                {
                    Console.WriteLine("Открытие файла read.txt ({0})", this.filePath);
                    using (StreamWriter sw = new StreamWriter(fileWrite))
                    {
                        Console.WriteLine("Запись в файл write.txt ({0})", fileWrite);

                        sw.WriteLine("<table>");

                        string csvData = sr.ReadToEnd();

                        for (int i = 0; i < csvData.Length; i++)
                        {
                            char c = csvData[i];
                            //пока не встретили кавычку "
                            if (!isQuote)
                            {
                                if (csvData[i] == this.Separator)
                                {
                                    stringsCsv[countFoundCols] = csvData.Substring(indexStart, i - indexStart);
                                    countFoundCols++;
                                    indexStart = i + 1;
                                }
                                else if (csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    stringsCsv[countFoundCols] = csvData.Substring(indexStart, i - indexStart);
                                    countFoundCols++;
                                    indexStart = i + 1;
                                    i = indexStart + Environment.NewLine.Length;
                                }
                                else if (i == csvData.Length - 1)
                                {
                                    stringsCsv[countFoundCols] = csvData.Substring(indexStart, i - indexStart + 1);
                                    stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Trim();
                                    countFoundCols++;
                                }
                                else if (csvData[i] == '\"')
                                {
                                    isQuote = true;
                                    indexStart = i;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            //внутри кавычки "
                            else
                            {
                                //найден разделитель
                                if (csvData[i] == this.Separator)
                                {
                                    //сохраняем наше имя
                                    stringsCsv[countFoundCols] = csvData.Substring(indexStart, i - indexStart);

                                    //проверяем имя на завершённость (количество кавычек должно быть чётным с учётом первой

                                    if (GetCountQuoteInString(stringsCsv[countFoundCols]) % 2 == 0)
                                    {
                                        //сохраняем наше имя и убираем кавычки вначале и в конце строки
                                        stringsCsv[countFoundCols] = csvData.Substring(indexStart + 1, i - indexStart - 2);
                                        stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Replace("\"\"", "\"");
                                        stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Trim();

                                        countFoundCols++;
                                        indexStart = i + 1;
                                        isQuote = false;
                                    }
                                }
                                else if (csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    //сохраняем наше имя
                                    stringsCsv[countFoundCols] = csvData.Substring(indexStart, i - indexStart);

                                    //проверяем имя на завершённость (количество кавычек должно быть чётным с учётом первой
                                    if (GetCountQuoteInString(stringsCsv[countFoundCols]) % 2 == 0)
                                    {
                                        //сохраняем наше имя и убираем кавычки вначале и в конце строки
                                        stringsCsv[countFoundCols] = csvData.Substring(indexStart + 1, i - indexStart - 2);
                                        stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Replace("\"\"", "\"");
                                        stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Trim();

                                        countFoundCols++;
                                        indexStart = i + Environment.NewLine.Length;
                                        i = indexStart;
                                        isQuote = false;
                                    }

                                }
                                else if (i == csvData.Length - 1)
                                {
                                    stringsCsv[countFoundCols] = csvData.Substring(indexStart, i - indexStart + 1);
                                    stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Replace("\"\"", "\"");
                                    stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Trim();
                                    countFoundCols++;
                                    isQuote = false;
                                }
                            }

                            if (countFoundCols == this.countColsInCsv)
                            {
                                sw.WriteLine("<tr>");
                                sw.WriteLine("<td>");
                                stringsCsv[0] = ReplaceToHTMLCode(stringsCsv[0]);
                                sw.WriteLine(stringsCsv[0]);
                                stringsCsv[0] = "";
                                sw.WriteLine("</td>");
                                sw.WriteLine("<td>");
                                sw.WriteLine(stringsCsv[1]);
                                stringsCsv[1] = "";
                                sw.WriteLine("</td>");
                                sw.WriteLine("<td>");
                                sw.WriteLine(stringsCsv[2]);
                                stringsCsv[2] = "";
                                sw.WriteLine("</td>");
                                sw.WriteLine("</tr>");

                                this.CountRecords++;
                                countFoundCols = 0;
                            }
                        }
                        sw.WriteLine("</table>");
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка!!!");
                Console.WriteLine(e.Message);
            }

            return false;
        }
    }
}
