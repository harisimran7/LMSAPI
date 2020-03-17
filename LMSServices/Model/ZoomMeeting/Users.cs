using System;
using System.Collections.Generic;
using System.Text;

namespace LMSServices.Model.ZoomMeeting
{
    public class Users
    {
        public int page_count { get; set; }
        public int page_number { get; set; }
        public int page_size { get; set; }
        public int total_records { get; set; }

        public List<User> users { get; set; }
    }

    public class User {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        
            public string email { get; set; }
        public int type { get; set; }
        public string status { get; set; }
        public Int64 pmi { get; set; } //"Personal meeting ID of the user."
        public string timezone { get; set; }
        public string dept { get; set; }
        public string created_at { get; set; }
        public string last_login_time { get; set; }
        public string last_client_version { get; set; }
        public List<string> group_ids { get; set; }
        public List<string> im_group_ids { get; set; }
        public int verified { get; set; }

    }
}
