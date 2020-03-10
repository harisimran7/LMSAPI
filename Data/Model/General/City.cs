using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class City : EntityBase
    {
        public string Name { get; set; }
        public string NameAR { get; set; }

        public virtual Country Country { get; set; }
    }
}
