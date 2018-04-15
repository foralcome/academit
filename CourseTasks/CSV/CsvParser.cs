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
        private string fileName;
        private string filePath;
        private bool isFileOpen;

        public CsvParser(string filePath, char separator, Encoding encoding)
        {
            if (!File.Exists(filePath))
            {
                this.isFileOpen = false;
                throw new FileNotFoundException("файл не найден!");
            }

            this.filePath = filePath;
            this.fileName = Path.GetFileName(filePath);
            this.FileEncoding = encoding;
            this.Separator = separator;
            this.isFileOpen = true;
        }

        public char Separator
        {
            get;
        }

        private Encoding FileEncoding
        {
            get;
        }

        private string GetHTMLCodeByChar(char c)
        {
            string s;
            switch (c)
            {
                case '&':
                    s = "&amp;";
                    break;
                case '<':
                    s = "&lt;";
                    break;
                case '>':
                    s = "&gt;";
                    break;
                default:
                    s = c.ToString();
                    break;
            }
            return s;
        }

        public bool ParseInHtmlFile(string fileWrite)
        {
            if (!this.isFileOpen)
            {
                throw new FileNotFoundException("файл не найден!!");
            }

            bool isQuote = false;
            int countChars = 0;

            try
            {
                using (StreamReader sr = new StreamReader(this.filePath, this.FileEncoding))
                {
                    using (StreamWriter sw = new StreamWriter(fileWrite))
                    {
                        sw.WriteLine("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">");
                        sw.WriteLine("<html>");
                        sw.WriteLine("<head>");
                        sw.WriteLine("<title>HTML-страница разбора CSV-файла {0}</title>", this.fileName);
                        sw.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset={0}\">", this.FileEncoding.HeaderName);
                        sw.WriteLine("</head>");
                        sw.WriteLine("<body>");
                        sw.WriteLine("<table>");

                        string csvData = sr.ReadToEnd();

                        StringBuilder resultData = new StringBuilder();
                        resultData.Append("<tr>");

                        int countQuote = 0;

                        for (int i = 0; i < csvData.Length; i++)
                        {
                            if (countChars == 0)
                            {
                                resultData.Append("<td>");
                            }
                            //пока не встретили кавычку "
                            if (!isQuote)
                            {
                                //найден разделитель
                                if (csvData[i] == this.Separator)
                                {
                                    resultData.Append("</td>");
                                    countChars = 0;
                                }
                                //найдена кавычка
                                else if (csvData[i] == '\"')
                                {
                                    isQuote = true;
                                    countQuote = 1;
                                    countChars++;
                                    continue;
                                }
                                //обнаружен перенос строки
                                else if (csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    resultData.Append("</td></tr>");
                                    i += Environment.NewLine.Length - 1;
                                    countChars = 0;

                                    if (i + Environment.NewLine.Length < csvData.Length)
                                    {
                                        resultData.Append("<tr>");
                                    }
                                }
                                else
                                {
                                    resultData.Append(GetHTMLCodeByChar(csvData[i]));
                                    countChars++;
                                    continue;
                                }
                            }
                            //внутри кавычки "
                            else
                            {
                                //найден разделитель
                                if (csvData[i] == this.Separator && countQuote % 2 == 0)
                                {
                                    countChars = 0;
                                    countQuote = 0;
                                    isQuote = false;
                                    resultData.Append("</td>");
                                }
                                //обнаружен перенос строки
                                else if (csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    if (countQuote % 2 == 0)
                                    {
                                        isQuote = false;
                                        countChars = 0;
                                        resultData.Append("</td></tr>");
                                        if (i + Environment.NewLine.Length < csvData.Length)
                                        {
                                            resultData.Append("<tr>");
                                        }
                                    }
                                    else
                                    {
                                        resultData.Append("<br>");
                                        countChars++;
                                    }

                                    i += Environment.NewLine.Length - 1;
                                }
                                //найдена кавычка
                                else if (csvData[i] == '"')
                                {
                                    if (csvData[i + 1] == '"')
                                    {
                                        resultData.Append("\"");
                                        i++;
                                    }
                                    else
                                    {
                                        countQuote++;
                                    }
                                    countChars++;
                                }
                                else
                                {
                                    resultData.Append(GetHTMLCodeByChar(csvData[i]));
                                    countChars++;
                                    continue;
                                }
                            }
                        }
                        if (countChars != 0)
                        {
                            resultData.Append("</td></tr>");
                        }
                        sw.WriteLine(resultData);

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
