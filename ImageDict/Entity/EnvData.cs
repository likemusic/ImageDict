using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDict.Entity
{
    public class EnvData
    {
        public EnvData()
        {
            Scale = 1;
            ScaleStep = 1.1;
        }

        public DictData DictData { get; set; }
        public int CurrentPage {get;set;}
        public double Scale { get; set; }
        public double ScaleStep { get; set; }

        public System.Drawing.Image Image { get; set; } 
    }
}
