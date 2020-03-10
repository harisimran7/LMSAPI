using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class ContactPoint: EntityBase
    {
        public virtual Period Period { get; set; }
        public virtual ContactPointSystem? System { get; set; }
        public int? Rank { get; set; }
        public string Value { get; set; }
        public virtual ContactPointUse? Use { get; set; }
        public int RankElement { get; set; }

        public enum ContactPointSystem
        {
            Phone = 0,
            Fax = 1,
            Email = 2,
            Pager = 3,
            Url = 4,
            Sms = 5,
            Other = 6
        }
        public enum ContactPointUse
        {
            Home = 0,
            Work = 1,
            Temp = 2,
            Old = 3,
            Mobile = 4
        }
    }
}
