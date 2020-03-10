using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMSData.Model
{
    public class Annotation: EntityBase
    {
        public string TypeName { get; }
        public DateTime Time { get; set; }

        [RegularExpression("[ \\r\\n\\t\\S]+")]
        public string Text { get; set; }

        public virtual Member Author { get; set; }

    }
}
