using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class Address: EntityBase
    {
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public virtual Country Country { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Text { get; set; }
        public AddressType? Type { get; set; }
        public AddressUse? Use { get; set; }
        public virtual Period Period { get; set; }
        public string PostalCode { get; set; }

        public enum AddressUse
        {
            Home = 0,
            Work = 1,
            Temp = 2,
            Old = 3

        }
        public enum AddressType {
            Postal = 0,
            Physical = 1,
            Both = 2
        }
    }
}
