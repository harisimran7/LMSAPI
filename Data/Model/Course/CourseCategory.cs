using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class CourseCategory : EntityBase
    {
        public int ParentID { get; set; }
        public string IDNumber { get; set; }
        public string Name { get; set; }
        public string NameAR { get; set; }

        public string Description { get; set; }
        public string DescriptionAR { get; set; }

        public virtual Attachment Image { get; set; }
        public virtual CourseCategory ParentCategory { get; set; }
    }
}
