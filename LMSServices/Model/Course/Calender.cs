using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class Calender : BaseModel
    {
        public DateTime Date { get; set; }
        public string Shift { get; set; }
        public string StartTime{ get; set; }
        public string EndTime { get; set; }
        public int Duration { get; set; }

    }
}
