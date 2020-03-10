using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public abstract class MappingBase : BaseModel
    {

        public string ReferenceTable { get; set; }
        public string ReferenceColumn { get; set; }
        public string ReferenceEntityID { get; set; }
    }
    
}
