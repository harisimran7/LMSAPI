using System;
using System.Collections.Generic;
using System.Text;

namespace LMSServices.ZoomMeeting
{
    public class Header
    {
        public Header()
        {
            alg = "HS256";
            typ = "JWT";
        }
        public string alg { get; set; }
        public string typ { get; set; }
    }

}
