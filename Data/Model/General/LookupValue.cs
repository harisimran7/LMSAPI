using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class LookupValue : EntityBase
    {
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }

        public string XML1 { get; set; }
        public string XML2 { get; set; }

        public virtual Lookup Lookup { get; set; }
    }
}
