using System;
using System.Collections.Generic;
using System.Text;
using LMSData.Enums;

namespace Services.Model
{
    public class Member : BaseModel
    {
        public string MemberID { get; set; }

        public string Password { get; set; }

        public HumanName Name { get; set; }
        public HumanName NameAR { get; set; }

        public string Alias { get; set; }
        public string AliasAR { get; set; }

        public virtual Attachment Picture { get; set; }
        public virtual Nationality NationalityID { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual Gender Gender { get; set; }

        public string DateofBirth { get; set; }
        public string DateofBirthHijri { get; set; }

        public string Remarks { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual ICollection<Address> Address { get; set; }

        public virtual ICollection<Designation> Designation { get; set; }

    }
}
