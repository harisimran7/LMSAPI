using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class Country: EntityBase
    {
        public string Name { get; set; }
        public string NameAR { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
