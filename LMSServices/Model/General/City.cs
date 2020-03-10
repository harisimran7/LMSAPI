using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class City : BaseModel
    {
        
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string NameAR { get; set; }

        public virtual Country Country { get; set; }
    }
}
