using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Model
{
    public class ContactDetail: BaseModel
    {
        public string Name { get; set; } //uri
        public virtual IList<ContactPoint> Telecom { get; set; }
    }
}
