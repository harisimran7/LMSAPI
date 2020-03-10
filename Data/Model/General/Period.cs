using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class Period: EntityBase
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
