using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class Country: BaseModel
    {
        public string Name { get; set; }
        public string NameAR { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
