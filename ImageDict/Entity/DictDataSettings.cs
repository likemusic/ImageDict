using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDict.Entity
{
    public class DictDataSettings
    {
        public int StartOffset { get; set; }
        public string FileFormatString { get; set; }
        public int MinPage { get; set; }
        public int MaxPage { get; set; }
    }
}
