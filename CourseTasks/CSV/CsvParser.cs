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
            if (!File.Exists(filePath))
            {
                this.isFileOpen = false;
                throw new FileNotFoundException("файл не найден!");
            }

            this.filePath = filePath;
            this.fileName = Path.GetFileName(filePath);
            this.FileEncoding = encoding;
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

        private Encoding FileEncoding
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
            destination = destination.Replace("&", "&amp");
            destination = destination.Replace("<", "&lt");
            destination = destination.Replace(">", "&gt");
            destination = destination.Replace(Environment.NewLine, "<br>");
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

        public bool ParseInHtmlFile(string fileWrite)
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
                using (StreamReader sr = new StreamReader(this.filePath, this.FileEncoding))
                {
                    using (StreamWriter sw = new StreamWriter(fileWrite))
                    {
                        sw.WriteLine("< !DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">");
                        sw.WriteLine("<html>");
                        sw.WriteLine("<head>");
                        sw.WriteLine(string.Format("<title>HTML-страница разбора CSV-файла {0}</title>", this.fileName));
                        sw.WriteLine(string.Format("<meta http-equiv=\"Content-Type\" content=\"text/html; charset={0}\">", this.FileEncoding.HeaderName));
                        sw.WriteLine("<body>");
                        sw.WriteLine("<table>");

                        string csvData = sr.ReadToEnd();

                        for (int i = 0; i < csvData.Length; i++)
                        {
                            char c = csvData[i];
                            //пока не встретили кавычку "
                            if (!isQuote)
                            {
                                if (csvData[i] == this.Separator || csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    char[] subString = new char[i - indexStart];
                                    for (int j = indexStart, k = 0; j < i; j++, k++)
                                    {
                                        subString[k] = csvData[j];
                                    }
                                    stringsCsv[countFoundCols] = new string(subString);
                                    countFoundCols++;

                                    if (csvData[i] == this.Separator)
                                    {
                                        indexStart = i + 1;
                                    }
                                    else
                                    {
                                        indexStart = i + Environment.NewLine.Length;
                                        i = indexStart;
                                    }
                                }
                                //достигнут конец файла
                                else if (i == csvData.Length - 1)
                                {
                                    char[] subString = new char[i - indexStart + 1];
                                    for (int j = indexStart, k = 0; j < i + 1; j++, k++)
                                    {
                                        subString[k] = csvData[j];
                                    }
                                    stringsCsv[countFoundCols] = new string(subString);

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
                                if (csvData[i] == this.Separator || csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    //сохраняем наше имя
                                    int lengthSubString = i - indexStart - 2;
                                    int countQuote = 0;
                                    char[] subString = new char[lengthSubString];
                                    for (int j = indexStart, k = 0; j < i; j++, k++)
                                    {
                                        if (csvData[j] == '"')
                                        {
                                            countQuote++;
                                        }
                                        if (k < lengthSubString)
                                        {
                                            subString[k] = csvData[j + 1];
                                        }
                                    }
                                    //проверяем имя на завершённость (количество кавычек должно быть чётным с учётом первой
                                    if (countQuote % 2 == 0)
                                    {
                                        stringsCsv[countFoundCols] = new string(subString);
                                        stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Replace("\"\"", "\"");
                                        countFoundCols++;

                                        if (csvData[i] == this.Separator)
                                        {
                                            indexStart = i + 1;
                                        }
                                        else
                                        {
                                            indexStart = i + Environment.NewLine.Length;
                                            i = indexStart;
                                        }

                                        isQuote = false;
                                    }
                                }
                                //достигнут конец файла
                                else if (i == csvData.Length - 1)
                                {
                                    stringsCsv[countFoundCols] = csvData.Substring(indexStart, i - indexStart + 1);
                                    stringsCsv[countFoundCols] = stringsCsv[countFoundCols].Replace("\"\"", "\"");
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
                                stringsCsv[1] = ReplaceToHTMLCode(stringsCsv[1]);
                                sw.WriteLine(stringsCsv[1]);
                                stringsCsv[1] = "";
                                sw.WriteLine("</td>");
                                sw.WriteLine("<td>");
                                stringsCsv[2] = ReplaceToHTMLCode(stringsCsv[2]);
                                sw.WriteLine(stringsCsv[2]);
                                stringsCsv[2] = "";
                                sw.WriteLine("</td>");
                                sw.WriteLine("</tr>");

                                this.CountRecords++;
                                countFoundCols = 0;
                            }
                        }
                        sw.WriteLine("</table>");
                        sw.WriteLine("</body>");
                        sw.WriteLine("</html>");
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
