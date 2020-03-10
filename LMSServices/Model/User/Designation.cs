using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class Designation : BaseModel
    {
        public string Name { get; set; }
        public string NameAR { get; set; }

        public string Alias { get; set; }
        public string AliasAR { get; set; }
    }
}
