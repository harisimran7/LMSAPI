using System;
using System.Collections.Generic;
using System.Text;
using LMSData.Enums;

namespace LMSData.Model
{
    public class Course: EntityBase
    {
        public string IDNumber { get; set; }
        public string Name { get; set; }
        public string NameAR { get; set; }

        public string ShortName { get; set; }
        public string ShortNameAR { get; set; }

        public Visibility Visibility { get; set; }

        public virtual Period Duration { get; set; }
        public virtual Attachment Image { get; set; }
        public virtual List<Attachment> ResourceFiles { get; set; }
        public virtual Attachment Certificate { get; set; }

        public string Description { get; set; }
        public string DescriptionAR { get; set; }

        public virtual CourseCategory Category { get; set; }

    }
}