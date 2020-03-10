using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Services.Model
{
    public class Annotation: BaseModel
    {
        public string TypeName { get; }
        public virtual BaseModel Author { get; set; }
        public DateTime Time { get; set; }

        [RegularExpression("[ \\r\\n\\t\\S]+")]
        public string Text { get; set; }
    }
}
