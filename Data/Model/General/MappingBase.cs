using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public abstract class MappingBase : EntityBase
    {

        public string ReferenceTable { get; set; }
        public string ReferenceColumn { get; set; }
        public string ReferenceEntityID { get; set; }
    }
    
}
