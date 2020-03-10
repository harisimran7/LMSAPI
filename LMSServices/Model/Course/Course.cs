using System;
using System.Collections.Generic;
using System.Text;
using LMSData.Enums;

namespace Services.Model
{
    public class Course: BaseModel
    {
        public int CategoryID { get; set; }
        public string IDNumber { get; set; }
        public string Name { get; set; }
        public string NameAR { get; set; }

        public string ShortName { get; set; }
        public string ShortNameAR { get; set; }

        public Visibility Visibility { get; set; }

        public Period Duration { get; set; }
        public virtual Attachment Image { get; set; }
        public List<Attachment> ResourceFiles { get; set; }
        public virtual Attachment Certificate { get; set; }

        public string Description { get; set; }
        public string DescriptionAR { get; set; }

        public virtual CourseCategory ParentCategory { get; set; }

    }
}