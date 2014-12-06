using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDict.Entity
{
    public class DictData
    {
        public Dictionary<string, int> Contents { get; set; }
        public int StartOffset { get; set; }
        public string SourceDir { get; set; }
        public string FileFormatString { get; set; }

        public int MinPage { get; set; }
        public int MaxPage { get; set; }
    }
}
