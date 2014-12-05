using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageBook.Entity
{
    public class DictData
    {
        public Dictionary<string, int> Contents { get; set; }
        public int StartOffset { get; set; }
        public string SourceDir { get; set; }
        public string FileFormatString { get; set; }

        public int MinPage{ get { return StartOffset; } }
        public int MaxPage { get { return StartOffset + Contents.Count; } }
    }
}
