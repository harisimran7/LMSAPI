using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using LMSData.Enums;

namespace LMSData.Model
{
    public class CourseSections : EntityBase
    {
        public string Title { get; set; }
        [NotMapped]
        public string TitleAR { get; set; }
        public Visibility Visibility { get; set; }

        public virtual Course Course { get; set; }

    }
}