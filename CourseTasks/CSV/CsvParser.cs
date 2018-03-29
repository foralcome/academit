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
            destination = destination.Replace("&", "&amp;");
            destination = destination.Replace("<", "&lt;");
            destination = destination.Replace(">", "&gt;");
            return destination;
        }

        public bool ParseInHtmlFile(string fileWrite)
        {
            if (!this.isFileOpen)
            {
                throw new FileNotFoundException("файл не найден!!");
            }

            this.CountRecords = 0;
            int countFoundCols = 0;
            string[] stringsCsv = new string[this.countColsInCsv];
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
                        sw.WriteLine("<title>HTML-страница разбора CSV-файла {0}</title>", this.fileName);
                        sw.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset={0}\">", this.FileEncoding.HeaderName);
                        sw.WriteLine("<body>");
                        sw.WriteLine("<table>");

                        string csvData = sr.ReadToEnd();

                        StringBuilder buffer = new StringBuilder();
                        int countQuote = 0;

                        for (int i = 0; i < csvData.Length; i++)
                        {
                            //пока не встретили кавычку "
                            if (!isQuote)
                            {
                                //найден разделитель
                                if (csvData[i] == this.Separator)
                                {
                                    stringsCsv[countFoundCols] = buffer.ToString();
                                    buffer.Clear();
                                    countFoundCols++;
                                }
                                //достигнут конец файла
                                else if (i == csvData.Length - 1)
                                {
                                    stringsCsv[countFoundCols] = buffer.ToString();
                                    buffer.Clear();
                                    countFoundCols++;
                                }
                                //найдена кавычка
                                else if (csvData[i] == '\"')
                                {
                                    isQuote = true;
                                    countQuote = 1;
                                    buffer.Clear();
                                    continue;
                                }
                                //обнаружен перенос строки
                                else if (csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    stringsCsv[countFoundCols] = buffer.ToString();
                                    buffer.Clear();
                                    countFoundCols++;

                                    i += Environment.NewLine.Length - 1;
                                }
                                else
                                {
                                    buffer.Append(csvData[i]);
                                    continue;
                                }
                            }
                            //внутри кавычки "
                            else
                            {
                                //найден разделитель
                                if (csvData[i] == this.Separator && countQuote % 2 == 0)
                                {
                                    stringsCsv[countFoundCols] = buffer.ToString();
                                    countFoundCols++;
                                    countQuote = 0;
                                    buffer.Clear();
                                    isQuote = false;
                                }
                                //это предпоследний символ в файле
                                else if (i == csvData.Length - 1)
                                {
                                    stringsCsv[countFoundCols] = buffer.ToString();
                                    countFoundCols++;
                                    isQuote = false;
                                    buffer.Clear();
                                }
                                //обнаружен перенос строки
                                else if (csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    if (countQuote % 2 == 0)
                                    {
                                        stringsCsv[countFoundCols] = buffer.ToString();
                                        countFoundCols++;
                                        isQuote = false;
                                        buffer.Clear();
                                    }
                                    else
                                    {
                                        buffer.Append("<br>");
                                    }

                                    i += Environment.NewLine.Length - 1;
                                }
                                //найдена кавычка
                                else if (csvData[i] == '"')
                                {
                                    if (csvData[i + 1] == '"')
                                    {
                                        buffer.Append("\"");
                                        i++;
                                    }
                                    else
                                    {
                                        countQuote++;
                                    }
                                }
                                else
                                {
                                    buffer.Append(csvData[i]);
                                    continue;
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
