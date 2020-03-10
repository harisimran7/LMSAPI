using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class Period: BaseModel
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
