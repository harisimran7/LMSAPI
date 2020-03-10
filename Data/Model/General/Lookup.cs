using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class Lookup : EntityBase
    {
        public string Name { get; set; }
        public string NameAR { get; set; }

        public string Alias { get; set; }
        public string AliasAR { get; set; }

        public virtual LookupCategory Category { get; set; }
    }
}
