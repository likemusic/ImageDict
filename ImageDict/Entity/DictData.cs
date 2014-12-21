using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDict.Entity
{
    public class DictData
    {
        public Dictionary<string, int> Contents { get; set; }
        public Dictionary<string, int> ContentsEnds { get; set; }

        public DictDataSettings Settings { get; set; }

        public string SourceDir { get; set; }
    }
}
