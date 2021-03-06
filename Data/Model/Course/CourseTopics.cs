﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class CourseTopics : EntityBase
    {
        public int SectionID { get; set; }
        public string IDNumber { get; set; }
        public string Title { get; set; }
        public string TitleAR { get; set; }

        public virtual Attachment Image { get; set; }
        public virtual List<Attachment> Files { get; set; }
        public string Description { get; set; }
        public string DescriptionAR { get; set; }

        public virtual CourseCategory ParentCategory { get; set; }
    }
}
