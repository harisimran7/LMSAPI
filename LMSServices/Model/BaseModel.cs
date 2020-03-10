using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class BaseModel
    {
        public int? ID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastEditDate { get; set; }

        public int? CreatedBy { get; set; }
        public int? LastEditBy { get; set; }

        public bool IsActive { get; set; } = false;

    }
}
