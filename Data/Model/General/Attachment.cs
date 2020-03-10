using System;
using System.Collections.Generic;
using System.Text;

namespace LMSData.Model
{
    public class Attachment: MappingBase
    {
        public byte[] Data { get; set; }
        public string Creation { get; set; }
        public string Title { get; set; }
        public byte[] Hash { get; set; }
        public int? Size { get; set; }
        public string Url { get; set; }
        public string Language { get; set; }
        public string ContentType { get; set; }
    }
}
