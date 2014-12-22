using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageDict.Entity
{
    public class Scale
    {
        public Scale()
        {
            Type = ScaleTypeEnum.ByValue;
            Value = 1;
        }

        public ScaleTypeEnum Type {get;set;}
        public double Value { get; set; }
    }
}
