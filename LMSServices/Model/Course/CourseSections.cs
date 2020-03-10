using System;
using System.Collections.Generic;
using System.Text;
using LMSData.Enums;

namespace Services.Model
{
    public class CourseSections : BaseModel
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string TitleAR { get; set; }

        public Visibility Visibility { get; set; }

        public virtual Course Course { get; set; }

    }
}