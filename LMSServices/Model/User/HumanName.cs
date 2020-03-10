using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class HumanName : MappingBase
    {
        public string Family { get; set; }
        public string Text { get; set; }
        public NameUse? Use { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public virtual Period Period { get; set; }
        public string Given { get; set; }

        public enum NameUse
        {
            Usual = 0,
            Official = 1,
            Temp = 2,
            Nickname = 3,
            Anonymous = 4,
            Old = 5,
            Maiden = 6
        }
    }
}
