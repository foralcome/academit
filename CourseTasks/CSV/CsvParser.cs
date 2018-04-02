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
                    s = "" + c;
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

            this.CountRecords = 0;
            bool isQuote = false;
            bool isBlockEnd = true;
            bool isRowEnd = true;

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

                        StringBuilder resultData = new StringBuilder();
                        int countQuote = 0;

                        for (int i = 0; i < csvData.Length; i++)
                        {
                            //пока не встретили кавычку "
                            if (!isQuote)
                            {
                                //найден разделитель
                                if (csvData[i] == this.Separator)
                                {
                                    isBlockEnd = true;
                                }
                                //найдена кавычка
                                else if (csvData[i] == '\"')
                                {
                                    isQuote = true;
                                    countQuote = 1;
                                    continue;
                                }
                                //обнаружен перенос строки
                                else if (csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    isBlockEnd = true;
                                    isRowEnd = true;

                                    i += Environment.NewLine.Length - 1;
                                }
                                else
                                {
                                    if (isRowEnd == true)
                                    {
                                        resultData.Append("<tr>");
                                        isRowEnd = false;
                                    }
                                    if (isBlockEnd == true)
                                    {
                                        resultData.Append("<td>");
                                        isBlockEnd = false;
                                    }

                                    resultData.Append(GetHTMLCodeByChar(csvData[i]));
                                    continue;
                                }
                            }
                            //внутри кавычки "
                            else
                            {
                                //найден разделитель
                                if (csvData[i] == this.Separator && countQuote % 2 == 0)
                                {
                                    countQuote = 0;
                                    isQuote = false;
                                    isBlockEnd = true;
                                }
                                //обнаружен перенос строки
                                else if (csvData[i] == '\r' || csvData[i] == '\n')
                                {
                                    if (countQuote % 2 == 0)
                                    {
                                        isQuote = false;
                                        isBlockEnd = true;
                                        isRowEnd = true;
                                    }
                                    else
                                    {
                                        resultData.Append("<br>");
                                    }

                                    i += Environment.NewLine.Length - 1;
                                }
                                //найдена кавычка
                                else if (csvData[i] == '"')
                                {
                                    if (isBlockEnd == true)
                                    {
                                        resultData.Append("<td>");
                                        isBlockEnd = false;
                                    }

                                    if (csvData[i + 1] == '"')
                                    {
                                        resultData.Append("\"");
                                        i++;
                                    }
                                    else
                                    {
                                        countQuote++;
                                    }
                                }
                                else
                                {
                                    resultData.Append(GetHTMLCodeByChar(csvData[i]));
                                    continue;
                                }
                            }

                            if (isBlockEnd == true)
                            {
                                resultData.Append("</td>");
                            }
                            if (isRowEnd == true)
                            {
                                resultData.Append("</tr>");
                            }
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
