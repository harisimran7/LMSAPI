using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class Contact: EntityBase
    {
        public string PhoneResidence { get; set; }
        public string PhoneOffice { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }

        public virtual ICollection<LookupValue> SocialContacts { get; set; }
        //public string Skype { get; set; }
        //public string Yahoo { get; set; }
        //public string Gmail { get; set; }
        //public string MicrosoftOutlook { get; set; }
        //public string Facebook { get; set; }
        //public string Other { get; set; }
    }
}
