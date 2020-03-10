using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class ContactDetail: EntityBase
    {
        public string Name { get; set; } //uri
        public virtual IList<ContactPoint> Telecom { get; set; }
    }
}
