using System;
using System.Collections.Generic;
using System.Text;

namespace LMSServices.ZoomMeeting
{

    public class PayloadRequest
    {
        public string iss { get; set; }
        public int timestamp { get; set; }

    }

    public class PayloadResponse
    {
        public string api_key { get; set; }
        public int expireDate { get; set; }
    }
}
