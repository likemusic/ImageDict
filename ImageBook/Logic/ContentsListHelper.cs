using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageBook.Entity;
using System.IO;

namespace ImageBook.Logic
{
    public class ContentsListHelper
    {
        public ContentsList LoadFromTxtFile(string Filename)
        {
            var FileLines = File.ReadLines(Filename);
            var Ret = FileLines.Select((value, index) => new { value, index })
                .ToDictionary(pair => pair.value, pair => pair.index);
            return Ret as ContentsList;
        }
    }
}
