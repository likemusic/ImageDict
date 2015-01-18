using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ImageDict.Entity
{
    public class DictDataSettings
    {
        public string FileFormatString { get; set; }    //формат имен файлов

        public int PagesPerFile { get; set; }           //страниц в одном файле (по умолчанию - 1)

        public int MinFileNumber { get; set; }          //минимальный номер файла (по умолчанию - 0)
        public int MaxFileNumber { get; set; }          //максимальный номер файла (по умолчанию - 0)

        public int MinPage { get; set;}                 //номер страницы первого файла (по умолчанию - 0)
        public int MaxPage;                             //максимальный номер, не сериализуем

        public int StartDictPage { get; set; }          //номер страницы с которой начинается словарь (по умолчанию - 0)

        public int WordsPerFile { get; set; }           //слов на файл

        public string ContentColumnSeparator { get; set; } //разделитель для колонок
        public bool ContentHaveEnds { get; set; } //разделитель для колонок

        public string CultureName { get; set; } //http://msdn.microsoft.com/ru-ru/goglobal/bb896001.aspx
    }
}
